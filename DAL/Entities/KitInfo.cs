using System;
using System.Collections.Generic;

namespace DAL;

public partial class KitInfo
{
    public int? Id { get; set; }

    public string? ActivationCode { get; set; }

    public int? Status { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Email { get; set; }

    public int? Sex { get; set; }
}
