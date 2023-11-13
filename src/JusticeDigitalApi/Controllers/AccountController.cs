using JusticeDigitalApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JusticeDigitalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IPasswordService _passwordService;

    public AccountController(IPasswordService passwordService)
	{
        _passwordService = passwordService;
    }

    [HttpPost("ValidatePassword")]
    public IActionResult ValidatePassword(string password)
    {
        var isValid = _passwordService.ValidatePassword(password);

        return Ok(isValid);
    }
}
