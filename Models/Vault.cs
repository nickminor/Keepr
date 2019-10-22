using Keepr.Interfaces;

namespace Keepr.Models
{
  public class Vault : IVault
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string UserId { get; internal set; }
    public int Id { get; internal set; }
  }
}