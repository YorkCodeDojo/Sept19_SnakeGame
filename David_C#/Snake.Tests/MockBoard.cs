namespace Snake.Tests
{
    public class MockBoard
    {
        private Board _board;

        public MockBoard(Snake snake)
        {
            var food = new Food() { X = 7, Y = 7 };
            _board = new Board(DrawSnakeHead, RemoveSnakeTail, DrawFood, DrawBoard, snake, food);
        }

        private void DrawBoard(Board obj)
        {
        }

        private void DrawFood(Food obj)
        {
        }

        private void RemoveSnakeTail(Snake obj)
        {
        }

        private void DrawSnakeHead(Snake obj)
        {
        }

        internal void TurnSnake(Direction direction) => _board.TurnSnake(direction);

        internal bool WalkSnake() => _board.WalkSnake();
    }
}
