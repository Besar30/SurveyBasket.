
using SurveyBasket.api.Models;

namespace SurveyBasket.api.Services
{
    public class pollservices : Ipollservices
    {
        private static readonly List<Poll> _polls = new()
        {
            new Poll {Id=1,Title="poll 1",Summary="my first poll"},
        };
        public IEnumerable<Poll> Getall() => _polls;
   
        public Poll? Get(int id)=>_polls.SingleOrDefault(pol => pol.Id == id);

        public Poll add(Poll poll)
        {
            poll.Id = _polls.Count + 1;
            _polls.Add(poll);
            return poll;
        }

        public bool update(int id, Poll poll)
        {
           var updated=Get(id);
            if (updated == null) { 
               return false;
            }
            updated.Title = poll.Title;
            updated.Summary = poll.Summary; 
            return true;
        }

        public bool delete(int id)
        {
            var poll = Get(id);
            if (poll == null)
            {
                return false;
            }
            _polls.Remove(poll);
            return true;
        }
    }
}
