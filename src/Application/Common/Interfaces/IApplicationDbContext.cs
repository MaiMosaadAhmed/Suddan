using Microsoft.EntityFrameworkCore;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<SuddanApplication.Domain.Entities.Driver> Drivers { get; }
    DbSet<car> Cars { get; }
    DbSet<OwnerCar> OwnerCars { get; }  
    DbSet<SuddanApplication.Domain.Entities.Officers> Officers { get; }
    DbSet<SuddanApplication.Domain.Entities.Nodes> Nodes { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
