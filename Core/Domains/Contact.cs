using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domains;

public partial class Contact
{
    public int Id { get; set; }

    public int? StudentId { get; set; }
    
    public int TelcoId { get; set; }

    public string Number { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Student? Student { get; set; }
}
