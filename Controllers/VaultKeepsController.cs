using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.Create(vaultKeep, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<VaultKeep>> GetVaultKeeps(int vaultId)
    {
      try
      {
        return Ok(_vks.GetVaultKeeps(vaultId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut]
    public ActionResult<VaultKeep> Delete([FromBody] VaultKeep vaultKeep)
    {
      try
      {
        return Ok(_vks.Delete(vaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}