namespace Speakify.Facades
{
    public class RealizationFacade
    {
        // Função para gerar URL de atividade
        public string GenerateActivityUrl(int activityID)
        {
            return $"https://speakify-u5hk.onrender.com?activity={activityID}";
        }

        // Função para registar acesso do estudante
        public string RegisterStudentAccess(int activityID, int studentID)
        {
            return $"https://speakify-u5hk.onrender.com?activity={activityID}&studentID={studentID}";
        }
    }
}
