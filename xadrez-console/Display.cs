using System;
using board;
using chess;

namespace xadrez_console {
    class Display {
        public static void displayBoard(Board board) {
            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    pieceImpress(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void displayBoard(Board board, bool[,] possiblePositions) {

            ConsoleColor standardBackground = Console.BackgroundColor;
            ConsoleColor alteredBackgound = ConsoleColor.DarkGray;
            
            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    if (possiblePositions[i,j]) {
                        Console.BackgroundColor = alteredBackgound;
                    }
                    else {
                        Console.BackgroundColor = standardBackground;
                    }
                    pieceImpress(board.piece(i, j));
                    Console.BackgroundColor = standardBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = standardBackground;
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);
        }

        public static void pieceImpress(Piece piece) {
            if (piece == null) {
                Console.Write("- ");
            }
            else {
                if (piece.color == Color.White) {
                    Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
