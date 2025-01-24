namespace SurveyBasket.api.contracts.polls
{
    public record CreatePollRespons(
       int Id,
        string Title,
          string Summary,
           bool IsPublished,
           DateOnly StartsAt,
           DateOnly EndsAt);

}
