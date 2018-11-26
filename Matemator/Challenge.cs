using System;

namespace Matemator {
    class Challenge {
        public const char OP_SUM = '+';
        public const char OP_SUB = '-';
        public const char OP_MUL = 'x';
        public const char OP_DIV = '/';

        public Challenge(int range, Random r) {
            //Random r = new Random();
            switch (r.Next(0, 4)) {
                case 0: {
                    Operator = OP_SUM;
                    Result = r.Next(2, range + 1);
                    Left = r.Next(1, Result);
                    Right = Result - Left;
                    break;
                }
                case 1: {
                    Operator = OP_SUB;
                    Left = r.Next(2, range + 1);
                    Right = r.Next(1, Left);
                    Result = Left - Right;
                    break;
                }
                case 2: {
                    Operator = OP_MUL;
                    Result = r.Next((int)Math.Sqrt(range), range + 1);
                    Left = r.Next(2, (Result / 2) + 1);
                    Right = Result / Left;
                    Result = Left * Right;  // Due to rounding, the initial result may not match.
                    break;
                }
                case 3: {
                    Operator = OP_DIV;
                    Left = r.Next((int)Math.Sqrt(range), range + 1);
                    Result = r.Next(2, (Left / 2) + 1);
                    Right = Left / Result;
                    Left = Result * Right;  // Due to rounding, the initial left op. may not match.
                    break;
                }
            }
        }

        public String DebugString() {
            return "" + Left + Operator + Right + " = " + Result;
        }

        private readonly int Left;
        private readonly char Operator;
        private readonly int Right;
        private readonly int Result;
    }
}
