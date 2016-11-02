using Dominio.Entidades;

namespace Dominio.Interfaces.Repositorios
{
    public interface IRespostaQuestaoRepositorio : IRepositorioBase<RespostaQuestao>
    {
        RespostaQuestao ObtemPorQuestaoAvaliacao(int? pIdQuestao, int? pIdAvaliacao);
    }
}

