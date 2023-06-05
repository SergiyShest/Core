using System;
using System.Collections.Generic;

namespace DAL;

public partial class VueComponentData
{
    public int Id { get; set; }

    public int VueComponentId { get; set; }

    public string? RefToTable { get; set; }

    public string? Json { get; set; }

    public virtual VueComponent VueComponent { get; set; } = null!;
}
