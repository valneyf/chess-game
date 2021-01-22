using System;
using board;

namespace chess {
    class ChessMatch {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            insertPieces();
        }

        public void executeMove(Position origin, Position destination) {
            Piece piece = board.removePiece(origin);
            piece.increaseMoves();
            Piece capturePiece = board.removePiece(destination);
            board.insertPiece(piece, destination);
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

        private void insertPieces() {
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.insertPiece(new Tower(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.insertPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.insertPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
