using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tic_tacToe
{
    internal class Game
    {
        private const string X = "X";
        private const string O = "O";

        private const int MatrixLength = 3;

        private readonly int[] NumberRange;


        private string CurrentPlayer { get; set; } = String.Empty;
        private string[,] GameBoard = new string[MatrixLength, MatrixLength];
        private int TurnCount = 1;

        public Game() 
        {
            CurrentPlayer = X;
            NumberRange = Enumerable.Range(0, MatrixLength).ToArray();
        }

        public void UpdateGameBoard(string buttonPosition)
        {
            var position = buttonPosition.Split(',');
            int xVal = int.Parse(position[0]);
            int yVal = int.Parse(position[1]);
            GameBoard[xVal, yVal] = CurrentPlayer;
            TurnCount++;
        }

        public int getTurnCount()
        {
            return TurnCount;
        }

        public void setNextPlayer()
        {
            CurrentPlayer = CurrentPlayer == X ? O : X;
        }

        public string getCurrentPlayer()
        {
            return CurrentPlayer;
        }

        public bool CheckWinCondition()
        {
            //Vertical
            //|
            //|
            //|
            for(int i = 0; i < MatrixLength; i++) 
            {
                if (!String.IsNullOrWhiteSpace(GameBoard[i, 0]))
                {
                    if (GameBoard[i, 0] == GameBoard[i, 1] && GameBoard[i, 0] == GameBoard[i, 2])
                    {
                        return true;
                    }
                }
            }

            //Horizontal
            //-------------
            for (int i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(GameBoard[0, i]))
                {
                    if (GameBoard[0, i] == GameBoard[1, i] && GameBoard[0, i] == GameBoard[2, i])
                    {
                        return true;
                    }
                }
            }

            
            if (!String.IsNullOrWhiteSpace(GameBoard[1, 1]))
            {
                //Diagonal
                //\
                // \
                //  \
                if (GameBoard[0, 0] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 2])
                {
                    return true;
                }

                //Anti Diagonal
                //   /
                //  /
                // /
                if (GameBoard[0, 2] == GameBoard[1, 1] && GameBoard[1, 1] == GameBoard[2, 0])
                {
                    return true;
                }

            }



            return false;
        }

        public void resetGame()
        {
            CurrentPlayer = X;
            GameBoard = new string[3, 3];
            TurnCount = 1;
        }
    }
}
