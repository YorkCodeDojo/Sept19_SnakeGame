using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board { Height = 28, Width = 50 };
            var snake = new Snake();
            var food = new Food() { X = 7, Y = 7 };

            DrawBoard(board);
            DrawSnakeHead(snake);
            DrawFood(food);

            while (true)
            {
                Console.SetCursorPosition(board.Width + 2, board.Height + 2);

                Thread.Sleep(500);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow) snake.Facing = Direction.West;
                    if (key.Key == ConsoleKey.RightArrow) snake.Facing = Direction.East;
                    if (key.Key == ConsoleKey.UpArrow) snake.Facing = Direction.North;
                    if (key.Key == ConsoleKey.DownArrow) snake.Facing = Direction.South;

                    while (Console.KeyAvailable)
                        Console.ReadKey(false);
                }

                if (!Walk(board, snake, food))
                {
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

        public static bool Walk(Board board, Snake snake, Food food)
        {
            var newX = snake.Head.X;
            var newY = snake.Head.Y;

            switch (snake.Facing)
            {
                case Direction.North:
                    newY--;
                    break;
                case Direction.South:
                    newY++;
                    break;
                case Direction.West:
                    newX--;
                    break;
                case Direction.East:
                    newX++;
                    break;
                default:
                    break;
            }


            if (snake.IsSnake(newX, newY) || board.IsWall(newX, newY))
            {
                Console.WriteLine("Game Over");
                return false;
            }

            var newHead = new Segment() { X = newX, Y = newY };
            snake.Head.Next = newHead;
            snake.Head = newHead;
            DrawSnakeHead(snake);

            if (newX == food.X && newY == food.Y)
            {
                MoveFood(board, food, snake);
                DrawFood(food);
            }
            else
            {
                RemoveSnakeTail(snake);
                snake.Tail = snake.Tail.Next;
            }

            return true;
        }

        internal static void MoveFood(Board board, Food food, Snake snake)
        {
            var rnd = new Random();

            var x = rnd.Next(1, board.Width);
            var y = rnd.Next(1, board.Height);

            while (snake.IsSnake(x, y))
            {
                x = rnd.Next(1, board.Width);
                y = rnd.Next(1, board.Height);
            }

            food.X = x;
            food.Y = y;
        }
    }


    enum Direction
    {
        North,
        South,
        West,
        East
    }

    class Snake
    {
        public Segment Head { get; set; }
        public Segment Tail { get; set; }

        public Direction Facing { get; set; }

        public Snake()
        {
            Tail = new Segment() { X = 5, Y = 5 };
            Tail.Next = new Segment() { X = 6, Y = 5 };
            Tail.Next.Next = new Segment() { X = 7, Y = 5 };
            Tail.Next.Next.Next = new Segment() { X = 8, Y = 5 };
            Head = Tail.Next.Next.Next;
        }

        public bool IsSnake(int x, int y)
        {
            var segment = Tail;
            if (segment.X == x && segment.Y == y) return true;

            while (segment != Head)
            {
                segment = segment.Next;
                if (segment.X == x && segment.Y == y) return true;
            }

            return false;
        }
    }

    class Segment
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Segment Next { get; set; }
    }

    class Food
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsWall(int x, int y)
        {
            if (x == -1) return true;
            if (x == Width) return true;
            if (y == -1) return true;
            if (y == Height) return true;

            return false;
        }

    }
}
