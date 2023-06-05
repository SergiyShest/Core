using System;
using System.Collections.Generic;

namespace DAL;

public partial class Summary
{
    public int Id { get; set; }

    public string? Kingdom { get; set; }

    public string? Phylum { get; set; }

    public string? Class { get; set; }

    public string? Order { get; set; }

    public string? Family { get; set; }

    public string? Genus { get; set; }

    public string? Species { get; set; }

    public int Hits { get; set; }

    public decimal HitsPercent { get; set; }

    public int? WorkflowResultId { get; set; }

    public virtual WfResult? WorkflowResult { get; set; }
}
