using TaskboardAPI.Data;
using TaskboardAPI.Dtos;
using TaskboardAPI.Entities;

namespace TaskboardAPI.Endpoints;

public static class ColumnEndpoint
{

    public static RouteGroupBuilder MapColumnEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("column")
                  .WithParameterValidation();

        group.MapGet("/{boardId}", (int boardId, ApplicationContext context) =>
         {
             var columns = context.Columns.Where(c => c.BoardId == boardId).ToList();
             return columns.Any() ? Results.Ok(columns) : Results.NotFound("Empty board");
         }
        );


        group.MapPost("/", (ColumnDto newColumn, ApplicationContext context) =>
         {
             Column column = new()
             {
                 Title = newColumn.Title,
                 BoardId = newColumn.BoardId
             };
             context.Add(column);
             context.SaveChanges();
         }
         );

        group.MapPut("/{id}", (int id, UpdateColumnDto updatedColumn, ApplicationContext context) =>
        {
            var column = context.Columns.Find(id);
            if (column == null)
            {
                return Results.NotFound();
            }
            column.Title = updatedColumn.Title;
            column.BoardId = updatedColumn.BoardId;
            context.SaveChanges();

            return Results.NoContent();
        }
        );

        group.MapDelete("/{id}", (int id, ApplicationContext context) =>
        {
            var column = context.Columns.Find(id);
            if (column == null)
            {
                return Results.NotFound();
            }

            context.Columns.Remove(column);
            context.SaveChanges();

            return Results.NoContent();
        });


        return group;

    }
}
