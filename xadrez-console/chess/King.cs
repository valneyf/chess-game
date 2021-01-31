using System;
using board;

namespace chess {
    class King : Piece {
        public King(Board board, Color color) : base(board, color) {

        }

        public override string ToString() {
            return "K";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.columns, board.rows];

            Position pos = new Position(0, 0);

            // above
            pos.setPosition(position.row - 1, position.column);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // northeast
            pos.setPosition(position.row - 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // right
            pos.setPosition(position.row, position.column + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // southeast
            pos.setPosition(position.row + 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // below
            pos.setPosition(position.row + 1, position.column);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // southwest
            pos.setPosition(position.row + 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // left
            pos.setPosition(position.row, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // northwest
            pos.setPosition(position.row - 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}
