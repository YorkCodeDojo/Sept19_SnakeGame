using System;
using System.Threading;

namespace Snake
{
    class Demo
    {
        internal void Run()
        {
            while (true)
            {
                Console.Clear();
                var snake = new Snake(3, 3);
                var food = new Food() { X = 7, Y = 7 };
                var board = new Board(DrawSnakeHead, RemoveSnakeTail, DrawFood, DrawBoard, snake, food);
                
                while (true)
                {
                    Console.SetCursorPosition(board.Width + 2, board.Height + 2);

                    Thread.Sleep(100);

                    var westScore = 0;
                    if (board.IsWall(snake.Head.X - 1, snake.Head.Y) || snake.IsSnake(snake.Head.X - 1, snake.Head.Y))
                        westScore = int.MinValue;
                    else
                        westScore = snake.Head.X - food.X;

                    var eastScore = 0;
                    if (board.IsWall(snake.Head.X + 1, snake.Head.Y) || snake.IsSnake(snake.Head.X + 1, snake.Head.Y))
                        eastScore = int.MinValue;
                    else
                        eastScore = food.X - snake.Head.X;

                    var northScore = 0;
                    if (board.IsWall(snake.Head.X, snake.Head.Y - 1) || snake.IsSnake(snake.Head.X, snake.Head.Y - 1))
                        northScore = int.MinValue;
                    else
                        northScore = snake.Head.Y - food.Y;

                    var southScore = 0;
                    if (board.IsWall(snake.Head.X, snake.Head.Y + 1) || snake.IsSnake(snake.Head.X, snake.Head.Y + 1))
                        southScore = int.MinValue;
                    else
                        southScore = food.Y - snake.Head.Y;

                    if (westScore >= eastScore && westScore >= northScore && westScore >= southScore)
                        board.TurnSnake(Direction.West);
                    else if (eastScore >= westScore && eastScore >= northScore && eastScore >= southScore)
                        board.TurnSnake(Direction.East);
                    else if (southScore >= westScore && southScore >= northScore && southScore >= eastScore)
                        board.TurnSnake(Direction.South);
                    else
                        board.TurnSnake(Direction.North);

                    if (!board.WalkSnake())
                    {
                        ShowGameOver();
                        break;
                    }
                }
            }
        }

        private static void ShowGameOver()
        {
            Console.SetCursorPosition(20, 15);
            Console.WriteLine("".PadLeft(15, '-'));
            Console.SetCursorPosition(20, 16);
            Console.WriteLine("|  Game Over  |");
            Console.SetCursorPosition(20, 17);
            Console.WriteLine("".PadLeft(15, '-'));

            Thread.Sleep(5000);
        }

        private static void DrawFood(Food food)
        {
            Console.SetCursorPosition(food.X + 1, food.Y + 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("F");
            Console.ResetColor();
        }

        private static void DrawSnakeHead(Snake snake)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snake.Head.X + 1, snake.Head.Y + 1);
            Console.Write("S");
            Console.ResetColor();
        }

        private static void RemoveSnakeTail(Snake snake)
        {
            Console.SetCursorPosition(snake.Tail.X + 1, snake.Tail.Y + 1);
            Console.Write(" ");
        }

        private static void DrawBoard(Board board)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("".PadLeft(board.Width + 2, '_'));

            var spaces = "".PadLeft(board.Width);
            for (int r = 0; r < board.Height; r++)
            {
                Console.WriteLine($"|{spaces}|");
            }

            Console.WriteLine("".PadLeft(board.Width + 2, '_'));
            Console.ResetColor();
        }
    }
}
