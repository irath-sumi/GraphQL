//using GraphQLBasic.DAL;
using GraphQLBasic;
using GraphQLBasic.DAL;
using GraphQLBasic.Database;
using GraphQLBasic.Models;
using GraphQLBasic.Service;
//using GraphQLBasic.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer
//(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddPooledDbContextFactory<SchoolContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddGraphQLServer()
    .AddQueryType<SchoolService>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddProjections().AddFiltering().AddSorting()
    .AddInMemorySubscriptions();

    


//builder.Services.AddGraphQLServer().AddQueryType<QueryType>();



// EF Core to query only selected fields
//builder.Services.AddGraphQLServer().AddQueryType<QueryType>().AddProjections().AddFiltering().AddSorting();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //app.UsePlayground(new PlaygroundOptions
    //{
    //    QueryPath = "/api",
    //    Path = "/playground"
    //});

   // The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// create db if not present already
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<SchoolContext>();
//    dbContext.Database.EnsureCreated();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseAuthorization();

app.UseWebSockets();//adds websockets middleware to request pipeline


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.MapGet("/", () => "Hello World!");

app.MapRazorPages();

app.Run();
