using Microsoft.AspNetCore.Mvc;
using Dominio;
using Servicios;
using BancoUsuariosWebApp.Models;
using BCrypt.Net;

namespace BancoUsuariosWebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IServicioUsuario _servicioUsuario;
        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        // GET: UsuarioController
        public ActionResult Index(string nombre = "")
        {
            var usuariosDTO = _servicioUsuario.TraerPorNombre(nombre);
            var viewModel = new UsuarioIndexViewModel()
            {
                Usuarios = usuariosDTO
            };
            return View(viewModel);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create

        private UsuarioFormViewModel FormDefaultUsuarioViewModel()
        {
            return new UsuarioFormViewModel();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(FormDefaultUsuarioViewModel());
        }

        // POST: UsuarioController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioFormViewModel form)
        {
            try
            {
                UsuarioDTO usuarioDTO = form.CrearUsuarioDTO();
                _servicioUsuario.Add(usuarioDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View(form);
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuarioDTO = _servicioUsuario.Get(id);
            if (usuarioDTO == null)
            {// Si no se encuentra el usuario, redirigir a una página de error o retornar un error 404
                return NotFound();
            }
            var usuarioViewModel = new UsuarioFormViewModel(usuarioDTO);
            return View(usuarioViewModel);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioFormViewModel usuario)
        {
            try
            {
                var usuarioDTO = _servicioUsuario.Get(id);
                if (usuarioDTO == null)
                {
                    ViewBag.Message = "Usuario no encontrado.";
                    return View(usuario);
                }

                bool updated = false;
                if (usuario.Nombre != usuarioDTO.Nombre)
                {
                    usuarioDTO.Nombre = usuario.Nombre;
                    updated = true;
                }
                if (usuario.Apellido != usuarioDTO.Apellido)
                {
                    usuarioDTO.Apellido = usuario.Apellido;
                    updated = true;
                }
                if (usuario.Email != usuarioDTO.Email)
                {
                    usuarioDTO.Email = usuario.Email;
                    updated = true;
                }

                if (updated)
                {
                    _servicioUsuario.Update(id, usuarioDTO);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                // Proporciona información más detallada, idealmente con logging en lugar de mostrar directamente en la vista.
                ViewBag.Message = "Error al actualizar el usuario: " + e.Message;
                return View(usuario);
            }
        }
        public ActionResult Delete(int id)
        {
            _servicioUsuario.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
