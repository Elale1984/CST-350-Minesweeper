using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Controllers
{
    public class MinesweeperBoardController : Controller
    {
        static List<MinesweeperTileModel> board { get; set; }
        public IActionResult Index()
        {
            board = new List<MinesweeperTileModel>();
            board.Add(new MinesweeperTileModel(0, MinesweeperState.Unclicked, new Random().NextDouble() > 0.9));
            board.Add(new MinesweeperTileModel(1, MinesweeperState.Unclicked, new Random().NextDouble() > 0.9));
            board.Add(new MinesweeperTileModel(2, MinesweeperState.Unclicked, new Random().NextDouble() > 0.9));
            board.Add(new MinesweeperTileModel(3, MinesweeperState.Unclicked, new Random().NextDouble() > 0.9));
            return View("Index", board);
        }
        //-2 - No Flag
        //-1 - Flag
        //0...max - number of mines (display number)
        public ActionResult Flag(int i)
        {

            Console.WriteLine(i);
            Console.WriteLine(board.Count + "Count");
            if (board.ElementAt(i).State == MinesweeperState.Unclicked) board.ElementAt(i).State = MinesweeperState.Flagged;
            if (board.ElementAt(i).State == MinesweeperState.Flagged) board.ElementAt(i).State = MinesweeperState.Unclicked;

            return View("Index", board);
        }
        public ActionResult Click(int i)
        {
           
            if (board.ElementAt(i).IsMine == true) terminateGame();
            if (board.ElementAt(i).State == MinesweeperState.Unclicked) putNumsOnBoard(board, i);

            return View("Index", board);
        }
        //@TODO - Implement game logic for calculating and display numbers and also potentially move to a service class.  Params current board and index of tile pressed [note by Josh]
        private bool putNumsOnBoard(List<MinesweeperTileModel> board, int i)
        {
            //logic

            return true; /*returning true temp*/
        }
        //@TODO - Terminate game [note by Josh]
        private void terminateGame()
        {

        }
    }
}
