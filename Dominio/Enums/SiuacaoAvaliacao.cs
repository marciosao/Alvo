using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Enums
{
    /// <summary>
    /// Domínio Fixo: SiuacaoAvaliacao
    /// </summary>
    public enum SiuacaoAvaliacao
    {
        /// <summary>
        /// Pendente Etapa II Secretaria
        /// </summary>
        PendenteEtapaIISecretaria = 1,

        /// <summary>
        /// Pendente Etapa II Professor
        /// </summary>
        PendenteEtapaIIProfessor = 2,

        /// <summary>
        /// Pendente Etapa III
        /// </summary>
        PendenteEtapaIII = 3,

        /// <summary>
        /// Concluída
        /// </summary>
        Concluida = 4,
    }
}
