using System;
using System.Collections.Generic;

namespace DAL;

public partial class DuringRegistrationUser
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Email { get; set; }

    public int? Sex { get; set; }

    public string? Logon { get; set; }

    public DateTime? RegisterDate { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? Guid { get; set; }

    public string? Phone { get; set; }
}
