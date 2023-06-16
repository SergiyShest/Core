using System;
using System.Collections.Generic;

namespace DAL;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateOnly? Date { get; set; }

    public string? Comment { get; set; }

   public int? WorkOstId   { get; set; }

    public int? UserOstId   { get; set; }

    public DateTime? LDate { get; set; }

   public DateTime? CDate { get; set; }

    public string? LUser { get; set; }

   public string? CUser { get; set; }



}
