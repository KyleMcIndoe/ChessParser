using ChessParser;

namespace ChessBoard {
    public class board {
        char[,] positions;
        char sideToMove;
        string[] castlingAbility;
        string enpassantTarget;
        int halfMoves;
        int fullMoves;
        string startPos = fenStrings.gameStart;

        public board(string fenS) {
            if(fenS == "") fenS = startPos;

            this.positions = parses.positions(fenS);
            this.sideToMove = parses.nextToMove(fenS);
            this.castlingAbility = parses.castlingRights(fenS);
            this.enpassantTarget = parses.enPassantTargets(fenS);
            this.halfMoves = parses.halfMoveCount(fenS);
            this.fullMoves = parses.fullMoveCount(fenS);
        }
    }
}