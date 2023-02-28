using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Models
{
    public class CellModel
    {
        
        public int ID { get; set; }
        public int State { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }
        public int Neighbors { get; set; }

        public bool Visited { get; set; }

        public bool Flagged { get; set; }
        public CellModel ()
        {
        }

        public CellModel (int id, int state, int row, int col)
        {
            ID = id;
            State = state;
            Row = row;
            Col = col;
        }
    }
}
