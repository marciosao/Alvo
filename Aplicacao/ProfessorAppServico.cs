using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class ProfessorAppServico : AppServicoBase<Professor>, IProfessorAppServico         
    {                                                                                    
        private readonly IProfessorServico _professorServico;                                
                                                                                         
        public ProfessorAppServico(IProfessorServico professorServico)
            : base(professorServico)                                                        
        {
            _professorServico = professorServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

