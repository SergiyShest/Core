using System;
using System.Collections.Generic;

namespace DAL;

public partial class ChatMessage
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string? Message { get; set; }

    public DateTime CrDate { get; set; }

    public virtual ICollection<ChatFile> ChatFiles { get; set; } = new List<ChatFile>();
}
