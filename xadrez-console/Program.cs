using System;
using board;
using chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
                        
            board.insertPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.insertPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.insertPiece(new King(board, Color.Black), new Position(2, 4));

            Display.displayBoard(board);

            Console.ReadLine();
        }
    }
}
