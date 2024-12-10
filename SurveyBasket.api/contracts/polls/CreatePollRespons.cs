namespace SurveyBasket.api.contracts.polls
{
    public record CreatePollRespons(
        int id,
        string Title,
          string Summary,
           bool IsPublished,
           DateOnly StartsAt,
           DateOnly EndsAt);

}
