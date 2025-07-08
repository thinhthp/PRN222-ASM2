// Controllers/AccountController.cs
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using zQuitSmoking.Services.ThinhTHP;

[Route("[controller]/[action]")]
public class AccountController : Controller
{
    private readonly IServiceProviders _serviceProviders;

    public AccountController(IServiceProviders serviceProviders)
    {
        _serviceProviders = serviceProviders;
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        // Validate user here (pseudo-code)
        var user = await _serviceProviders.SystemUserAccountService.GetUserAccountAsync(username, password);
        if (user == null)
            return Redirect("/login?error=1");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, user.RoleId.ToString())
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return Redirect("/"); // or wherever you want
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/login");
    }
}
