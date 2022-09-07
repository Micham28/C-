//Charles Costarella, TINFO 200B, Programing II for ITS
//L5life assignment - John Conway's Game of Life Program.
//The Game of Life is a computational phenomenon invented
//by British mathematician John Conway circa 1970 to show
//possibilities of population simulations in a mathematically controlled environment.
//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
/////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-25    Michael         Strart project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLife
{//(needs comment)
    internal class Program
    {//(needs comment)
        static void Main(string[] args)
        { 
            //want to be able to create a game obj and call the ctor
            //to kick off the simulation
            Game game = new Game();
            game.PlayTheGame();

        }
    }
}
