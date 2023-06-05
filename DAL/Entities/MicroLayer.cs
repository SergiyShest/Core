using System;
using System.Collections.Generic;

namespace DAL;

public partial class MicroLayer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Microb> Microbs { get; set; } = new List<Microb>();
}
