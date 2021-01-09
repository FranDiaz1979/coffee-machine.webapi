namespace Services
{
    using System;

    [Serializable]
    public class BadParametersException : Exception
    {
        public BadParametersException()
        {
        }

        public BadParametersException(string message)
            : base(message)
        {
        }

        public BadParametersException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BadParametersException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
