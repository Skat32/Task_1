using System;

namespace Logic.Exceptions
{
    public class AlreadyCreatedException : Exception
    {
        public AlreadyCreatedException(string message, Guid id) : base(message)
        {
            Id = id;
        }

        /// <summary>
        /// Идентификатор в базе
        /// </summary>
        public Guid Id { get; }
    }
}