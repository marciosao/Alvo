using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;
using System;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class AvaliacaoAppServico : AppServicoBase<Avaliacao>, IAvaliacaoAppServico         
    {                                                                                    
        private readonly IAvaliacaoServico _avaliacaoServico;
        private readonly IRespostaQuestaoServico _respostaQuestaoServico;

        public AvaliacaoAppServico(IAvaliacaoServico avaliacaoServico, IRespostaQuestaoServico respostaQuestaoServico)
            : base(avaliacaoServico)                                                        
        {
            _avaliacaoServico = avaliacaoServico;
            _respostaQuestaoServico = respostaQuestaoServico;
        }

        
        public void GravarRespostasAvaliacao(Avaliacao lAvaliacao)
        {
            var lIdAvaliacao = _avaliacaoServico.ObtemPorId(lAvaliacao.Id);
            decimal lNotaFinal = 0;

            foreach (var lRowResposta in lAvaliacao.RespostaQuestao)
            {
                _respostaQuestaoServico.Add(lRowResposta);
                if (!string.IsNullOrEmpty(lRowResposta.ValorResposta))
                {
                    lNotaFinal += Decimal.Parse(lRowResposta.ValorResposta);
                }
            }

            lIdAvaliacao.NotaFinal = lNotaFinal;
            lIdAvaliacao.Concluido = true;
            lIdAvaliacao.DataAvaliacao = DateTime.Now.Date;

            _avaliacaoServico.Update(lIdAvaliacao);
        }
    }                                                                                    
}                                                                                        

