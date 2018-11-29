using System;

namespace Matemator {

    class Challenge {

        public const char OP_SUM = '+';
        public const char OP_SUB = '-';
        public const char OP_MUL = 'x';
        public const char OP_DIV = '/';

        public readonly int Left;
        public readonly char Operator;
        public readonly int Right;
        public readonly int Result;
        public readonly bool ShowLeft;
        public readonly bool ShowRight;
        public readonly bool ShowResult;

        public Challenge(int range, bool withDiv) {

            switch (random.Next(0, withDiv ? 4 : 3)) {

                case 0:
                    Operator = OP_SUM;
                    Result = random.Next(2, range + 1);
                    Left = random.Next(1, Result);
                    Right = Result - Left;
                    break;

                case 1:
                    Operator = OP_SUB;
                    Left = random.Next(2, range + 1);
                    Right = random.Next(1, Left);
                    Result = Left - Right;
                    break;

                case 2:
                    Operator = OP_MUL;
                    Result = random.Next((int)Math.Sqrt(range), range + 1);
                    Left = random.Next(2, (Result / 2) + 1);
                    Right = Result / Left;
                    Result = Left * Right;  // Due to rounding, the initial result may not match.
                    break;

                case 3:
                    Operator = OP_DIV;
                    Left = random.Next((int)Math.Sqrt(range), range + 1);
                    Result = random.Next(2, (Left / 2) + 1);
                    Right = Left / Result;
                    Left = Result * Right;  // Due to rounding, the initial left op. may not match.
                    break;

            }

            switch (random.Next(0, 3)) {

                case 0:
                    ShowLeft = false;
                    ShowRight = true;
                    ShowResult = true;
                    break;

                case 1:
                    ShowLeft = true;
                    ShowRight = false;
                    ShowResult = true;
                    break;

                case 2:
                    ShowLeft = true;
                    ShowRight = true;
                    ShowResult = false;
                    break;
            }

        }

        public bool Check(int left, int right, int result) {
            return Left == left && Right == right && Result == result;
        }

        private static readonly Random random = new Random();

    }

}
