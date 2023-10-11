using System;
using System.Collections.Generic;

namespace Core.Domains;

public partial class E8Log
{
    public int Id { get; set; }

    public string? StoreCode { get; set; }

    public DateTime? TxDate { get; set; }

    public string? TxTime { get; set; }

    public string? Type { get; set; }

    public string? Module { get; set; }

    public string? Tranno { get; set; }

    public string? LogDescription { get; set; }

    public string? Employee { get; set; }

    public string? Terminal { get; set; }

    public bool? IsActive { get; set; }
}
