using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(VaultKeep newVaultKeep)
    {
      string sql = @"
                INSERT INTO vaultkeeps
                (userId, vaultId, keepId)
                VALUES
                (@UserId, @VaultId, @KeepId";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }

    internal VaultKeep GetVaultKeepsByVaultId(int vaultId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE vaultId = @vaultId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId });
    }
  }
}