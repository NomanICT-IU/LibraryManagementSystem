using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.DAL.Entities
{
    public class BookCopy
    {
        public int CopyId { get; set; }
        public string CopyCode { get; set; }
        public int BookId { get; set; }
        public int Status { get; set; }
    }
}
