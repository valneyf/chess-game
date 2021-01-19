﻿namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moves { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.moves = 0;
        }

        public void increaseMoves() {
            moves++;
        }


        public abstract bool[,] possibleMoves();
    }
}
