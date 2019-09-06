using System;

namespace Snake
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }

        private readonly Snake _snake;
        private readonly Food _food;

        private readonly Action<Snake> _drawSnakeHead;
        private readonly Action<Snake> _removeSnakeTail;
        private readonly Action<Food> _drawFood;


        public Board(Action<Snake> drawSnakeHead, Action<Snake> removeSnakeTail, Action<Food> drawFood, Action<Board> drawBoard, Snake snake)
        {
            Height = 28;
            Width = 50;

            _snake = snake;
            _food = new Food() { X = 7, Y = 7 };

            drawBoard(this);
            drawSnakeHead(_snake);
            drawFood(_food);

            _drawSnakeHead = drawSnakeHead;
            _removeSnakeTail = removeSnakeTail;
            _drawFood = drawFood;
        }

        public void TurnSnake(Direction direction)
        {
            _snake.Facing = direction;
        }


        public bool IsWall(int x, int y)
        {
            if (x == -1) return true;
            if (x == Width) return true;
            if (y == -1) return true;
            if (y == Height) return true;

            return false;
        }

        internal void MoveFood()
        {
            var rnd = new Random();

            var x = rnd.Next(1, Width);
            var y = rnd.Next(1, Height);

            while (_snake.IsSnake(x, y))
            {
                x = rnd.Next(1, Width);
                y = rnd.Next(1, Height);
            }

            _food.X = x;
            _food.Y = y;
        }

        public bool WalkSnake()
        {
            var newX = _snake.Head.X;
            var newY = _snake.Head.Y;

            switch (_snake.Facing)
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


            if (_snake.IsSnake(newX, newY) || IsWall(newX, newY))
            {
                return false;
            }

            _snake.AddNewHead(newX, newY);
            _drawSnakeHead(_snake);

            if (newX == _food.X && newY == _food.Y)
            {
                MoveFood();
                _drawFood(_food);
            }
            else
            {
                _removeSnakeTail(_snake);
                _snake.Tail = _snake.Tail.Next;
            }

            return true;
        }
    }
}
