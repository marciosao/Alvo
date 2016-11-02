using Dominio.Entidades;

namespace Aplicacao.Interfaces
{
    public interface IQuestaoAppServico : IAppServicoBase<Questao>
    {
        Questao ObtemQuestaoPorId(int? pIdQuestao);
    }
}

