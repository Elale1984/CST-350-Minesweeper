using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Models
{
    //Hold state of the minsweeper tile or how many mines adjacent
    public enum MinesweeperState
    {
        Unclicked = -2,
        Flagged = -1,
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6
    }
    public class MinesweeperTileModel
    {
        public int Id { get; set; }
        public MinesweeperState State { get; set; }

        public bool IsMine { get; set; }
        public MinesweeperTileModel()
        {
        }

        public MinesweeperTileModel(int id, MinesweeperState state, bool isMine)
        {
            Id = id;
            State = state;
            IsMine = isMine;
        }
    }
}
