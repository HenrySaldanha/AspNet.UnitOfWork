﻿namespace AspNet.UnitOfWork.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) =>
        _context = context;

    public void Commit() =>
        _context.SaveChanges();

    public void Rollback()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
