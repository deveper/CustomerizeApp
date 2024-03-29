﻿using Customerize.Core.UnitOfWorks;
using Customerize.Repository;

namespace Customerize.Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<bool> CommitAsync()
        {

            await _context.SaveChangesAsync();
            return true;

        }
    }
}
