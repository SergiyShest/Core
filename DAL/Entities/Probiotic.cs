using System;
using System.Collections.Generic;

namespace DAL;

public partial class Probiotic
{
    public int Id { get; set; }

    public string? GenusName { get; set; }

    public string? SpeciesName { get; set; }

    public string? Label { get; set; }
}
