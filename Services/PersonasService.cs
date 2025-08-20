using Data;
using Models;
using SysAdmin_Inventario.Models;
namespace Services;
using SysAdmin_Inventario.Models;

// Lógica de negocio/validaciones. No hace SQL directo; llama al Repository.
public class PersonasService
{
    private readonly PersonasRepository _repo;

    public PersonasService(PersonasRepository repo)
    {
        _repo = repo;
    }

    public List<PersonasModel.GetPersonas> GetAll()
        => _repo.GetAll();

    public string Insert(PersonasModel.InsertPersona model)
    {
        // Valida negocio. Cambia/añade reglas según tu caso.
        if (string.IsNullOrWhiteSpace(model.nombre))
            return "El campo 'Nombre' es obligatorio.";

        if (model.edad == default)
            return "El campo 'Edad' es obligatorio.";

        if (string.IsNullOrWhiteSpace(model.email))
            return "El campo 'Email' es obligatorio.";

        return _repo.Insert(model);
    }
}
