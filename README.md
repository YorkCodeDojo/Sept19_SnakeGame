# Sept19 Snake Game


## Tips Getting Started

Try to separate the game logic from the display logic (this will make testing easier)

Write a function which draws the empty board onto the screen.

Think about the data structure you are going to use to represent the snake.  In your group come up with at least two designs.

The snake needs to be able to perform the following actions
    * Change direction
    * Move forward 1 square in the direction it is currently facing
    * Grow by one segment
    * Be able to detect when it has eaten its own tail

Adding the timer to automatically move the snake is quite complicated.  To start with you could allow the user to press bar to move the snake forward.



## Some Suggested Tests

1. "The game ends with the snake hits the edge of the screen"

    *   Given I am one square away from the top of the screen
    *   Given I am facing north
    *   When the timer ticks and I move forward
    *   Then I hit the edge of screen and lose


2. "The game ends with the snake eats itself"

    *   Given I am one square above my tail
    *   Given I am facing south
    *   When the timer ticks and I move forward
    *   Then I hit the eat part of my tail and lose

3. "The snake can change direction"

    *   Given I am facing west
    *   When I press the up arrow
    *   Then I turn to face North

4. "The snake grows longer when it eats food"

    *   Given I am one square to the left of some food
    *   Given I am facing west
    *   When the timer ticks and I move forward onto the food
    *   Then my tail grows one segment longer
    *   Then new food appears on the board in an unoccupied square



