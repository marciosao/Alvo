using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class ProfessorServico : ServicoBase<Professor>, IProfessorServico            
    {                                                                              
        private readonly IProfessorRepositorio _professorRepositorio;                    
                                                                                   
        public ProfessorServico(IProfessorRepositorio professorRepositorio)                
            : base(professorRepositorio)                                              
        {                                                                          
            _professorRepositorio = professorRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

