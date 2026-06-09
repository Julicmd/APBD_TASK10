using StudentPanel.Components;
using StudentPanel.Controller;
using StudentPanel.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<StudentsApiClient>(client =>
    client.BaseAddress = new Uri("http://localhost:5080/"));

builder.Services.AddScoped<ObservedStudentsState>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

StudentController.MapEndpoints(app);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
