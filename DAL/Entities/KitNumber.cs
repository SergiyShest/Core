using System;
using System.Collections.Generic;

namespace DAL;

public partial class KitNumber
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public bool Taken { get; set; }
}
