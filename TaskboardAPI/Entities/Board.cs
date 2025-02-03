using System;

namespace TaskboardAPI.Entities;

public class Board
{
    public int Id { get; set; }
    public required string Title { get; set; }

}