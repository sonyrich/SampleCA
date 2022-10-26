using SampleCA.WebAPI.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InstallServiceInAssembly(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("corsapp");
//}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();
app.MapControllers();

app.Run();