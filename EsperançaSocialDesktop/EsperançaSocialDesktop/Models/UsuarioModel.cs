namespace EsperancaSocial.Desktop.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string SenhaHash { get; set; }
        public string NivelAcesso { get; set; }
        public bool Ativo { get; set; }
    }
}
