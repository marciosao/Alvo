using Dominio.Entidades;

namespace Dominio.Interfaces.Repositorios
{
    public interface IQuestaoRepositorio : IRepositorioBase<Questao>
    {
        Questao ObtemQuestaoPorId(int? pIdQuestao);
    }
}

