namespace RogueLike_Remake.GameObject
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }
    public struct Position
    {
        public int _X { get; private set; }
        public int _Y { get; private set; }
        public Direction _Direction { get; private set; }
        public Position(int X, int Y)
        {
            _X = X;
            _Y = Y; 
            _Direction = Direction.None;
        }
        public Position(int X, int Y, Direction direction) 
        {
            _X = X; 
            _Y = Y;
            _Direction = direction;
        }
        public readonly Position ChangePos(Direction direction) 
        {
            switch (direction) 
            {
                case Direction.Up:
                    return new Position(_X    , _Y + 1);
                case Direction.Left:
                    return new Position(_X - 1, _Y    );
                case Direction.Right:
                    return new Position(_X + 1, _Y + 1);
                case Direction.Down:
                    return new Position(_X    , _Y - 1);
            }
            return this;
        }

    }
}
