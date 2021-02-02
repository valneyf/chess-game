﻿using System;
using board;

namespace chess {
    class Bishop : Piece {
        public Bishop(Board board, Color color) : base(board, color) {

        }

        public override string ToString() {
            return "B";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.columns, board.rows];

            Position pos = new Position(0, 0);

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
