using System;
using remoteops.Infrastructure.Exceptions;
namespace remoteops.Infrastructure.Exceptions.DatabaseException
{
    public class DatabaseException : CustomException
    {
        public DatabaseException() { }
        public DatabaseException(string message) : base(message) { }
        public DatabaseException(string message, Exception inner) : base(message, inner) { }
    }
}