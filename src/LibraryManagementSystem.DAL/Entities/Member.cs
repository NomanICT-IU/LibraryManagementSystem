using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.DAL.Entities;

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string MemberCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Adress { get; set; }
    public bool Status { get; set; }
}
