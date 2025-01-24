namespace SurveyBasket.api.Services
{
    public interface Ipollservices
    {
        public Task<IEnumerable<Poll>> GetallAsync(CancellationToken cancellationToken = default);
        public  Task<Result<CreatePollRespons>> Getasync(int id,CancellationToken cancellationToken = default);
        public Task<CreatePollRespons> addasync(Createpollrequest poll,CancellationToken cancellationToken = default);
        public Task<Result> updateasync(int id, Createpollrequest poll, CancellationToken cancellationToken = default);
        public Task< Result> deleteasync(int id, CancellationToken cancellationToken = default);
        public Task< Result> togglepublishstatusasync(int id, CancellationToken cancellationToken = default);
    }
}
