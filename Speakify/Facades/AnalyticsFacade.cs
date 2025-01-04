using Speakify.Interfaces;
using Speakify.Models;

namespace Speakify.Facades
{
    public class AnalyticsFacade
    {
        private readonly IParameterFactory _parameterFactory;

        public AnalyticsFacade(IParameterFactory parameterFactory)
        {
            _parameterFactory = parameterFactory;
        }

        // Função para obter lista de analytics
        public object GetAnalyticsList()
        {
            return new
            {
                quantAnalytics = new[]
                {
                    _parameterFactory.CreateAnalytics("Tempo total dedicado", "quantitative"),
                    _parameterFactory.CreateAnalytics("Número de atividades concluídas", "quantitative"),
                    _parameterFactory.CreateAnalytics("Pontuação média", "quantitative"),
                    _parameterFactory.CreateAnalytics("Número de tentativas", "quantitative"),
                    _parameterFactory.CreateAnalytics("Frequência de acesso", "quantitative")
                },
                qualAnalytics = new[]
                {
                    _parameterFactory.CreateAnalytics("Comentários sobre o progresso", "qualitative"),
                    _parameterFactory.CreateAnalytics("Sugestões para melhoria", "qualitative"),
                    _parameterFactory.CreateAnalytics("Feedback qualitativo do aluno", "qualitative"),
                }
            };
        }

        // Função para obter analytics de uma atividade específica ou de todas se Id da actividade for nulo
        public List<StudentAnalytics> GetActivityAnalytics(int? activityID)
        {
            var allAnalytics = StudentAnalyticsData.GetAllAnalytics();
            if (activityID != null)
            {
                return allAnalytics
                    .Where(analytics => analytics.ActivityID == activityID)
                    .ToList();
            }
            return allAnalytics;
        }
    }
}
