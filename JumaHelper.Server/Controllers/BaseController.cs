using Microsoft.AspNetCore.Mvc;

namespace JumaHelper.Server.Controllers;

[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase;