using Dominio.Entidades;

namespace Dominio.Interfaces.Servicos
{
    public interface IQuestaoServico : IServicoBase<Questao>
    {
        Questao ObtemQuestaoPorId(int? pIdQuestao);
    }
}

