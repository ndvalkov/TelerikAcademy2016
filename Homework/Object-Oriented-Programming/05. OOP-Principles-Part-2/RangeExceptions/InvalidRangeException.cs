using System;
using System.Runtime.Serialization;

namespace RangeExceptions
{
    public class InvalidRangeException<T> : Exception where T : struct
    {
        public const string InvalidRangeMsg = "The {0} must be in the range {1}";
        public const string RangeDefinition = "[{0} ... {1}]";

        public T Start { get; }
        public T End { get; }

        public override string Message
        {
            get
            {
                string val = typeof(T).ToString().Split('.')[1];
                string def = string.Format(RangeDefinition, this.Start, this.End);

                return string.Format(InvalidRangeMsg, val, def);
            }
        }

        public InvalidRangeException()
        {
        }

        public InvalidRangeException(string message) : base(message)
        {
        }

        public InvalidRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidRangeException(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}