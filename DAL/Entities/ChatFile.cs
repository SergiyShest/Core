using System;
using System.Collections.Generic;

namespace DAL;

public partial class ChatFile
{
    public int Id { get; set; }

    public int BinaryObjectId { get; set; }

    public int ChatMessageId { get; set; }

    public string? FileName { get; set; }

    public virtual BinaryObject BinaryObject { get; set; } = null!;

    public virtual ChatMessage ChatMessage { get; set; } = null!;
}
