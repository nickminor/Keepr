using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vault> Get()
    {
      string sql = "SELECT * FROM Vaults";
      return _db.Query<Vault>(sql);
    }

    public Vault GetVaultById(int id)
    {
      string sql = "SELECT * FROM Vaults WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }
    public int Create(Vault newVault)
    {
      string sql = @"
                INSERT INTO Vaults
                (name, description, userId)
                VALUES
                (@Name,@Description, @UserId);
                SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    public IEnumerable<Vault> GetVaultsByUserId(string userId)
    {
      string sql = "SELECT * FROM Vaults WHERE userId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM Vaults WHERE id = @Id";
      _db.Execute(sql, new { id });
    }
  }
}