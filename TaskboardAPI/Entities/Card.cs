using System;

namespace TaskboardAPI.Entities;

public class Card
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int ColumnId { get; set; }
    public Column? Column { get; set; }
}