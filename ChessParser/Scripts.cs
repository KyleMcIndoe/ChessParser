namespace ChessParser {

    public static class funcs {
        public static string returnField(string s, int x) { // return one field of the fen string
            string[] fields = s.Split(" ");
            return fields[x];
        }
    }
    public static class parses {
        static char[,] fenPositions(string fenString) { // fill board with nothing but positions of pieces
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
    }
}
