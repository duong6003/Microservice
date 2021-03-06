using CommandsService.SyncDataServices.Grpc;
using Microsoft.EntityFrameworkCore;
using PlatformService;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsProduction())
{
    string connection = builder.Configuration.GetConnectionString("PlatformsConn");
    Console.WriteLine("--> Using Sql Server Db");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(connection));
}
else
{
    Console.WriteLine("--> Using InMem Db");
    builder.Services.AddDbContext<AppDbContext>(opt =>
         opt.UseInMemoryDatabase("InMem"));
}
builder.Services.AddConfiguration();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.WriteLine($"--> CommandService Endpoint {builder.Configuration["CommandService"]}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

#region route
app.MapControllers();
app.MapGrpcService<GrpcPlatformService>();
app.MapGet("/protos/platforms.proto", async context => {
    await context.Response.WriteAsync(File.ReadAllText("Protos/platforms.proto"));
});
#endregion

PrepDb.PrepPopulation(app);

app.Run();
