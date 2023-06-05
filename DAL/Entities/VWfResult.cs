using System;
using System.Collections.Generic;

namespace DAL;

public partial class VWfResult
{
    public int? Id { get; set; }

    public int? PatientId { get; set; }

    public DateTime? Date { get; set; }

    public string? JsonData { get; set; }
}
