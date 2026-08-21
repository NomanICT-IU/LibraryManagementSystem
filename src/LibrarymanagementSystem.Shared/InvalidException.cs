using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarymanagementSystem.Shared
{
    public class InvalidException : Exception
    {
        public InvalidException(string message)
            : base(message)
        {
        }
    }
}
