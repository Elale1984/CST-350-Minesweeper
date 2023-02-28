using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Models
{
    public class BoardModel
    {
        private string v;
        private object id;
        private object date1;

        [Key]
        public int Id { get; set; }
        public string boardCells { get; set; }
        public int UID { get; set; }
        public string date { get; set; }
        public BoardModel(string boardCells, int UID, string date)
        {
            this.boardCells = boardCells;
            this.UID = UID;
            this.date = date;
        }
        public BoardModel(string v, string iD)
        {

        }

        public BoardModel(string v, object id, object date1)
        {
            this.v = v;
            this.id = id;
            this.date1 = date1;
        }

        public BoardModel()
        {
        }
    }
}
