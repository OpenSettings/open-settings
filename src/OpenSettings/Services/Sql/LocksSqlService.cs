using Microsoft.EntityFrameworkCore;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using LockSqlModel = OpenSettings.Domains.Sql.Entities.LockSqlModel;

namespace OpenSettings.Services.Sql
{
    internal sealed class LocksSqlService : ILocksSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public LocksSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AcquireLockAsync(AcquireLockInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Locks.FindAsync(new object[] { input.Key }, cancellationToken);

            if (entity == null)
            {
                HandleAcquireNewLock(input);
            }
            else if (!HandleAcquireExistingLock(entity, input))
            {
                return false;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task SetLockExpiryTimeAsync(SetLockExpiryTimeInput input, CancellationToken cancellationToken)
        {
            var entity = await _context.Locks.FindAsync(new object[] { input.Key }, cancellationToken);

            if (entity == null || entity.Owner != input.Owner)
            {
                return;
            }

            entity.ExpiryTime = input.ExpiryTime;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ReleaseLockAsync(ReleaseLockInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Locks.FirstOrDefaultAsync(l => l.Key == input.Key && l.Owner == input.Owner,
                cancellationToken);

            if (entity == null)
            {
                return false;
            }

            _context.Locks.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private void HandleAcquireNewLock(AcquireLockInput input)
        {
            var entity = new LockSqlModel
            {
                Key = input.Key,
                Owner = input.Owner,
                ExpiryTime = DateTime.UtcNow.Add(input.Timeout)
            };

            _context.Locks.Add(entity);
        }

        private static bool HandleAcquireExistingLock(LockSqlModel entity, AcquireLockInput input)
        {
            if (entity.ExpiryTime > DateTime.UtcNow)
            {
                return false;
            }

            entity.Owner = input.Owner;
            entity.ExpiryTime = DateTime.UtcNow.Add(input.Timeout);

            return true;
        }
    }
}