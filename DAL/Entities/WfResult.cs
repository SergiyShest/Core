using System;
using System.Collections.Generic;

namespace DAL;

public partial class WfResult
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<Kit> Kits { get; set; } = new List<Kit>();

    public virtual CPatient? Patient { get; set; }

    public virtual ICollection<Summary> Summaries { get; set; } = new List<Summary>();

    public virtual ICollection<WfResultPoint> WfResultPoints { get; set; } = new List<WfResultPoint>();
}
