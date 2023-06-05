using System;
using System.Collections.Generic;

namespace DAL;

public partial class Microb
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? JsonBbody { get; set; }

    public int? LayersId { get; set; }

    public bool IsRare { get; set; }

    public decimal? Mean { get; set; }

    public decimal? Sd { get; set; }

    public virtual MicroLayer? Layers { get; set; }
}
