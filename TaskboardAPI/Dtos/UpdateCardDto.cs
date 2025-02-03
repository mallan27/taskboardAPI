namespace TaskboardAPI.Dtos;

public record class UpdateCardDto(int Id, string Title, string Description, int ColumnId);
