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
    public VaultKeep GetVaultKeepId(int vaultId, int keepId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE vaultId =@VaultId AND keepId = @KeepId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId });
    }
    public void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @Id";
      _db.Execute(sql, new { id });
    }
  }
}