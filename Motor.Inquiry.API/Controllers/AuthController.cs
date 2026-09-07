using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;

namespace Motor.Inquiry.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
   
    
    private readonly IAuthService _authService;






    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }








    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var response = _authService.Login(request);

        if (response is null)
        {
            return Unauthorized();
        }

        return Ok(response);
    }
}