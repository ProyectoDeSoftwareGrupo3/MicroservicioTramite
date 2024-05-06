using Application.Interfaces.ICurrentUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TramiteRepository.Controllers;

[Authorize]
public class AuthController : Controller
{
    
    [HttpGet("me")]
    public IActionResult Me([FromServices] ICurrentUserService currentUser)
    {
        return Ok(new
        {
            currentUser.User,
            IsAdmin = currentUser.IsInRole("Administrador")
        });
    }
}
