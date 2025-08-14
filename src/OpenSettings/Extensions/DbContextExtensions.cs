using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OpenSettings.Extensions
{
    internal static class DbContextExtensions
    {
        internal static void MarkAsModified<TEntity>(this DbContext context, TEntity entity, params Expression<Func<TEntity, object>>[] properties) where TEntity : class
        {
            var entry = context.Entry(entity);

            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
        }

        internal static void MarkAsModified<TEntity>(this EntityEntry<TEntity> entry, params Expression<Func<TEntity, object>>[] properties) where TEntity : class
        {
            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
        }

        internal static void MarkAsModified<TEntity>(this DbContext context, TEntity entity, ICollection<Expression<Func<TEntity, object>>> properties) where TEntity : class
        {
            var entry = context.Entry(entity);

            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
        }
    }
}