using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UFCInfoApi.Data;
using UFCInfoApi.Models;
using UFCInfoApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UFCInfoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configure EF Core to use SQL Server
            services.AddDbContext<UFCContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UFCDatabase")));

            // Register UFCDataService for handling CRUD operations
            services.AddScoped<UFCDataService>();

            // Add Swagger generation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UFC API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UFCContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ensure the database is created and seed the data
            context.Database.EnsureCreated();
            SeedDatabase(context);

            // Enable Swagger middleware for generating and serving the Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UFC API v1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Seed data into the database if tables are empty
        private void SeedDatabase(UFCContext context)
        {
            // Seed Fighters if table is empty
            if (!context.Fighters.Any())
            {
                var fighters = new List<Fighter>
                {
                      new Fighter { Name = "Jon Jones", Age = 34, Weight = 205, Height = 6.4, WeightClass = "Light Heavyweight", FightRecord = "26-1-0" },
  new Fighter { Name = "Kamaru Usman", Age = 35, Weight = 170, Height = 6.0, WeightClass = "Welterweight", FightRecord = "20-2-0" },
  new Fighter { Name = "Israel Adesanya", Age = 32, Weight = 185, Height = 6.4, WeightClass = "Middleweight", FightRecord = "23-2-0" },
  new Fighter { Name = "Francis Ngannou", Age = 36, Weight = 260, Height = 6.4, WeightClass = "Heavyweight", FightRecord = "17-3-0" },
  new Fighter { Name = "Alexander Volkanovski", Age = 33, Weight = 145, Height = 5.6, WeightClass = "Featherweight", FightRecord = "25-1-0" },
  new Fighter { Name = "Charles Oliveira", Age = 32, Weight = 155, Height = 5.10, WeightClass = "Lightweight", FightRecord = "32-8-0" },
  new Fighter { Name = "Dustin Poirier", Age = 33, Weight = 155, Height = 5.9, WeightClass = "Lightweight", FightRecord = "28-7-0" },
  new Fighter { Name = "Max Holloway", Age = 30, Weight = 145, Height = 5.11, WeightClass = "Featherweight", FightRecord = "23-6-0" },
  new Fighter { Name = "Stipe Miocic", Age = 39, Weight = 240, Height = 6.4, WeightClass = "Heavyweight", FightRecord = "20-4-0" },
  new Fighter { Name = "Petr Yan", Age = 29, Weight = 135, Height = 5.7, WeightClass = "Bantamweight", FightRecord = "16-3-0" },
  new Fighter { Name = "Aljamain Sterling", Age = 32, Weight = 135, Height = 5.7, WeightClass = "Bantamweight", FightRecord = "21-3-0" },
  new Fighter { Name = "Brandon Moreno", Age = 29, Weight = 125, Height = 5.7, WeightClass = "Flyweight", FightRecord = "19-5-2" },
  new Fighter { Name = "Cory Sandhagen", Age = 30, Weight = 135, Height = 5.11, WeightClass = "Bantamweight", FightRecord = "14-4-0" },
  new Fighter { Name = "Colby Covington", Age = 33, Weight = 170, Height = 5.11, WeightClass = "Welterweight", FightRecord = "16-3-0" },
  new Fighter { Name = "Justin Gaethje", Age = 33, Weight = 155, Height = 5.11, WeightClass = "Lightweight", FightRecord = "23-3-0" },
  new Fighter { Name = "Robert Whittaker", Age = 31, Weight = 185, Height = 6.0, WeightClass = "Middleweight", FightRecord = "23-5-0" },
  new Fighter { Name = "Glover Teixeira", Age = 42, Weight = 205, Height = 6.2, WeightClass = "Light Heavyweight", FightRecord = "33-7-0" },
  new Fighter { Name = "Rose Namajunas", Age = 29, Weight = 115, Height = 5.5, WeightClass = "Strawweight", FightRecord = "11-4-0" },
  new Fighter { Name = "Jorge Masvidal", Age = 37, Weight = 170, Height = 5.11, WeightClass = "Welterweight", FightRecord = "35-15-0" },
  new Fighter { Name = "Zhang Weili", Age = 32, Weight = 115, Height = 5.4, WeightClass = "Strawweight", FightRecord = "21-3-0" },
  new Fighter { Name = "Leon Edwards", Age = 30, Weight = 170, Height = 6.0, WeightClass = "Welterweight", FightRecord = "19-3-0" },
  new Fighter { Name = "Jan Blachowicz", Age = 38, Weight = 205, Height = 6.2, WeightClass = "Light Heavyweight", FightRecord = "28-9-0" },
  new Fighter { Name = "Jessica Andrade", Age = 30, Weight = 125, Height = 5.1, WeightClass = "Flyweight", FightRecord = "22-9-0" },
  new Fighter { Name = "Tai Tuivasa", Age = 28, Weight = 265, Height = 6.2, WeightClass = "Heavyweight", FightRecord = "14-3-0" },
  new Fighter { Name = "Sean O'Malley", Age = 27, Weight = 135, Height = 5.11, WeightClass = "Bantamweight", FightRecord = "15-1-0" },
  new Fighter { Name = "Gilbert Burns", Age = 34, Weight = 170, Height = 5.10, WeightClass = "Welterweight", FightRecord = "20-4-0" },
  new Fighter { Name = "Henry Cejudo", Age = 34, Weight = 135, Height = 5.4, WeightClass = "Bantamweight", FightRecord = "16-2-0" },
  new Fighter { Name = "Yair Rodriguez", Age = 29, Weight = 145, Height = 5.11, WeightClass = "Featherweight", FightRecord = "14-3-0" },
  new Fighter { Name = "Derrick Lewis", Age = 36, Weight = 265, Height = 6.3, WeightClass = "Heavyweight", FightRecord = "26-8-0" },
  new Fighter { Name = "Paulo Costa", Age = 30, Weight = 185, Height = 6.1, WeightClass = "Middleweight", FightRecord = "13-2-0" }

                };

                context.Fighters.AddRange(fighters);
                context.SaveChanges();
            }

            // Seed Events if table is empty
            if (!context.Events.Any())
            {
                var events = new List<Event>
                {
                     new Event { EventName = "UFC 300: Jones vs Ngannou", EventDate = DateTime.Now.AddDays(30), EventTime = "10:00 PM ET", Fighters = context.Fighters.Take(2).ToList() },
    new Event { EventName = "UFC 301: Adesanya vs Whittaker", EventDate = DateTime.Now.AddDays(60), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(2).Take(2).ToList() },
    new Event { EventName = "UFC 302: Volkanovski vs Holloway", EventDate = DateTime.Now.AddDays(90), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(4).Take(2).ToList() },
    new Event { EventName = "UFC 303: Poirier vs Oliveira", EventDate = DateTime.Now.AddDays(120), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(6).Take(2).ToList() },
    new Event { EventName = "UFC 304: Usman vs Covington", EventDate = DateTime.Now.AddDays(150), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(8).Take(2).ToList() },
    new Event { EventName = "UFC 305: Miocic vs Lewis", EventDate = DateTime.Now.AddDays(180), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(10).Take(2).ToList() },
    new Event { EventName = "UFC 306: Moreno vs Yan", EventDate = DateTime.Now.AddDays(210), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(12).Take(2).ToList() },
    new Event { EventName = "UFC 307: O'Malley vs Sterling", EventDate = DateTime.Now.AddDays(240), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(14).Take(2).ToList() },
    new Event { EventName = "UFC 308: Blachowicz vs Glover", EventDate = DateTime.Now.AddDays(270), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(16).Take(2).ToList() },
    new Event { EventName = "UFC 309: Costa vs Burns", EventDate = DateTime.Now.AddDays(300), EventTime = "10:00 PM ET", Fighters = context.Fighters.Skip(18).Take(2).ToList() }
};




                context.Events.AddRange(events);
                context.SaveChanges();
            }

            // Seed Articles if table is empty
            if (!context.Articles.Any())
            {
                var articles = new List<Article>
                {
                    new Article { Title = "Upcoming UFC 300 Preview", Url = "https://example.com/ufc300", PublishedAt = DateTime.Now },
                    new Article { Title = "UFC Fighter Spotlight: Jon Jones", Url = "https://example.com/jon-jones", PublishedAt = DateTime.Now.AddDays(-1) },
                    // Add more articles as needed...
                };

                context.Articles.AddRange(articles);
                context.SaveChanges();
            }
        }
    }
}
