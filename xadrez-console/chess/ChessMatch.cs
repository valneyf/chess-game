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
        public bool check { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPieces();

        }

        public Piece executeMove(Position origin, Position destination) {
            Piece piece = board.removePiece(origin);
            piece.increaseMoves();
            Piece capturedPiece = board.removePiece(destination);
            board.insertPiece(piece, destination);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMove(Position origin, Position destination, Piece capturedPiece) {
            Piece p = board.removePiece(destination);
            p.decreaseMoves();
            if (capturedPiece != null) {
                board.insertPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.insertPiece(p, origin);
        }
        
        public void performMove(Position origin, Position destination) {
            Piece capturedPiece = executeMove(origin, destination);

            if (isInCheck(currentPlayer)) {
                undoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (isInCheck(opponent(currentPlayer))) {
                check = true;
            }
            else {
                check = false;
            }

            if (CheckmateTest(opponent(currentPlayer))) {
                finished = true;
            }
            else {
                turn++;
                changePlayer();
            }
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
            if (!board.piece(origin).possibleMovement(destination)) {
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
            foreach (Piece x in pieces) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color opponent(Color color) {
            if (color == Color.White) {
                return Color.Black;
            }
            else {
                return Color.White;
            }
        }

        private Piece king(Color color) {
            foreach (Piece x in piecesInGame(color)) {
                if (x is King) {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color) {
            Piece K = king(color);
            if (K == null) {
                throw new BoardException("There is no king with color " + color + " in the board!");
            }

            foreach (Piece x in piecesInGame(opponent(color))) {
                bool[,] mat = x.possibleMoves();
                if (mat[K.position.row, K.position.column]) {
                    return true;
                }
            }
            return false;
        }

        public bool CheckmateTest(Color color) {
            if (!isInCheck(color)) {
                return false;
            }
            foreach (Piece x in piecesInGame(color)) {
                bool[,] mat = x.possibleMoves();
                for (int i = 0; i < board.rows; i++) {
                    for (int j = 0; j < board.columns; j++) {
                        if (mat[i,j]) {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = executeMove(origin, destination);
                            bool checkTest = isInCheck(color);
                            undoMove(origin, destination, capturedPiece);
                            if (!checkTest) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void insertNewPiece(char column, int row, Piece piece) {
            board.insertPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void insertPieces() {
            insertNewPiece('a', 1, new Tower(board, Color.White));            
            insertNewPiece('b', 1, new Horse(board, Color.White));
            insertNewPiece('c', 1, new Bishop(board, Color.White));
            insertNewPiece('d', 1, new Queen(board, Color.White));
            insertNewPiece('e', 1, new King(board, Color.White));
            insertNewPiece('f', 1, new Bishop(board, Color.White));
            insertNewPiece('g', 1, new Horse(board, Color.White));
            insertNewPiece('h', 1, new Tower(board, Color.White));
            insertNewPiece('a', 2, new Pawn(board, Color.White));
            insertNewPiece('b', 2, new Pawn(board, Color.White));
            insertNewPiece('c', 2, new Pawn(board, Color.White));
            insertNewPiece('d', 2, new Pawn(board, Color.White));
            insertNewPiece('e', 2, new Pawn(board, Color.White));
            insertNewPiece('f', 2, new Pawn(board, Color.White));
            insertNewPiece('g', 2, new Pawn(board, Color.White));
            insertNewPiece('h', 2, new Pawn(board, Color.White));
            
            insertNewPiece('a', 8, new Tower(board, Color.Black));            
            insertNewPiece('b', 8, new Horse(board, Color.Black));
            insertNewPiece('c', 8, new Bishop(board, Color.Black));
            insertNewPiece('d', 8, new Queen(board, Color.Black));
            insertNewPiece('e', 8, new King(board, Color.Black));
            insertNewPiece('f', 8, new Bishop(board, Color.Black));
            insertNewPiece('g', 8, new Horse(board, Color.Black));
            insertNewPiece('h', 8, new Tower(board, Color.Black));
            insertNewPiece('a', 7, new Pawn(board, Color.Black));
            insertNewPiece('b', 7, new Pawn(board, Color.Black));
            insertNewPiece('c', 7, new Pawn(board, Color.Black));
            insertNewPiece('d', 7, new Pawn(board, Color.Black));
            insertNewPiece('e', 7, new Pawn(board, Color.Black));
            insertNewPiece('f', 7, new Pawn(board, Color.Black));
            insertNewPiece('g', 7, new Pawn(board, Color.Black));
            insertNewPiece('h', 7, new Pawn(board, Color.Black));
                                    
        }
    }
}
