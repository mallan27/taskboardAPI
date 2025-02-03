using TaskboardAPI.Data;
using TaskboardAPI.Dtos;
using TaskboardAPI.Entities;

namespace TaskboardAPI.Endpoints;

public static class CardEndpoint
{

    public static RouteGroupBuilder MapCardEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("card")
                  .WithParameterValidation();

        group.MapGet("/", (ApplicationContext context) =>
        {
            return context.Cards;
        }
        );

        group.MapGet("/{columnId}", (int columnId, ApplicationContext context) =>
         {
             var cards = context.Cards.Where(c => c.ColumnId == columnId).ToList();
             return cards.Count != 0 ? Results.Ok(cards) : Results.NotFound("Empty column");
         }
        );

        group.MapPost("/", (CardDto newCard, ApplicationContext context) =>
        {
            Card card = new()
            {
                Title = newCard.Title,
                Description = newCard.Description,
                ColumnId = newCard.ColumnId
            };
            context.Add(card);
            context.SaveChanges();
        }
        );

        group.MapPut("/{id}", (int id, UpdateCardDto updatedCard, ApplicationContext context) =>
        {
            var card = context.Cards.Find(id);
            if (card == null)
            {
                return Results.NotFound();
            }
            card.Title = updatedCard.Title;
            card.Description = updatedCard.Description;
            card.ColumnId = updatedCard.ColumnId;
            context.SaveChanges();
            return Results.NoContent();
        }
        );

        group.MapDelete("/{id}", (int id, ApplicationContext context) =>
        {
            var card = context.Cards.Find(id);
            if (card == null)
            {
                return Results.NotFound();
            }
            context.Cards.Remove(card);
            context.SaveChanges();
            return Results.NoContent();
        }
        );

        return group;

    }
}
