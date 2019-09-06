namespace Snake
{
    public class Snake
    {
        public Segment Head { get; set; }
        public Segment Tail { get; set; }

        public Direction Facing { get; set; }

        public Snake(int x, int y)
        {
            Tail = new Segment() { X = x, Y = y };
            Head = Tail;
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

        public void AddNewHead(int x, int y)
        {
            var newHead = new Segment() { X = x, Y = y };
            Head.Next = newHead;
            Head = newHead;
        }
    }
}
