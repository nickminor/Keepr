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
    public int Create(VaultKeep vaultKeep)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (userId, vaultId, keepId)
      VALUES
      (@UserId, @VaultId, @KeepId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, vaultKeep);
    }
    public IEnumerable<VaultKeep> GetVaultKeeps(int vaultId)
    {
      string sql = "SELECT * FROM vaultkeeps";
      return _db.Query<VaultKeep>(sql);
    }
  }
}