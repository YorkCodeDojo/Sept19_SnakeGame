using TestStack.BDDfy;
using Xunit;

namespace Snake.Tests
{
    [Story(AsA = "Player", IWant = "To change direction", SoThat = "I can move around the board")]
    public class CanChangeDirection
    {
        private MockBoard _board;
        private bool _result;

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }

        void GivenIAmOnTheBoard()
        {
            var snake = new Snake(3, 3);

            _board = new MockBoard(snake);
        }


        void AndGivenIAmFacingWest()
        {
            _board.TurnSnake(Direction.West);
        }

        void WhenTheUpArrowIsPressed()
        {
            _board.TurnSnake(Direction.North);
        }

        void ThenTheSnakeFacesNorth()
        {
            //         Assert.Equal(Direction.North, _board.CurrentDirection);
            Assert.False(true);
        }
    }
}
