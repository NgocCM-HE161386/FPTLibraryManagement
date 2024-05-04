using System;
using System.Collections.Generic;

namespace LibraryManagement.DataAccess;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string? StudentName { get; set; }

    public string? Phone { get; set; }

    public DateTime? Dob { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<BorrowBook> BorrowBooks { get; set; } = new List<BorrowBook>();
}
