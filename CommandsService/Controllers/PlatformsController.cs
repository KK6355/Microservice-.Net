using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;
[ApiController]
[Route("api/c/[controller]")]
public class PlatformsController: ControllerBase
{
    public PlatformsController()
    {
        
    }
    [HttpPost]
    public ActionResult TestInboundConnection()
    {
        Console.WriteLine("--->Inbound POST # command service");
        return Ok("Inbound test of from platforms controller");
    }
}