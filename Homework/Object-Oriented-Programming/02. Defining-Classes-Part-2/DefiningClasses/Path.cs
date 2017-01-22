using System;
using System.Collections.Generic;
using System.IO;

namespace DefiningClasses
{
    class Path
    {
        private Stack<Point3D> pointSequence;

        public Path()
        {
        }

        public Path(IEnumerable<Point3D> pointSequence) : this()
        {
            SimpleValidator.CheckNull(pointSequence, "Point sequence");
            this.pointSequence = new Stack<Point3D>(pointSequence);
        }

        public Stack<Point3D> PointSequence
        {
            get { return pointSequence; }
            set { pointSequence = value; }
        }

        public void AddPoint(Point3D point)
        {
            SimpleValidator.CheckNull(point, "Point");
            pointSequence.Push(point);
        }

        public void RemovePoint()
        {
            if (pointSequence.Count > 0)
            {
                pointSequence.Pop();
            }
        }

        public override string ToString()
        {
            return "Path: " + Environment.NewLine + string.Join(Environment.NewLine, pointSequence);
        }

        public static class PathStorage
        {
            private const string PathTerminator = "END";
            private static readonly string StorageDir;

            static PathStorage()
            {
                StorageDir = "Storage";

                if (!Directory.Exists(StorageDir))
                {
                    Directory.CreateDirectory(StorageDir);
                }
            }

            public static void SavePath(IEnumerable<Point3D> path, string fileName)
            {
                using (StreamWriter sw = new StreamWriter(StorageDir + "\\" + fileName))
                {
                    foreach (var point3D in path)
                    {
                        sw.WriteLine(point3D.X + " " + point3D.Y + " " + point3D.Z);
                    }

                    sw.WriteLine(PathTerminator);
                }
            }

            public static void SavePath(Path path, string fileName)
            {
                SavePath(path.PointSequence, fileName);
            }

            public static IEnumerable<Point3D> LoadPointList(string fileName)
            {
                List<Point3D> pointList = new List<Point3D>();

                using (StreamReader sw = new StreamReader(StorageDir + "\\" + fileName))
                {
                    while (true)
                    {
                        string line = sw.ReadLine();

                        if (line == null || line == PathTerminator)
                        {
                            break;
                        }

                        Point3D currentPoint = new Point3D();

                        string[] coords = line.Split(new char[] {' '}, StringSplitOptions.None);
                        currentPoint.X = int.Parse(coords[0]);
                        currentPoint.Y = int.Parse(coords[1]);
                        currentPoint.Z = int.Parse(coords[2]);

                        pointList.Add(currentPoint);
                    }
                }

                return pointList;
            }

            public static Path LoadPath(string fileName)
            {
                IEnumerable<Point3D> pointList = LoadPointList(fileName);

                return new Path(pointList);
            }
        }
    }
}