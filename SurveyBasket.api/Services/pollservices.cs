
using Microsoft.AspNetCore.Http.HttpResults;
using SurveyBasket.api.Errors;
using SurveyBasket.api.Models;

namespace SurveyBasket.api.Services
{
    public class pollservices(ApplicationDbContext context) : Ipollservices
    {
       private readonly ApplicationDbContext _context=context;
        public async Task< IEnumerable<Poll>> GetallAsync(CancellationToken cancellationToken = default) => await _context.Polls.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Result<CreatePollRespons>> Getasync(int id, CancellationToken cancellationToken = default)
        {
            var poll = await _context.Polls.FindAsync(id, cancellationToken);
             return poll is not null ?
                Result.Success(poll.Adapt<CreatePollRespons>()) :
                Result.Failure<CreatePollRespons>(PollsErrors.PollNotFound);
        }
        public async Task<CreatePollRespons> addasync(Createpollrequest request, CancellationToken cancellationToken = default)
        {
            var poll = request.Adapt<Poll>();
            await _context.Polls.AddAsync(poll, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Adapt<CreatePollRespons>();
        }

        public async Task<Result> updateasync(int id, Createpollrequest poll, CancellationToken cancellationToken = default)
        {
            var updated = await _context.Polls.FindAsync(id, cancellationToken);
            if (updated == null)
            {
                return Result.Failure(PollsErrors.PollNotFound);
            }
            updated.Title = poll.Title;
            updated.Summary = poll.Summary;
            updated.StartsAt = poll.StartsAt;
            updated.EndsAt = poll.EndsAt;
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        public async Task<Result> deleteasync(int id, CancellationToken cancellationToken = default)
        {
            var poll = await _context.Polls.FindAsync(id,cancellationToken);
            if(poll==null)return Result.Failure(PollsErrors.PollNotFound);
             _context.Polls.Remove(poll);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        public async Task<Result> togglepublishstatusasync(int id, CancellationToken cancellationToken = default)
        {
            var poll = await _context.Polls.FindAsync(id, cancellationToken);
            if (poll == null)
            {
                return Result.Failure(PollsErrors.PollNotFound);
            }
            poll.IsPublished = !poll.IsPublished;
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
