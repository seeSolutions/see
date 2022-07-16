using Microsoft.AspNetCore.Mvc;

namespace See.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController
{
    [HttpGet("index")]
    public string Index()
    {
        return "Hello World!";
    }
}