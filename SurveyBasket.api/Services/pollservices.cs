
using Microsoft.AspNetCore.Http.HttpResults;
using SurveyBasket.api.Models;

namespace SurveyBasket.api.Services
{
    public class pollservices(ApplicationDbContext context) : Ipollservices
    {
       private readonly ApplicationDbContext _context=context;
        public async Task< IEnumerable<Poll>> GetallAsync(CancellationToken cancellationToken = default) => await _context.Polls.AsNoTracking().ToListAsync(cancellationToken);
   
        public async Task<Poll?> Getasync(int id,CancellationToken cancellationToken = default) => await _context.Polls.FindAsync(id,cancellationToken);

        public async Task<Poll> addasync(Poll poll,CancellationToken cancellationToken = default)
        {
           
             await _context.Polls.AddAsync(poll,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return poll;
        }

        public async Task< bool> updateasync(int id, Poll poll, CancellationToken cancellationToken = default)
        {
            var updated = await Getasync(id,cancellationToken);
            if (updated == null)
            {
                return false;
            }
            updated.Title = poll.Title;
            updated.Summary = poll.Summary;
            updated.StartsAt = poll.StartsAt;
            updated.EndsAt = poll.EndsAt;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task< bool> deleteasync(int id,CancellationToken cancellationToken=default)
        {
            var poll =await Getasync(id,cancellationToken);
            if (poll == null)
            {
                return false;
            }
            _context.Remove(poll);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<bool> togglepublishstatusasync(int id, CancellationToken cancellationToken = default)
        {
            var poll = await Getasync(id, cancellationToken);
            if (poll == null)
            {
                return false;
            }
            poll.IsPublished = !poll.IsPublished;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
