using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IsaleItemRepository using Entity Framework Core
/// </summary>
public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of saleItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new saleItem in the database
    /// </summary>
    /// <param name="saleItem">The saleItem to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created saleItem</returns>
    public async Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems.AddAsync(saleItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return saleItem;
    }

    /// <summary>
    /// Retrieves a saleItem by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the saleItem</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The saleItem if found, null otherwise</returns>
    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a saleItem from the database
    /// </summary>
    /// <param name="id">The unique identifier of the saleItem to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the saleItem was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var saleItem = await GetByIdAsync(id, cancellationToken);
        if (saleItem == null)
            return false;

        _context.SaleItems.Remove(saleItem);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Get All SaleItem in the database
    /// </summary>
    /// <returns>The SaleItem founds</returns>
    public async Task<PaginatedList<SaleItem>> GetAllSalesItems(int pageNumber, int pageSize)
    {
        var totalItems = await _context.SaleItems.CountAsync();
        var items = await _context.SaleItems
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PaginatedList<SaleItem>(items, totalItems, pageNumber, pageSize);
    }

    /// <summary>
    /// Updates an existing Sale in the database
    /// </summary>
    /// <param name="saleItem">The saleItem to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated Sale</returns>
    public async Task<SaleItem> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        var existingSale = await GetByIdAsync(saleItem.Id, cancellationToken);
        if (existingSale == null)
        {
            throw new KeyNotFoundException($"SaleItem with ID {saleItem.Id} not found.");
        }

        _context.Entry(existingSale).CurrentValues.SetValues(saleItem);
        await _context.SaveChangesAsync(cancellationToken);
        return existingSale;
    }
}
