using Speakify.Interfaces;

namespace Speakify.Implementations.Observers
{
    public class ActivityAnalyticsObserver : IActivityObserver
    {
        private readonly Facades.AnalyticsFacade _analyticsFacade;

        public ActivityAnalyticsObserver(Facades.AnalyticsFacade analyticsFacade)
        {
            _analyticsFacade = analyticsFacade;
        }

        public void Update(Models.StudentAccessRequest request)
        {
            // Implementação para atualizar analytics
            Console.WriteLine($"Analytics atualizados para atividade {request.ActivityID}");
        }
    }
}