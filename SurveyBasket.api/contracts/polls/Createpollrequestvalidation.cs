using FluentValidation;

namespace SurveyBasket.api.contracts.polls
{
    public class Createpollrequestvalidation : AbstractValidator<Createpollrequest>
    {
        public Createpollrequestvalidation()
        {
            RuleFor(x => x.Title).NotEmpty()
                .Length(3, 100).
                WithMessage("plese enter string betwwen 3 and 100 , included");
            RuleFor(x => x.StartsAt).NotEmpty().GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));
            RuleFor(x => x.EndsAt).NotEmpty();
            RuleFor(x => x).Must(hasvalidate)
                .WithName(nameof(Createpollrequest.EndsAt))
                .WithMessage("{PropertyName} must greater than startAt");

        }
        private bool hasvalidate(Createpollrequest poll)
        {
            return poll.EndsAt >= poll.StartsAt;
        }
    }
}
