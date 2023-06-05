using System;
using System.Collections.Generic;

namespace DAL;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Email { get; set; }

    public int? Sex { get; set; }

    public string? Logon { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? Auth { get; set; }

    public DateTime? RegisterDate { get; set; }

    public string? Guid { get; set; }

    public string? Description { get; set; }

    public bool? EnableChat { get; set; }

    public int? ImageDataId { get; set; }

    public int Role { get; set; }

    public bool? EnablePublicSearch { get; set; }

    public string? Phone { get; set; }

    public virtual BinaryObject? ImageData { get; set; }

    public virtual ICollection<Kit> Kits { get; set; } = new List<Kit>();
}
