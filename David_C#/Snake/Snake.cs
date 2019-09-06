namespace Snake
{
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
}
