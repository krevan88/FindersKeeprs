using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using FindersKeeprs.Models;
using FindersKeeprs.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindersKeeprs.Controllers
{
  [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly VaultsService _vs;
        private readonly KeepsService _ks;

    public ProfilesController(AccountService accountService, VaultsService vs, KeepsService ks)
    {
      _accountService = accountService;
      _ks = ks;
      _vs = vs;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
        try
        {
          Profile profile = _accountService.GetProfileById(id);
          return Ok (profile);
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetVaultsByUserId(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Vault> foundVault = _vs.GetVaultsByUserId(id, userInfo?.Id);
        return foundVault;
      }
      catch (Exception e)
        {
          return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/keeps")]
    public ActionResult<List<Keep>> GetKeepsByUserId(string id)
    {
      try
      {
        List<Keep> foundKeeps = _ks.GetKeepsByUserId(id);
        return foundKeeps;
      }
      catch (Exception e)
        {
          return BadRequest(e.Message);
        }
    }
  }
}