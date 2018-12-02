using System;

namespace Matemator {

    class Challenge {

        public const char OpSum = '+';
        public const char OpSub = '-';
        public const char OpMul = 'x';
        public const char OpDiv = '/';

        public readonly int Left;
        public readonly char Operator;
        public readonly int Right;
        public readonly int Result;
        public readonly bool ShowLeft;
        public readonly bool ShowRight;
        public readonly bool ShowResult;

        public Challenge(int range, bool withDiv) {
            switch (RndGen.Next(0, withDiv ? 4 : 3)) {
                case 0:
                    Operator = OpSum;
                    Result = RndGen.Next(range / 5, range + 1);
                    Left = RndGen.Next(range / 10, Result);
                    Right = Result - Left;
                    break;
                case 1:
                    Operator = OpSub;
                    Left = RndGen.Next(range / 5, range + 1);
                    Right = RndGen.Next(1, Left);
                    Result = Left - Right;
                    break;
                case 2:
                    Operator = OpMul;
                    Result = RndGen.Next((int)Math.Sqrt(range), range + 1);
                    Left = RndGen.Next(2, (Result / 3) + 1);
                    Right = Result / Left;
                    Result = Left * Right;  // Due to rounding, the initial result may not match.
                    break;
                case 3:
                    Operator = OpDiv;
                    Left = RndGen.Next((int)Math.Sqrt(range), range + 1);
                    Result = RndGen.Next(2, (Left / 3) + 1);
                    Right = Left / Result;
                    Left = Result * Right;  // Due to rounding, the initial left op. may not match.
                    break;
            }
            switch (RndGen.Next(0, 3)) {
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

        private static readonly Random RndGen = new Random();

    }

}
