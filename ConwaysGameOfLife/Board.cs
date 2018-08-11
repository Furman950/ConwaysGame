using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class Board
    {
        static Cell[,] cellBoard;

        public static Cell[,] CellBoard { get => cellBoard; set => cellBoard = value; }

    }
}
