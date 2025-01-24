using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;

namespace SurveyBasket.api.contracts.polls
{
    public class Createpollrequestvalidation : AbstractValidator<Createpollrequest>
    {
        private readonly ApplicationDbContext _context; // Inject DbContext

        public Createpollrequestvalidation(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(3, 100)
                .WithMessage("Please enter a string between 3 and 100 characters, inclusive.");
               
               

            RuleFor(x => x.StartsAt)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

            RuleFor(x => x.EndsAt).NotEmpty();

            RuleFor(x => x)
                .Must(HasValidate)
                .WithName(nameof(Createpollrequest.EndsAt))
                .WithMessage("{PropertyName} must be greater than StartsAt.");
        }
        private bool HasValidate(Createpollrequest poll)
        {
            return poll.EndsAt >= poll.StartsAt;
        }
    }
}
