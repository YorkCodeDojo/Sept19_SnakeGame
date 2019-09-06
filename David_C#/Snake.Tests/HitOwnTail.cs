using TestStack.BDDfy;
using Xunit;

namespace Snake.Tests
{
    [Story(AsA = "Player", IWant = "To lose when I eat my own tail", SoThat = "The game will end")]
    public class HitOwnTail
    {
        private MockBoard _board;
        private bool _result;

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }

        void GivenIAmOneSquareAboveMyTail()
        {
            var snake = new Snake(1, 2);
            snake.AddNewHead(2, 2);
            snake.AddNewHead(2, 1);
            snake.AddNewHead(1, 1);

            _board = new MockBoard(snake);
        }


        void AndGivenIAmFacingSouth()
        {
            _board.TurnSnake(Direction.South);
        }

        void WhenTheTimerTicksAndIMoveForward()
        {
            _result = _board.WalkSnake();
        }

        void ThenIEatMyTailAndLose()
        {
            Assert.False(_result);
        }
    }
}
