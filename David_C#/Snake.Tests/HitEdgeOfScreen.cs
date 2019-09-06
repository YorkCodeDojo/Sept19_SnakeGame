using TestStack.BDDfy;
using Xunit;

namespace Snake.Tests
{
    [Story(AsA = "Player", IWant = "To lose when I hit the edge of the board", SoThat = "The game will end")]
    public class HitEdgeOfScreen
    {
        private MockBoard _board;
        private bool _result;

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }

        [Given("Given I Am One Square Away From The Top Of The Screen")]
        void GivenIAmOneSquareAwayFromTheTopOfTheScreen()
        {
            var snake = new Snake(1, 0);
            _board = new MockBoard(snake);
        }


        void AndGivenIAmFacingNorth()
        {
            _board.TurnSnake(Direction.North);
        }

        void WhenTheTimerTicksAndIMoveForward()
        {
            _result = _board.WalkSnake();
        }

        void ThenIHitTheEdgeOfTheScreenAndLose()
        {
            Assert.False(_result);
        }
    }
}
