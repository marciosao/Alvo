using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class QuestaoRepositorio : RepositorioBase<Questao>, IQuestaoRepositorio
    {
        public Questao ObtemQuestaoPorId(int? pIdQuestao)
        {

            var lQuestao = Db.Questao.Find((pIdQuestao!=null)?pIdQuestao:0);

            return lQuestao;
        }

    }
}

