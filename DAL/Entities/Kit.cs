using System;
using System.Collections.Generic;

namespace DAL;

public partial class Kit
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? ActivationCode { get; set; }

    public DateTime? CollectedDate { get; set; }

    public int? WorkflowResultId { get; set; }

    public int Status { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual WfResult? WorkflowResult { get; set; }
}
