using System;
using board;

namespace xadrez_console
{
    class Display
    {
        public static void displayBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    Console.Write(board.piece(i,j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
