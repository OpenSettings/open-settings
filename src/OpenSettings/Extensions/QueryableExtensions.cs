using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace OpenSettings.Extensions
{
    public static class QueryableExtensions
    {
        private const string InMemoryProviderName = "Microsoft.EntityFrameworkCore.InMemory";

        private const string SqliteProviderName = "Microsoft.EntityFrameworkCore.Sqlite";

        private static readonly MethodInfo StringContainsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });

        private static readonly MethodInfo LikeMethod = typeof(DbFunctionsExtensions).GetMethod(nameof(DbFunctionsExtensions.Like), new[] { typeof(DbFunctions), typeof(string), typeof(string) });

        private static readonly MemberExpression EfFunctionsProperty = Expression.Property(null, typeof(EF).GetProperty(nameof(EF.Functions)));

        public static bool IsInMemory(this DatabaseFacade database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            return database.ProviderName == InMemoryProviderName;
        }

        public static bool IsSqlite(this DatabaseFacade database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            return database.ProviderName == SqliteProviderName;
        }

        internal static IQueryable<TEntity> SearchBy<TEntity>(
            this IQueryable<TEntity> query,
            IEnumerable<Expression<Func<TEntity, string>>> fieldSelectors,
            string searchTerm,
            DbContext context)
            where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return query;
            }

            Expression<Func<TEntity, bool>> combinedExpression = null;

            var isInMemory = context.Database.IsInMemory();

            foreach (var fieldSelector in fieldSelectors)
            {
                var searchExpression = isInMemory 
                    ? BuildContainsExpression(fieldSelector, searchTerm.Trim(Constants.PercentageChar)) 
                    : BuildLikeExpression(fieldSelector, searchTerm);

                combinedExpression = combinedExpression == null
                    ? searchExpression
                    : combinedExpression.Or(searchExpression);
            }

            return combinedExpression == null ? query : query.Where(combinedExpression);
        }


        internal static IQueryable<TEntity> SearchBy<TEntity>(
            this IQueryable<TEntity> query,
            Expression<Func<TEntity, string>> fieldSelector,
            string searchTerm,
            DbContext context)
            where TEntity : class
        {
            return query.Where(context.Database.IsInMemory() 
                ? BuildContainsExpression(fieldSelector, searchTerm.Trim(Constants.PercentageChar)) 
                : BuildLikeExpression(fieldSelector, searchTerm));
        }

        private static Expression<Func<TEntity, bool>> BuildContainsExpression<TEntity>(
            Expression<Func<TEntity, string>> fieldSelector,
            string searchTerm)
            where TEntity : class
        {
            var parameter = fieldSelector.Parameters[0]; 
            var property = fieldSelector.Body;

            var searchExpression = Expression.Call(
                property,
                StringContainsMethod,
                Expression.Constant(searchTerm));

            return Expression.Lambda<Func<TEntity, bool>>(searchExpression, parameter);
        }

        private static Expression<Func<TEntity, bool>> BuildLikeExpression<TEntity>(
            Expression<Func<TEntity, string>> fieldSelector,
            string searchTerm)
            where TEntity : class
        {
            var parameter = fieldSelector.Parameters[0];
            var property = fieldSelector.Body; 

            var likeExpression = Expression.Call(
                LikeMethod,
                EfFunctionsProperty,
                property,
                Expression.Constant(searchTerm));

            return Expression.Lambda<Func<TEntity, bool>>(likeExpression, parameter);
        }

        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var combined = new ReplaceParameterVisitor(expr1.Parameters[0], parameter)
                .Visit(expr1.Body);
            var right = new ReplaceParameterVisitor(expr2.Parameters[0], parameter)
                .Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(combined, right), parameter);
        }
    }
}