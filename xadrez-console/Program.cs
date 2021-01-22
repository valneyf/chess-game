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
                ChessMatch match = new ChessMatch();


                while (!match.finished)
                {
                    try {
                        Console.Clear();
                        Display.displayBoard(match.board);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + match.turn);
                        Console.WriteLine("Waiting move: " + match.currentPlayer);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Display.readChessPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] possiblePositions = match.board.piece(origin).possibleMoves();

                        Console.Clear();
                        Display.displayBoard(match.board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destination = Display.readChessPosition().toPosition();
                        match.validateDestinationPosition(origin, destination);

                        match.performMove(origin, destination);
                    }
                    catch(BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                

            }
            catch (BoardException e)
            {   
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
