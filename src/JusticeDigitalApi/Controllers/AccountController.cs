using JusticeDigitalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JusticeDigitalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly PasswordService _passwordService;

    public AccountController()
	{
        _passwordService = new PasswordService();
    }

    [HttpPost("ValidatePassword")]
    public IActionResult ValidatePassword(string password)
    {
        var isValid = _passwordService.ValidatePassword(password);

        if(!isValid)
            return BadRequest("Validation failed.");

        return Ok("Password is valid");
    }
}
