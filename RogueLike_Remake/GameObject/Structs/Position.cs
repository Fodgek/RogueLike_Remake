namespace RogueLike_Remake.GameObject.Structs
{
    public struct Position
    {
        public int _X { get; private set; }
        public int _Y { get; private set; }
        public Direction _Direction { get; private set; }
        private Random random = new Random();
        private int rand; 

        public Position(int X, int Y)
        {
            _X = X;
            _Y = Y;
            _Direction = RandDirect();
        }
        public Position(int X, int Y, Direction direction)
        {
            _X = X;
            _Y = Y;
            _Direction = direction;
        }

        private Direction RandDirect()
        {
            rand = random.Next(3);
            Direction direct = new Direction();
            switch (rand) 
            {
                case 0: direct = Direction.Up; break;
                case 1: direct = Direction.Down; break;
                case 2: direct = Direction.Left; break;
                case 3: direct = Direction.Right; break;
            }
            return direct;
        }
        public static bool operator ==(Position a, Position b) => a._X == b._X && a._Y == b._Y;
        public static bool operator !=(Position a, Position b) => !(a == b);
        public override readonly bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj is Position p)
                return _X == p._X && _Y == p._Y;

            return false;
        }
        public override readonly int GetHashCode() => HashCode.Combine(_X, _Y);
        public Position ChangePos(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Position(_X    , _Y - 1, direction);
                case Direction.Left:
                    return new Position(_X - 1, _Y    , direction);
                case Direction.Right:
                    return new Position(_X + 1, _Y    , direction);
                case Direction.Down:
                    return new Position(_X    , _Y + 1, direction);
            }
            return this;
        }
        public Position[] GetPosArrFromDirect(Direction direction, int poscount) 
        {
            Position[] positions = new Position[poscount];
            for (int i = 0; i < poscount; i++)
            {
                switch (direction)
                {
                    case Direction.Up:
                        positions[i] = new Position(_X          , _Y - (i + 1), direction);
                        break;
                    case Direction.Left:
                        positions[i] = new Position(_X - (i + 1), _Y          , direction);
                        break;
                    case Direction.Right:
                        positions[i] = new Position(_X + (i + 1), _Y          , direction);
                        break;
                    case Direction.Down:
                        positions[i] = new Position(_X          , _Y + (i + 1), direction);
                        break;
                }
            }
            return positions;
        }
    }
}
