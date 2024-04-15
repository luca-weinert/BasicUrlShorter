using Microsoft.AspNetCore.Mvc;

namespace BasicUrlShorter.Backend.Controllers;

public class test : ControllerBase
{
    [HttpGet("/test")]
    public IActionResult getTest()
    {
        return Redirect("https://youtube.com");
    }
}