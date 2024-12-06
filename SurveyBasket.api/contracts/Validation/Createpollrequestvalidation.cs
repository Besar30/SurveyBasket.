using FluentValidation;
using SurveyBasket.api.contracts.Request;

namespace SurveyBasket.api.contracts.Validation
{
    public class Createpollrequestvalidation : AbstractValidator<Createpollrequest>
    {
        public Createpollrequestvalidation() {
            RuleFor(x => x.Title).NotEmpty()
                .Length(3,100).
                WithMessage("plese enter string betwwen 3 and 100 , included");
        }
    }
}
