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
  }
}