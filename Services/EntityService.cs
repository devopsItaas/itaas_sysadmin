using Data;
using Models;
using SysAdmin_Inventario.Models;
namespace Services;
using SysAdmin_Inventario.Models;

// Lógica de negocio/validaciones. No hace SQL directo; llama al Repository.
public class EntityService
{
    private readonly EntityRepository _repo;

    public EntityService(EntityRepository repo)
    {
        _repo = repo;
    }

    public List<EntityModels.GetEntityModel> GetAll()
        => _repo.GetAll();

    public string Insert(EntityModels.InsertEntityModel model)
    {
        // Valida negocio. Cambia/añade reglas según tu caso.
        if (string.IsNullOrWhiteSpace(model.Nombre))
            return "El campo 'Nombre' es obligatorio.";

        if (model.Fecha == default)
            return "El campo 'Fecha' es obligatorio.";

        return _repo.Insert(model);
    }
}
