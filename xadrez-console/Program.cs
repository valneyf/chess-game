﻿using System;
using board;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Display.displayBoard(board);

            Console.ReadLine();
        }
    }
}
