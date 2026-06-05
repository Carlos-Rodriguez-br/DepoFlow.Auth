using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Domain.Permissions.ObjectValues;

namespace DepoFlow.Auth.Domain.Permissions;

public sealed class Modules : Entity<ModuleId>
{
    private Modules()
    {
    }
    private Modules(ModuleId id,ModuleId? parendModule, string? name, string? route, string? icon, int? order, bool? isVisibleInMenu, bool? isActive, DateTime? createdAt, DateTime? updatedAt) : base(id)
    {
        ParendModule = parendModule;
        Name = name;
        Route = route;
        Icon = icon;
        Order = order;
        IsVisibleInMenu = isVisibleInMenu;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public ModuleId? ParendModule { get; private set; }
    public string? Name { get; private set; }
    public string? Route { get; private set; }
    public string? Icon { get; private set; }
    public int? Order { get; private set; }
    public bool? IsVisibleInMenu { get; private set; }
    public bool? IsActive { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public static Modules Create(ModuleId? parendModule, string name, string route, string? icon, int order, bool isVisibleInMenu, DateTime? createdAt)
    {
        return new Modules(
            ModuleId.New(),
            parendModule, 
            name, 
            route, 
            icon, 
            order, 
            isVisibleInMenu, 
            true, 
            createdAt, 
            createdAt
        );
    }

}