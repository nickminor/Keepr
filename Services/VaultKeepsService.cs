using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    public VaultKeep Create(VaultKeep newVaultKeep, string userId)
    {
      newVaultKeep.UserId = userId;
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }
    public IEnumerable<VaultKeep> GetVaultKeeps(int vaultId)
    {
      return _repo.GetVaultKeeps(vaultId);
    }
    public string Delete(VaultKeep vaultKeep)
    {
      VaultKeep exists = _repo.GetVaultKeepId(vaultKeep.VaultId, vaultKeep.KeepId);
      if (exists == null) { throw new Exception("Invalid ID yo"); }
      _repo.Delete(exists.Id);
      return "Vault keep's been delorted";
    }
  }
}