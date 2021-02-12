using board;

namespace chess {
    class Pawn : Piece {
        public Pawn(Board board, Color color) : base(board, color) {

        }

        public override string ToString() {
            return "P";
        }

        private bool thereIsEnemy(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }
        private bool free(Position pos) {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White) {
                pos.setPosition(position.row - 1, position.column);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.row, pos.column] = true;
                }

                pos.setPosition(position.row - 2, position.column);
                Position p2 = new Position(position.row - 1, position.column);
                if (board.validPosition(p2) && free(p2) && board.validPosition(pos) && free(pos) && moves == 0) {
                    mat[pos.row, pos.column] = true;
                }

                pos.setPosition(position.row - 1, position.column - 1);
                if (board.validPosition(pos) && thereIsEnemy(pos)) {
                    mat[pos.row, pos.column] = true;
                }

                pos.setPosition(position.row - 1, position.column + 1);
                if (board.validPosition(pos) && thereIsEnemy(pos)) {
                    mat[pos.row, pos.column] = true;
                }
            }
            else {
                pos.setPosition(position.row + 1, position.column);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.row, pos.column] = true;
                }

                pos.setPosition(position.row + 2, position.column);
                Position p2 = new Position(position.row + 1, position.column);
                if (board.validPosition(p2) && free(p2) && board.validPosition(pos) && free(pos) && moves == 0) {
                    mat[pos.row, pos.column] = true;
                }

                pos.setPosition(position.row + 1, position.column - 1);
                if (board.validPosition(pos) && thereIsEnemy(pos)) {
                    mat[pos.row, pos.column] = true;
                }

                pos.setPosition(position.row + 1, position.column + 1);
                if (board.validPosition(pos) && thereIsEnemy(pos)) {
                    mat[pos.row, pos.column] = true;
                }
            }

            return mat;
        }
    }
}
