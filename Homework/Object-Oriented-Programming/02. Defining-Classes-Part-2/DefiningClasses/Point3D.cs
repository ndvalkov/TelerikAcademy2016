namespace DefiningClasses
{
    public struct Point3D
    {
        private static readonly Point3D origin;

        static Point3D()
        {
            origin = new Point3D(0, 0, 0);
        }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D Origin
        {
            get { return origin; }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override string ToString()
        {
            return $"{{x={X}; y={Y}; z={Z}}}";
        }
    }
}