using TimeAttendance.TestJob.Server.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.DataBaseRegister(builder.Configuration);
builder.Services.CorsRegister(builder.Configuration);
builder.Services.ServicesRegister();
builder.Services.SwaggerRegister();

var app = builder.Build();

app.SwaggerConfigure();
app.CorsConfigure();
app.UseHttpsRedirection();
app.SignalRConfigure();
app.UseAuthorization();
app.MapControllers();


app.Run();
