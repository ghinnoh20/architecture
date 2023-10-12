using System;
using System.Collections.Generic;

namespace Core.Domains;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifyDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
