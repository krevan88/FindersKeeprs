using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FindersKeeprs.Models;

namespace FindersKeeprs.Repositories
{
  public class KeepsRepository
  {
      private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Keep> GetAll()
    {
      string sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a on k.creatorId = a.id";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) => 
      {
        k.Creator = p;
        return k;
      }).ToList();
    }

    internal Keep GetById(int id)
    {
      string sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a on k.creatorId = a.id
      WHERE k.id = @id";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
      {
        k.Creator = p;
        return k;
      }, new {id}).FirstOrDefault();
    }

    internal List<Keep> GetKeepsByUserId(string id)
    {
      string sql = @"
      SELECT 
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a on k.creatorId = a.id
      WHERE k.creatorId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
      {
        k.Creator = p;
        return k;
      }, new { id }).ToList();
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
        (name, description, img, creatorId)
      VALUES
        (@Name, @Description, @Img, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    internal void Edit(Keep original)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description,
      img = @Img
      WHERE id = @Id";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = @"
      DELETE FROM keeps
      WHERE id = @id
      LIMIT 1";
      _db.Execute(sql, new {id});
    }
  }
}