using System;
using System.Collections.Generic;

namespace LibraryManagement.DataAccess;

public partial class BorrowBook
{
    public string BookId { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public DateTime? BorrowedDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
