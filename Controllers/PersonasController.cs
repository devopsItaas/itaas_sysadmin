using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using SysAdmin_Inventario.Models;

namespace Controllers;

// Controlador HTTP. Ajusta el nombre de clase/ruta según tu recurso.
[ApiController]
[Route("api/[controller]")]
public class PersonasController : ControllerBase
{
    private readonly PersonasService _service;

    public PersonasController(PersonasService service)
    {
        _service = service;
    }

    // GET: api/personas
    [HttpGet]
    public ActionResult<IEnumerable<PersonasModel.GetPersonas>> Get()
        => Ok(_service.GetAll());

    // POST: api/personas
    [HttpPost]
    public ActionResult<string> Post([FromBody] PersonasModel.InsertPersona model)
    {
        var result = _service.Insert(model);
        // Ajusta códigos de estado según convenga (Created/BadRequest/etc.)
        return Ok(result);
    }
}
