using TaskboardAPI.Data;
using TaskboardAPI.Dtos;
using TaskboardAPI.Entities;

namespace TaskboardAPI.Endpoints;

public static class BoardEndpoint
{

    public static RouteGroupBuilder MapBoardEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("board")
                  .WithParameterValidation();

        group.MapGet("/", (ApplicationContext context) =>
        {
            return context.Boards;
        });

        group.MapGet("/{id}", (int id, ApplicationContext context) =>
        {
            var board = context.Boards.Find(id);
            return board != null ? Results.Ok(board) : Results.NotFound();
        });


        group.MapPost("/", (BoardDto newBoard, ApplicationContext context) =>
        {
            Board board = new()
            {
                Title = newBoard.Title,
            };
            context.Add(board);
            context.SaveChanges();
        }
        );

        group.MapPut("/{id}", (int id, BoardDto newBoard, ApplicationContext context) =>
        {
            var board = context.Boards.Find(id);
            if (board == null)
            {
                return Results.NotFound();
            }
            board.Title = newBoard.Title;
            context.SaveChanges();
            return Results.NoContent();
        }
        );

        group.MapDelete("/{id}", (int id, ApplicationContext context) =>
         {
             var board = context.Boards.Find(id);
             if (board == null)
             {
                 return Results.NotFound();
             }
             context.Boards.Remove(board);
             context.SaveChanges();
             return Results.NoContent();
         }
         );

        return group;

    }
}
