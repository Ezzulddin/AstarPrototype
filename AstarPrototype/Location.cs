namespace AstarPrototype
{
    public struct Location
    { 
        public int X;

        public int Y;

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Location locationA, Location locationB) => locationA.Equals(locationB);

        public static bool operator !=(Location locationA, Location locationB) => !locationA.Equals(locationB);

        public override int GetHashCode() => base.GetHashCode();

        public override bool Equals(object obj) => base.Equals(obj);
    }
}
