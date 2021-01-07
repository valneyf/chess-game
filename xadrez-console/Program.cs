using System;
using board;
using chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.insertPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.insertPiece(new Tower(board, Color.Black), new Position(1, 9));
                board.insertPiece(new King(board, Color.Black), new Position(0, 2));

                Display.displayBoard(board);

            }
            catch (BoardException e)
            {   
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
