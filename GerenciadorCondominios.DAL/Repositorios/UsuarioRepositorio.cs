using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Repositorios
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        private readonly Contexto _contexto;
        private readonly UserManager<Usuario> _gerenciadorUsuario;
        private readonly SignInManager<Usuario> _gerenciadorLogin;

        public UsuarioRepositorio(Contexto contexto, UserManager<Usuario> gerenciadorUsuario, SignInManager<Usuario> gerenciadorLogin) : base(contexto)
        {
            _contexto = contexto;
            _gerenciadorUsuario = gerenciadorUsuario;
            _gerenciadorLogin = gerenciadorLogin;
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            try
            {
                await _gerenciadorUsuario.UpdateAsync(usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string CodificaSenha(Usuario usuario, string senha)
        {
            try
            {
                return _gerenciadorUsuario.PasswordHasher.HashPassword(usuario, senha);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            try
            {
                return await _gerenciadorUsuario.CreateAsync(usuario, senha);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeslogarUsuario()
        {
            try
            {
                await _gerenciadorLogin.SignOutAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao)
        {
            try
            {
                await _gerenciadorUsuario.AddToRoleAsync(usuario, funcao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IdentityResult> IncluirUsuarioEmFuncoes(Usuario usuario, IEnumerable<string> funcoes)
        {
            try
            {
                return await _gerenciadorUsuario.AddToRolesAsync(usuario, funcoes);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            try
            {
                await _gerenciadorLogin.SignInAsync(usuario, lembrar);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<string>> PegarFuncoesUsuario(Usuario usuario)
        {
            try
            {
                return await _gerenciadorUsuario.GetRolesAsync(usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Usuario> PegarUsarioPeloId(string usuarioId)
        {
            try
            {
                return await _gerenciadorUsuario.FindByIdAsync(usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Usuario> PegarUsuarioPeloEmail(string email)
        {
            try
            {
                return await _gerenciadorUsuario.FindByEmailAsync(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Usuario> PegarUsuarioPeloNome(ClaimsPrincipal usuario)
        {
            try
            {
                return await _gerenciadorUsuario.FindByNameAsync(usuario.Identity.Name);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IdentityResult> RemoverFuncoesUsuario(Usuario usuario, IEnumerable<string> funcoes)
        {
            try
            {
                return await _gerenciadorUsuario.RemoveFromRolesAsync(usuario, funcoes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int VerificarSeExisteRegistro()
        {
            try
            {
                return _contexto.Usuarios.Count();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public  async Task<bool> VerificarSeUsuarioEstaEmFuncao(Usuario usuario, string funcao)
        {
            try
            {
                return await _gerenciadorUsuario.IsInRoleAsync(usuario, funcao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
