using System;
using board;

namespace chess {
    class Queen : Piece {
        public Queen(Board board, Color color) : base(board, color) {

        }

        public override string ToString() {
            return "Q";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.columns, board.rows];

            Position pos = new Position(0, 0);

            // left
            pos.setPosition(position.row, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.setPosition(pos.row, pos.column - 1);
            }

            // right
            pos.setPosition(position.row, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.setPosition(pos.row, pos.column + 1);
            }

            // above
            pos.setPosition(position.row - 1, position.column);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.setPosition(pos.row - 1, pos.column);
            }

            // below
            pos.setPosition(position.row + 1, position.column);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.setPosition(pos.row + 1, pos.column);
            }

            // northwest
            pos.setPosition(position.row - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.setPosition(pos.row - 1, pos.column - 1);
            }

            // northeast
            pos.setPosition(position.row - 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.setPosition(pos.row - 1, pos.column + 1);
            }

            // southeast
            pos.setPosition(position.row + 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.setPosition(pos.row + 1, pos.column + 1);
            }

            // southwest
            pos.setPosition(position.row + 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.setPosition(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
