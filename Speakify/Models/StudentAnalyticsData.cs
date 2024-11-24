namespace Speakify.Models
{
    public class StudentAnalyticsData
    {
        public static List<StudentAnalytics> GetAllAnalytics()
        {
            return new List<StudentAnalytics>
            {
                new StudentAnalytics
                {
                    InveniraStdID = 1001,
                    ActivityID = 1,
                    QuantAnalytics = new List<QuantitativeAnalytic>
                    {
                        new QuantitativeAnalytic { Name = "Tempo total dedicado", Value = 120.5 },
                        new QuantitativeAnalytic { Name = "Número de atividades concluídas", Value = 5 },
                        new QuantitativeAnalytic { Name = "Pontuação média", Value = 85.5 },
                        new QuantitativeAnalytic { Name = "Número de tentativas", Value = 3 },
                        new QuantitativeAnalytic { Name = "Frequência de acesso", Value = 10 }
                    },
                    QualAnalytics = new List<QualitativeAnalytic>
                    {
                        new QualitativeAnalytic { Name = "Comentários sobre o progresso", Value = "Ótimo desempenho!" },
                        new QualitativeAnalytic { Name = "Sugestões para melhoria", Value = "Focar em vocabulário avançado." },
                        new QualitativeAnalytic { Name = "Feedback qualitativo do aluno", Value = "Demonstrou grande interesse e dedicação." }
                    }
                },
                new StudentAnalytics
                {
                    InveniraStdID = 1002,
                    ActivityID = 1,
                    QuantAnalytics = new List<QuantitativeAnalytic>
                    {
                        new QuantitativeAnalytic { Name = "Tempo total dedicado", Value = 90.0 },
                        new QuantitativeAnalytic { Name = "Número de atividades concluídas", Value = 3 },
                        new QuantitativeAnalytic { Name = "Pontuação média", Value = 70.0 },
                        new QuantitativeAnalytic { Name = "Número de tentativas", Value = 2 },
                        new QuantitativeAnalytic { Name = "Frequência de acesso", Value = 7 }
                    },
                    QualAnalytics = new List<QualitativeAnalytic>
                    {
                        new QualitativeAnalytic { Name = "Comentários sobre o progresso", Value = "Progresso moderado." },
                        new QualitativeAnalytic { Name = "Sugestões para melhoria", Value = "Praticar mais exercícios de conversação." },
                        new QualitativeAnalytic { Name = "Feedback qualitativo do aluno", Value = "Pode melhorar o ritmo de aprendizagem." }
                    }
                }
            };
        }
    }
}

