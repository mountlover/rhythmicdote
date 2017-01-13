using System;

using System.Runtime.Serialization;



namespace Rhythmicdote

{

    [Serializable]

    internal class InvalidChunkException : Exception

    {

        public InvalidChunkException()

        {

        }



        public InvalidChunkException(string message) : base(message)

        {

        }



        public InvalidChunkException(string message, Exception innerException) : base(message, innerException)

        {

        }



        protected InvalidChunkException(SerializationInfo info, StreamingContext context) : base(info, context)

        {

        }

    }

}
