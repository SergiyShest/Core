using System;
using System.Collections.Generic;

namespace DAL;

public partial class MicroGroup
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int[]? Included { get; set; }

    public string? FrequencyJsonB { get; set; }

    public decimal? Mean { get; set; }

    public decimal? Sd { get; set; }

    public decimal? _90Percentile { get; set; }

    public string? Description { get; set; }
}
