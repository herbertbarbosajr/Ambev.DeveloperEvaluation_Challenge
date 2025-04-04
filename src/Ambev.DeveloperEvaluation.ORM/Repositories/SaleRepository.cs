﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Sale in the database
    /// </summary>
    /// <param name="Sale">The Sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Sale</returns>
    public async Task<Sale> CreateAsync(Sale Sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(Sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Sale;
    }

    /// <summary>
    /// Get All Sale in the database
    /// </summary>
    /// <returns>The Sales founds</returns>
    public async Task<PaginatedList<Sale>> GetAllSales(int pageNumber, int pageSize)
    {
        var totalItems = await _context.Sales.CountAsync();
        var items = await _context.Sales
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PaginatedList<Sale>(items, totalItems, pageNumber, pageSize);
    }
    /// <summary>
    /// Retrieves a Sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sale if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a Sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the Sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Sale = await GetByIdAsync(id, cancellationToken);
        if (Sale == null)
            return false;

        _context.Sales.Remove(Sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing Sale in the database
    /// </summary>
    /// <param name="Sale">The Sale to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated Sale</returns>
    public async Task<Sale> UpdateAsync(Sale Sale, CancellationToken cancellationToken = default)
    {
        var existingSale = await GetByIdAsync(Sale.Id, cancellationToken);
        if (existingSale == null)
        {
            throw new KeyNotFoundException($"Sale with ID {Sale.Id} not found.");
        }

        _context.Entry(existingSale).CurrentValues.SetValues(Sale);
        await _context.SaveChangesAsync(cancellationToken);
        return existingSale;
    }
}
