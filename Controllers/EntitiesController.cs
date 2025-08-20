using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using SysAdmin_Inventario.Models;

namespace Controllers;

// Controlador HTTP. Ajusta el nombre de clase/ruta según tu recurso.
[ApiController]
[Route("api/[controller]")]
public class EntitiesController : ControllerBase
{
    private readonly EntityService _service;

    public EntitiesController(EntityService service)
    {
        _service = service;
    }

    // GET: api/entities
    [HttpGet]
    public ActionResult<IEnumerable<EntityModels.GetEntityModel>> Get()
        => Ok(_service.GetAll());

    // POST: api/entities
    [HttpPost]
    public ActionResult<string> Post([FromBody] EntityModels.InsertEntityModel model)
    {
        var result = _service.Insert(model);
        // Ajusta códigos de estado según convenga (Created/BadRequest/etc.)
        return Ok(result);
    }
}
