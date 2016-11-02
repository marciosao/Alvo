using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class RespostaQuestaoRepositorio : RepositorioBase<RespostaQuestao>, IRespostaQuestaoRepositorio
    {
        public RespostaQuestao ObtemPorQuestaoAvaliacao(int? pIdQuestao, int? pIdAvaliacao)
        {
            var lQuestao = Db.RespostaQuestao.FirstOrDefault(x => x.IdQuestao == pIdQuestao && x.IdAvaliacao == pIdAvaliacao);

            return lQuestao;
        }

    }
}

