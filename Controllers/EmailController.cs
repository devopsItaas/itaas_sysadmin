using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using SysAdmin_Inventario.Models;

namespace Controllers;

/// <summary>
/// Controlador para operaciones relacionadas con el envío de correos electrónicos.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly EmailService _emailService;

    /// <summary>
    /// Constructor del controlador, recibe el servicio de correo por inyección de dependencias.
    /// </summary>
    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    /// <summary>
    /// Acción que envía una notificación por correo electrónico al cliente.
    /// </summary>
    /// <returns>Resultado HTTP indicando éxito o error.</returns>
    [HttpPost("notificar-cliente")]
    public async Task<IActionResult> NotificarCliente()
    {
        await _emailService.SendEmailAsync(
            "12782@utl.com.mx", 
            "Notificacion de prueba", 
            "<b>Este es la prueba viviente que si se puede.</b>"
        );
        return Ok("Correo enviado");
    }
}