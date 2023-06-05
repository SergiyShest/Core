using System;
using System.Collections.Generic;

namespace DAL;

public partial class VjsfForm
{
    public int Id { get; set; }

    public string? RefTable { get; set; }

    public string? VariableName { get; set; }

    public string? Model { get; set; }

    public string? Schema { get; set; }

    public string? Options { get; set; }

    public virtual ICollection<VjsfFormData> VjsfFormData { get; set; } = new List<VjsfFormData>();
}
