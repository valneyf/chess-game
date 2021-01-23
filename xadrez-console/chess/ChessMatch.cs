using System.Collections.Generic;
using board;

namespace chess {
    class ChessMatch {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPieces();

        }

        public void executeMove(Position origin, Position destination) {
            Piece piece = board.removePiece(origin);
            piece.increaseMoves();
            Piece capturedPiece = board.removePiece(destination);
            board.insertPiece(piece, destination);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }
        }

        public void performMove(Position origin, Position destination) {
            executeMove(origin, destination);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos) {
            if (board.piece(pos) == null) {
                throw new BoardException("There is no piece in the chosen origin position!");
            }
            if (currentPlayer != board.piece(pos).color) {
                throw new BoardException("The piece of chosen origin is not yours!");
            }
            if (!board.piece(pos).checkPossibleMoves()) {
                throw new BoardException("No movements possible for the selected origin piece!");
            }
        }

        public void validateDestinationPosition(Position origin, Position destination) {
            if (!board.piece(origin).canMoveTo(destination)) {
                throw new BoardException("Invalid destination position!");
            }
        }

        private void changePlayer() {
            if (currentPlayer == Color.White) {
                currentPlayer = Color.Black;
            }
            else {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }



        public void insertNewPiece(char column, int row, Piece piece) {
            board.insertPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void insertPieces() {
            insertNewPiece('c', 1, new Tower(board, Color.White));
            insertNewPiece('c', 2, new Tower(board, Color.White));
            insertNewPiece('d', 2, new Tower(board, Color.White));
            insertNewPiece('e', 2, new Tower(board, Color.White));
            insertNewPiece('e', 1, new Tower(board, Color.White));
            insertNewPiece('d', 1, new King(board, Color.White));

            insertNewPiece('c', 7, new Tower(board, Color.Black));
            insertNewPiece('c', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 7, new Tower(board, Color.Black));
            insertNewPiece('e', 7, new Tower(board, Color.Black));
            insertNewPiece('e', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
