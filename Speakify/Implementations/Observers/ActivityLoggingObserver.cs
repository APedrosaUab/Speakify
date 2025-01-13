using Speakify.Interfaces;

namespace Speakify.Implementations.Observers
{
    public class ActivityLoggingObserver : IActivityObserver
    {
        public void Update(Models.StudentAccessRequest request)
        {
            // Implementação para logging
            Console.WriteLine($"Log: Estudante {request.InveniraStdID} acedeu a atividade {request.ActivityID}");
        }
    }
}
