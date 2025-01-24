namespace SurveyBasket.api.Errors
{
   

        public static class PollsErrors
        {
            public static readonly Error PollNotFound =
                new(" Not found poll", "No found poll with this ID");
        }
}
