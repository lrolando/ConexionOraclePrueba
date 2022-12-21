using Persistence;
using Persistence.DBContext;
using Persistence.Entities;
using Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApiDBContext>();
builder.Services.AddScoped<IItemService<ITEM>, ItemService>();
builder.Services.AddScoped<IRepository<ITEM>, ItemRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
