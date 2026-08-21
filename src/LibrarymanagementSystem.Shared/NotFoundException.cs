using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarymanagementSystem.Shared
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
