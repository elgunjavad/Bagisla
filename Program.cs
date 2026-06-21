using DateInviteWeb;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/api/generate", (DateInviteRequest req) =>
{
    if (!DateTime.TryParse(req.Date, out DateTime parsedDate))
    {
        return Results.BadRequest(new { error = "Tarix formatı yanlışdır." });
    }

    var invite = new DateInvite
    {
        Name = req.Name,
        Place = req.Place,
        DateTime = parsedDate,
        Message = req.Message
    };

    var generator = new InviteGenerator();
    string result = generator.Generate(invite);

    return Results.Ok(new { message = result });
});

app.Run();

record DateInviteRequest(string Name, string Place, string Date, string Message);