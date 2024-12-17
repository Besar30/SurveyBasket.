namespace SurveyBasket.api.contracts.polls
{
    public record Createpollrequest
        (string Title,
          string Summary,
           DateOnly StartsAt,
           DateOnly EndsAt);
}
