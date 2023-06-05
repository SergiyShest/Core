using System;
using System.Collections.Generic;

namespace DAL;

public partial class CPatient
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<WfResult> WfResults { get; set; } = new List<WfResult>();
}
