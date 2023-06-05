using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace DAL;

public partial class WfResultPoint
{
    public int Id { get; set; }

    public int WorkflowResultId { get; set; }

    public string? Name { get; set; }

    public NpgsqlPoint Point { get; set; }

    public virtual WfResult WorkflowResult { get; set; } = null!;
}
