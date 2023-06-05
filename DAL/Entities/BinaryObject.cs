using System;
using System.Collections.Generic;

namespace DAL;

public partial class BinaryObject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Extention { get; set; }

    public byte[]? Content { get; set; }

    public virtual ICollection<ChatFile> ChatFiles { get; set; } = new List<ChatFile>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
