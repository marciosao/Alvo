﻿using Dominio.Entidades;
using System.Collections;                                 
                                                                           
namespace Aplicacao.Interfaces                           
{                                                                          
    public interface IUsuarioAppServico : IAppServicoBase<Usuario>         
    {
        IEnumerable ObtemUsuariosProfessores();
        Usuario AutenticarUsuario(Usuario pUsuario);
        Usuario AlterarSenha(Usuario lUsuario, string novaSenha);

        void GravarUsuario(Usuario lUsuario);
    }                                                                      
}                                                                          

