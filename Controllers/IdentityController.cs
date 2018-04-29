using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.AccessTokenValidation;

[Route ("api/identity")]
[ApiController]

[Authorize (AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
public class IdentityController : ControllerBase {
    [HttpGet]
    public IActionResult Get () {
        return new JsonResult (User.Claims.Select (c => new { c.Type, c.Value }));
    }
}