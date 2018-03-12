using Owin;

namespace MachineCafe.WebApi.Infrastructure
{
    public static class AppBuilderExtensions
    {
        private const string TESTING_KEY = "isTestEnv";

        public static bool IsTestingEnvironment(this IAppBuilder app)
        {
            var hasTestProperty = app.Properties.ContainsKey(TESTING_KEY);
            if (hasTestProperty)
            {
                return bool.Parse(app.Properties[TESTING_KEY].ToString());
            }
            return false;
        }

        public static void IamTesting(this IAppBuilder app)
        {
            app.Properties.Add(TESTING_KEY,true);
        }

    }
}