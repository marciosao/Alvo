[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Alvo.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Alvo.App_Start.NinjectWebCommon), "Stop")]

namespace Alvo.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Dominio;
    using Dominio.Interfaces.Repositorios;
    using Dominio.Interfaces.Servicos;

    using Aplicacao;
    using Aplicacao.Interfaces;
    using Dominio.Servicos;
    using Infra.Data.Repositorios;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServicoBase<>)).To(typeof(AppServicoBase<>));
            kernel.Bind<IAreaConcentracaoAppServico>().To<AreaConcentracaoAppServico>();
            kernel.Bind<IAvaliacaoAppServico>().To<AvaliacaoAppServico>();
            kernel.Bind<IAvaliacaoQuestionarioAppServico>().To<AvaliacaoQuestionarioAppServico>();
            kernel.Bind<ICandidatoAppServico>().To<CandidatoAppServico>();
            kernel.Bind<ICandidatoProcessoSeletivoAppServico>().To<CandidatoProcessoSeletivoAppServico>();
            kernel.Bind<ICategoriaQuestaoAppServico>().To<CategoriaQuestaoAppServico>();
            kernel.Bind<IGrupoQuestaoAppServico>().To<GrupoQuestaoAppServico>();
            kernel.Bind<IMenuAppServico>().To<MenuAppServico>();
            kernel.Bind<IOpcaoQuestaoAppServico>().To<OpcaoQuestaoAppServico>();
            kernel.Bind<IPerfilAppServico>().To<PerfilAppServico>();
            kernel.Bind<IPerfilMenuAppServico>().To<PerfilMenuAppServico>();
            kernel.Bind<IProcessoSeletivoAppServico>().To<ProcessoSeletivoAppServico>();
            kernel.Bind<IQuestaoAppServico>().To<QuestaoAppServico>();
            kernel.Bind<IQuestionarioAppServico>().To<QuestionarioAppServico>();
            kernel.Bind<IRespostaQuestaoAppServico>().To<RespostaQuestaoAppServico>();
            kernel.Bind<ITipoQuestaoAppServico>().To<TipoQuestaoAppServico>();
            kernel.Bind<IUsuarioAppServico>().To<UsuarioAppServico>();
            kernel.Bind<IEtapaAppServico>().To<EtapaAppServico>();

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind<IAreaConcentracaoServico>().To<AreaConcentracaoServico>();
            kernel.Bind<IAvaliacaoServico>().To<AvaliacaoServico>();
            kernel.Bind<IAvaliacaoQuestionarioServico>().To<AvaliacaoQuestionarioServico>();
            kernel.Bind<ICandidatoServico>().To<CandidatoServico>();
            kernel.Bind<ICandidatoProcessoSeletivoServico>().To<CandidatoProcessoSeletivoServico>();
            kernel.Bind<ICategoriaQuestaoServico>().To<CategoriaQuestaoServico>();
            kernel.Bind<IGrupoQuestaoServico>().To<GrupoQuestaoServico>();
            kernel.Bind<IMenuServico>().To<MenuServico>();
            kernel.Bind<IOpcaoQuestaoServico>().To<OpcaoQuestaoServico>();
            kernel.Bind<IPerfilServico>().To<PerfilServico>();
            kernel.Bind<IPerfilMenuServico>().To<PerfilMenuServico>();
            kernel.Bind<IProcessoSeletivoServico>().To<ProcessoSeletivoServico>();
            kernel.Bind<IQuestaoServico>().To<QuestaoServico>();
            kernel.Bind<IQuestionarioServico>().To<QuestionarioServico>();
            kernel.Bind<IRespostaQuestaoServico>().To<RespostaQuestaoServico>();
            kernel.Bind<ITipoQuestaoServico>().To<TipoQuestaoServico>();
            kernel.Bind<IUsuarioServico>().To<UsuarioServico>();
            kernel.Bind<IEtapaServico>().To<EtapaServico>();

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<IAreaConcentracaoRepositorio>().To<AreaConcentracaoRepositorio>();
            kernel.Bind<IAvaliacaoRepositorio>().To<AvaliacaoRepositorio>();
            kernel.Bind<IAvaliacaoQuestionarioRepositorio>().To<AvaliacaoQuestionarioRepositorio>();
            kernel.Bind<ICandidatoRepositorio>().To<CandidatoRepositorio>();
            kernel.Bind<ICandidatoProcessoSeletivoRepositorio>().To<CandidatoProcessoSeletivoRepositorio>();
            kernel.Bind<ICategoriaQuestaoRepositorio>().To<CategoriaQuestaoRepositorio>();
            kernel.Bind<IGrupoQuestaoRepositorio>().To<GrupoQuestaoRepositorio>();
            kernel.Bind<IMenuRepositorio>().To<MenuRepositorio>();
            kernel.Bind<IOpcaoQuestaoRepositorio>().To<OpcaoQuestaoRepositorio>();
            kernel.Bind<IPerfilRepositorio>().To<PerfilRepositorio>();
            kernel.Bind<IPerfilMenuRepositorio>().To<PerfilMenuRepositorio>();
            kernel.Bind<IProcessoSeletivoRepositorio>().To<ProcessoSeletivoRepositorio>();
            kernel.Bind<IQuestaoRepositorio>().To<QuestaoRepositorio>();
            kernel.Bind<IQuestionarioRepositorio>().To<QuestionarioRepositorio>();
            kernel.Bind<IRespostaQuestaoRepositorio>().To<RespostaQuestaoRepositorio>();
            kernel.Bind<ITipoQuestaoRepositorio>().To<TipoQuestaoRepositorio>();
            kernel.Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
            kernel.Bind<IEtapaRepositorio>().To<EtapaRepositorio>();
        }        
    }
}
