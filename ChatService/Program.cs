using ChatService.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<ChatHub>("chat");
//});


app.MapHub<ChatHub>("chat");
app.Run();
