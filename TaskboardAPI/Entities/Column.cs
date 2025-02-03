using System;

namespace TaskboardAPI.Entities;

public class Column
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int BoardId { get; set; }
    public Board? Board { get; set; }

}