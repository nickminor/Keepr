namespace Keepr.Interfaces
{
  public interface IKeep
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public bool isPrivate { get; set; }
  }
}