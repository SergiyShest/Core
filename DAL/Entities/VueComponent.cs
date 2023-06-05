using System;
using System.Collections.Generic;

namespace DAL;

public partial class VueComponent
{
    public int Id { get; set; }

    public string? RefTable { get; set; }

    public string? VariableName { get; set; }

    public string? Template { get; set; }

    public string? Json { get; set; }

    public virtual ICollection<VueComponentData> VueComponentData { get; set; } = new List<VueComponentData>();
}
