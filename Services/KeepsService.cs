using Keepr.Models;
using Keepr.Repositories;
using System;
using System.Collections.Generic;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    public Keep Create(Keep newKeep)
    {
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    public Keep Edit(Keep editKeep)
    {
      Keep keep = _repo.GetKeepById(editKeep.Id);
      if (keep == null) { throw new Exception("Invalid ID dude"); }
      keep.Name = editKeep.Name;
      keep.Description = editKeep.Description;
      keep.Img = editKeep.Img;
      keep.isPrivate = editKeep.isPrivate;
      keep.UserId = editKeep.UserId;
      _repo.Edit(keep);
      return keep;
    }

    public IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      IEnumerable<Keep> exists = _repo.GetKeepsByUserId(userId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;

    }

    public string Delete(int id, string userId)
    {
      Keep exists = _repo.GetKeepById(id);
      if (exists == null || userId != exists.UserId) { throw new Exception("Invalid ID dude"); }
      _repo.Delete(id);
      return "Keep's been delorted";
    }

    internal object GetKeepById(int id)
    {
      Keep exists = _repo.GetKeepById(id);
      if (exists == null)
      {
        throw new Exception("Invalid ID dude");
      }
      return exists;
    }
  }
}