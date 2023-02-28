using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Milestone.Controllers
{
    [ApiController]
    [Route("api")]
    public class GameBoardAPI : ControllerBase
    {
        static List<BoardModel> DBObjects = new List<BoardModel>();
        [HttpGet("showSavedGames")]
        public ActionResult<IEnumerable<BoardModel>> Index()
        {
            return DBObjects;
        }
        [HttpGet("showSavedGame/{id}")]
        public ActionResult<BoardModel> SavedGames(int id)
        {
            if (DBObjects.Count > id)
            {
                return DBObjects.ElementAt(id);
            } else
            {
                return new BoardModel();
            }
        }

        [HttpGet("deleteOneGame/{id}")]
        public ActionResult<bool> DeleteGame(int id)
        {
            if (DBObjects.Count >= id && id > 0)
            {
                DBObjects.RemoveAt(id - 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("addOneGame/{board}")]
        public ActionResult<bool> AddGame(string board)
        {
            BoardModel model = JsonSerializer.Deserialize<BoardModel>(board);
            DBObjects.Add(model);
            return true;
        }

    }
}
