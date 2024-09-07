namespace ChessParserFen {

    public static class funcs {
        public static string returnField(string s, int x) { // return one field of the fen string
            string[] fields = s.Split(" ");
            return fields[x];
        }
    }
    public static class parses {
        static char[,] positions(string fenString) { // fill board with nothing but positions of pieces
            char[,] board = new char[8,8];

            string piecePositions = funcs.returnField(fenString, 0);
            string[] rows = piecePositions.Split("/");

            for(int i = 0; i < 8; i++) {
                char[] charArr = rows[i].ToCharArray(0, rows[i].Length);

                for(int j = 0; j < charArr.Length; j++) {
                    if(Char.IsDigit(charArr[j])) {
                        i += (int) charArr[j] - 48; // (int) returns the number + 48
                    } else {
                        board[i,j] = charArr[i];
                    }
                }
            }

            return board;
        }

        static char nextToMove(string fenS) {
            string field = funcs.returnField(fenS, 1);
            if(field == "w") return 'w';
            return 'b'; // not sure if you can implicitely typecast string to char  
        }

        static string[] castlingRights(string fenS) { // return an array of valid castles
            string field = funcs.returnField(fenS, 2);
            if(field == "-") return new string[0];

            string[] ans = new string[field.Length];
            char[] fieldChars = field.ToCharArray(0, field.Length);

            for(int i = 0; i < field.Length; i++) {
                char curChar = fieldChars[i];

                if(curChar == 'K') ans[i] = "WhiteKingside";
                if(curChar == 'Q') ans[i] = "WhiteQueenside";
                if(curChar == 'k') ans[i] = "BlackKingside";
                if(curChar == 'q') ans[i] = "BlackQueenside";
            }

            return ans;
        }

        static string enPassantTargets(string fenS) {
            string field = funcs.returnField(fenS, 3);
            return field;
        }

        static int halfMoveCount(string fenS) { // number of moves that arent a capture or pawn move, used to enforce 50 move draw
            string field = funcs.returnField(fenS, 4); 
            return int.Parse(field);
        }

        static int fullMoveCount(string fenS) { // number of full moves
            string field = funcs.returnField(fenS, 5);
            return int.Parse(field);
        }
    }
}
