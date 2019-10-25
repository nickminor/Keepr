using Keepr.Models;
using Keepr.Repositories;
using System;
using System.Collections.Generic;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }
    public Vault Create(Vault newVault)
    {
      int id = _repo.Create(newVault);
      newVault.Id = id;
      return newVault;
    }
    public IEnumerable<Vault> GetVaultsByUserId(string userId)
    {
      IEnumerable<Vault> exists = _repo.GetVaultsByUserId(userId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;

    }
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _repo.GetKeepsByVaultId(vaultId, userId);
    }
    internal object GetVaultById(int id)
    {
      Vault exists = _repo.GetVaultById(id);
      if (exists == null)
      {
        throw new Exception("Invalid ID dude");
      }
      return exists;
    }

    public string Delete(int id)
    {
      Vault exists = _repo.GetVaultById(id);
      if (exists == null) { throw new Exception("Invalid ID dude"); }
      _repo.Delete(id);
      return "Vault's been delorted";
    }
  }
}