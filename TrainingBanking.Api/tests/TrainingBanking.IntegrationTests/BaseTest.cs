namespace TrainingBanking.IntegrationTests
{
    public abstract class BaseTest
    {
        protected TestContext Context;
        protected BaseTest()
        {
            Context = new TestContext();
        }
    }
}
