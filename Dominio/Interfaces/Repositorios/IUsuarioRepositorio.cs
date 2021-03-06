﻿using Dominio.Entidades;
using System.Collections;                              
                                                                     
namespace Dominio.Interfaces.Repositorios            
{                                                                    
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>   
    {
        IEnumerable ObtemUsuariosProfessores();
    }                                                                
}                                                                    

