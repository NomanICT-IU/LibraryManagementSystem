using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarymanagementSystem.Shared
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
