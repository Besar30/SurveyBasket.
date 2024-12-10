namespace SurveyBasket.api.Services
{
    public interface Ipollservices
    {
        public Task<IEnumerable<Poll>> GetallAsync(CancellationToken cancellationToken = default);
        public  Task<Poll?> Getasync(int id,CancellationToken cancellationToken = default);
        public Task< Poll> addasync(Poll poll,CancellationToken cancellationToken = default);
        public Task< bool> updateasync(int id, Poll poll, CancellationToken cancellationToken = default);
        public Task< bool> deleteasync(int id, CancellationToken cancellationToken = default);
        public Task< bool> togglepublishstatusasync(int id, CancellationToken cancellationToken = default);
    }
}
