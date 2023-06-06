using System;
using System.Collections.Generic;

namespace DAL;

public partial class Ost
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? FullName { get; set; }

    public virtual User? User { get; set; }
}
