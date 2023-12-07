using Hangfire;

namespace ProductApi.Servises
{
    public interface ICustomer
    {
        Task GetAll();
    }
    public class CustomerServise : ICustomer
    {
        public Task GetAll()
        {
            BackgroundJob.ContinueJobWith(
         "",
         () => Console.WriteLine("Continuation!"));

            RecurringJob.AddOrUpdate(
                "myrecurringjob",
                () => Console.WriteLine("Recurring!"),
                Cron.Minutely);
            var jobId = BackgroundJob.Enqueue(
    () => Console.WriteLine("Fire-and-forget!"));
            return Task.CompletedTask;
        }
    }

}
