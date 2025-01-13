using Speakify.Interfaces;

namespace Speakify.Facades
{
        public class RealizationFacade : IActivitySubject
        {
            private readonly List<IActivityObserver> _observers = new();

            public void Attach(IActivityObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IActivityObserver observer)
            {
                _observers.Remove(observer);
            }

            public void NotifyObservers(Models.StudentAccessRequest request)
            {
                foreach (var observer in _observers)
                {
                    observer.Update(request);
                }
            }

            public string RegisterStudentAccess(int activityID, int studentID)
            {
                var request = new Models.StudentAccessRequest
                {
                    ActivityID = activityID,
                    InveniraStdID = studentID
                };

                // Notifica os observers
                NotifyObservers(request);

                return $"https://speakify-u5hk.onrender.com?activity={activityID}&studentID={studentID}";
            }

            public string GenerateActivityUrl(int activityID)
            {
                return $"https://speakify-u5hk.onrender.com?activity={activityID}";
            }
        }
    }
