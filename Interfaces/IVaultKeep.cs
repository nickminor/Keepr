namespace Keepr.Interfaces
{
  public interface IVaultKeep
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }

  }
}