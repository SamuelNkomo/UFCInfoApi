// Services/UFCDataService.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UFCInfoApi.Data;
using UFCInfoApi.Models;

namespace UFCInfoApi.Services
{
    public class UFCDataService
    {
        private readonly UFCContext _context;

        public UFCDataService(UFCContext context)
        {
            _context = context;
        }

        // Get all fighters
        public async Task<List<Fighter>> GetFightersAsync()
        {
            return await _context.Fighters.ToListAsync();
        }

        // Get fighter by ID
        public async Task<Fighter> GetFighterDetailsAsync(int fighterId)
        {
            return await _context.Fighters.FindAsync(fighterId);
        }

        // Add new fighter
        // Add new fighter
        public async Task<Fighter> AddFighterAsync(Fighter fighter)
        {
            _context.Fighters.Add(fighter);
            await _context.SaveChangesAsync();
            return fighter;
        }

        // Update an existing fighter
        public async Task<Fighter> UpdateFighterAsync(Fighter fighter)
        {
            var existingFighter = await _context.Fighters.FindAsync(fighter.Id);
            if (existingFighter == null)
            {
                return null;
            }

            // Update fighter fields
            existingFighter.Name = fighter.Name;
            existingFighter.Age = fighter.Age;
            existingFighter.Weight = fighter.Weight;
            existingFighter.Height = fighter.Height;
            existingFighter.WeightClass = fighter.WeightClass;
            existingFighter.FightRecord = fighter.FightRecord;

            _context.Fighters.Update(existingFighter);
            await _context.SaveChangesAsync();

            return existingFighter;
        }

        // Delete a fighter by ID
        public async Task<bool> DeleteFighterAsync(int fighterId)
        {
            var fighter = await _context.Fighters.FindAsync(fighterId);
            if (fighter == null)
            {
                return false;
            }

            _context.Fighters.Remove(fighter);
            await _context.SaveChangesAsync();
            return true;
        }

        // Get all upcoming events
        public async Task<List<Event>> GetUpcomingEventsAsync()
        {
            return await _context.Events.Include(e => e.Fighters).ToListAsync();
        }

        // Get event by ID
        public async Task<Event> GetEventDetailsAsync(int eventId)
        {
            return await _context.Events.Include(e => e.Fighters).FirstOrDefaultAsync(e => e.Id == eventId);
        }

        // Add new event
        public async Task<Event> AddEventAsync(Event ufcEvent)
        {
            _context.Events.Add(ufcEvent);
            await _context.SaveChangesAsync();
            return ufcEvent;
        }

        // Update an existing event
        public async Task<Event> UpdateEventAsync(Event ufcEvent)
        {
            var existingEvent = await _context.Events.Include(e => e.Fighters).FirstOrDefaultAsync(e => e.Id == ufcEvent.Id);
            if (existingEvent == null)
            {
                return null;
            }

            // Update event fields
            existingEvent.EventName = ufcEvent.EventName;
            existingEvent.EventDate = ufcEvent.EventDate;
            existingEvent.EventTime = ufcEvent.EventTime;

            // Optionally update fighters participating in the event
            existingEvent.Fighters = ufcEvent.Fighters;

            _context.Events.Update(existingEvent);
            await _context.SaveChangesAsync();

            return existingEvent;
        }

        // Delete an event by ID
        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var ufcEvent = await _context.Events.FindAsync(eventId);
            if (ufcEvent == null)
            {
                return false;
            }

            _context.Events.Remove(ufcEvent);
            await _context.SaveChangesAsync();
            return true;
        }

        // Get all articles
        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        // Get article by ID
        public async Task<Article> GetArticleDetailsAsync(int articleId)
        {
            return await _context.Articles.FindAsync(articleId);
        }

        // Add new article
        public async Task<Article> AddArticleAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        // Update an existing article
        public async Task<Article> UpdateArticleAsync(Article article)
        {
            var existingArticle = await _context.Articles.FindAsync(article.Id);
            if (existingArticle == null)
            {
                return null;
            }

            // Update article fields
            existingArticle.Title = article.Title;
            existingArticle.Url = article.Url;
            existingArticle.PublishedAt = article.PublishedAt;

            _context.Articles.Update(existingArticle);
            await _context.SaveChangesAsync();

            return existingArticle;
        }

        // Delete an article by ID
        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            var article = await _context.Articles.FindAsync(articleId);
            if (article == null)
            {
                return false;
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
