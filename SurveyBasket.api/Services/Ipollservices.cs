namespace SurveyBasket.api.Services
{
    public interface Ipollservices
    {
        public IEnumerable<Poll> Getall();
        public Poll? Get(int id);
        public Poll add(Poll poll);
        public bool update(int id, Poll poll);
        public bool delete(int id);
    }
}
