namespace Repositories
{
    using System;

    [Serializable]
    public class MyDataBaseException : Exception
    {
        public MyDataBaseException()
        {
        }

        public MyDataBaseException(string message)
            : base(message)
        {
        }

        public MyDataBaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected MyDataBaseException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}