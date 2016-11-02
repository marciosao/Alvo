using Dominio.Entidades;

namespace Dominio.Interfaces.Servicos
{
    public interface IRespostaQuestaoServico : IServicoBase<RespostaQuestao>
    {
        RespostaQuestao ObtemPorQuestaoAvaliacao(int? pIdQuestao, int? pIdAvaliacao);
    }
}

