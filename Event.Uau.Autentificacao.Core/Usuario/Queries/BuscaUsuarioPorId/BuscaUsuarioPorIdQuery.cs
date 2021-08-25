using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Autenticacao.Core.Usuario.Queries.BuscaUsuarioPorId
{
    public class BuscaUsuarioPorIdQuery : EventUauRequest<ViewModel.Autenticacao.UsuarioViewModel>
    {
        public int IdUsuario { get; set; }
    }
}
