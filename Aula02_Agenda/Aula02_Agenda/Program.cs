using Aula02_Agenda.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtAuth(builder.Configuration);

builder.Services.AddMemoryCache();

builder.Services.AddControllers();

//Inicio - Injecao Dependencias - DI

builder.Services.AddInjecaoDependencias(builder.Configuration);

//Fim - Injecao Dependencias - DI

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddJwtSwagger();

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
