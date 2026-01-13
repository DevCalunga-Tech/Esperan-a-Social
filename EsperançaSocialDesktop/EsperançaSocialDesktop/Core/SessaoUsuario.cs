using EsperancaSocial.Desktop.Models;

namespace EsperancaSocial.Desktop.Core
{
    public static class SessaoUsuario
    {
        public static UsuarioModel UsuarioLogado { get; set; }

        public static bool EstaAutenticado()
        {
            return UsuarioLogado != null;
        }

        public static void EncerrarSessao()
        {
            UsuarioLogado = null;
        }
    }
}
