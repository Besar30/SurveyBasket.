namespace SurveyBasket.api.contracts.polls
{
    public record Createpollrequest
        (string Title,
          string Summary,
           bool IsPublished,
           DateOnly StartsAt,
           DateOnly EndsAt);
}
