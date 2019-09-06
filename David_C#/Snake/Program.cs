using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            var snake = new Snake(3, 3);
            var board = new Board(DrawSnakeHead, RemoveSnakeTail, DrawFood, DrawBoard, snake);

            while (true)
            {
                Console.SetCursorPosition(board.Width + 2, board.Height + 2);

                Thread.Sleep(500);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow) board.TurnSnake(Direction.West);
                    if (key.Key == ConsoleKey.RightArrow) board.TurnSnake(Direction.East);
                    if (key.Key == ConsoleKey.UpArrow) board.TurnSnake(Direction.North);
                    if (key.Key == ConsoleKey.DownArrow) board.TurnSnake(Direction.South);

                    while (Console.KeyAvailable)
                        Console.ReadKey(false);
                }

                if (!board.WalkSnake())
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }
        }

        private static void DrawFood(Food food)
        {
            Console.SetCursorPosition(food.X + 1, food.Y + 1);
            Console.Write("F");
        }

        private static void DrawSnakeHead(Snake snake)
        {
            Console.SetCursorPosition(snake.Head.X + 1, snake.Head.Y + 1);
            Console.Write("S");
        }

        private static void RemoveSnakeTail(Snake snake)
        {
            Console.SetCursorPosition(snake.Tail.X + 1, snake.Tail.Y + 1);
            Console.Write(" ");
        }

        private static void DrawBoard(Board board)
        {
            Console.Clear();

            Console.WriteLine("".PadLeft(board.Width + 2, '_'));

            var spaces = "".PadLeft(board.Width);
            for (int r = 0; r < board.Height; r++)
            {
                Console.WriteLine($"|{spaces}|");
            }

            Console.WriteLine("".PadLeft(board.Width + 2, '_'));
        }

    }
}
