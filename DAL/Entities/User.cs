using System;
using System.Collections.Generic;

namespace DAL;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int IdOst { get; set; }

    public DateOnly? Date { get; set; }

    public string? Email { get; set; }


}
