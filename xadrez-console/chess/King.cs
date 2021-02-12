using System;
using board;

namespace chess {
    class King : Piece {

        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color) {
            this.match = match;
        }

        public override string ToString() {
            return "K";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        private bool towerToRock(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p is Tower && p.color == color && p.moves == 0;
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

            // # Special Move 
            if (moves == 0 && !match.check) {
                // Special Move -> Little Rock
                Position posLR = new Position(position.row, position.column + 3);
                if (towerToRock(posLR)) {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null) {
                        mat[position.row, position.column + 2] = true;
                    }
                }

                // Special Move -> Big Rock
                Position posBR = new Position(position.row, position.column - 4);
                if (towerToRock(posBR)) {
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null) {
                        mat[position.row, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
