﻿using PoC.TesteAutomatizado.Interface.Processo;
using PoC.TesteAutomatizado.Interface.Repositorio;
using PoC.TesteAutomatizado.Processo;
using PoC.TesteAutomatizado.Repositorio;
using PoC.TesteAutomatizado.Repositorio.Moq;
using SimpleInjector;

namespace PoC.TesteAutomatizado.InjetorDependencias
{
    public static class InjetorDependencias
    {
        private static Container _container;

        public static void Iniciar()
        {
            if (_container != null)
                _container.Dispose();

            _container = new Container();

            _container.Register<IContratoRepositorio, ContratoRepositorio>();
            _container.Register<IPedidoRepositorio, PedidoRepositorio>();

            _container.Register<IContratoProcesso, ContratoProcesso>();
            _container.Register<IPedidoProcesso, PedidoProcesso>();

            _container.Verify();
        }

        public static void IniciarMoq()
        {
            if (_container != null)
                _container.Dispose();

            _container = new Container();

            _container.Register<IContratoRepositorio, ContratoRepositorioMoq>();
            _container.Register<IPedidoRepositorio, PedidoRepositorioMoq>();

            _container.Register<IContratoProcesso, ContratoProcesso>();
            _container.Register<IPedidoProcesso, PedidoProcesso>();

            _container.Verify();
        }

        public static T ObterInstancia<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public static Container Container
        {
            get
            {
                return _container;
            }
        }
    }
}
