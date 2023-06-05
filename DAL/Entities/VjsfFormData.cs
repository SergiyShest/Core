using System;
using System.Collections.Generic;

namespace DAL;

public partial class VjsfFormData
{
    public int Id { get; set; }

    public int VjsfFormId { get; set; }

    public string? RefToTable { get; set; }

    public string? Json { get; set; }

    public virtual VjsfForm VjsfForm { get; set; } = null!;
}
