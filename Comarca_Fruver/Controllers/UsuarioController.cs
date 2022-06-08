using Comarca_Fruver.Data;
using Comarca_Fruver.Models;
using Comarca_Fruver.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace Comarca_Fruver.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inicial(Usuario user)
        {
            int CedIngreso = user.Documento;
            string ClaveIngreso = user.Clave;
            int Id = 0;
            int Coincidencia = 0;
            IEnumerable<Usuario> IdentifyUser = _context.Usuarios;

            foreach(var item in IdentifyUser)
            {
                int Doc = item.Documento;
                if (Doc == CedIngreso)
                {
                    Id = item.UsuarioID;
                    Coincidencia++;
                }
                else if(Coincidencia == 0)
                {
                    Id = 0;
                }
            }

            var Users = _context.Usuarios.Find(Id);

            if (Users == null)
            {
                TempData["Ingreso"] = "Cuenta no encontrada";
                return RedirectToAction("Inicial");
            }
            else if (Users.Clave != ClaveIngreso)
            {
                TempData["Ingreso"] = "Contraseña incorrecta";
                return RedirectToAction("Inicial");
            }
            else if (Users.Clave == ClaveIngreso)
            {
                return RedirectToAction("Listado", "Cargamento");
            }
            else
            {
                TempData["Ingreso"] = "Sistema fuera de operación";
                return RedirectToAction("Inicial");
            }

        }
        //AQUÍ ACABA EL LOGIN

        public IActionResult Listado()
        {

            IEnumerable<UsuarioDto> listaEmpleadoDetalles =
                (from Usuario in _context.Usuarios
                 join Rol in _context.Rol
                 on Usuario.Rol equals
                 Rol.RolID
                 select new UsuarioDto
                 {
                     UsuarioID = Usuario.UsuarioID,
                     Documento = Usuario.Documento,
                     Nombre = Usuario.Nombre,
                     Apellido = Usuario.Apellido,
                     Rol = Rol.NombreRol,
                     Celular = Usuario.Celular,
                     Clave = Usuario.Clave
                 }).ToList();


            return View(listaEmpleadoDetalles);
        }

        public IActionResult Creacion()
        {
            IEnumerable<Rol> RolDisponible = _context.Rol;
            ViewBag.Rol = RolDisponible;
            return View();
        }

        public IActionResult Inicial()
        {
            return View();
        }

        public int Existencia(int Documento)
        {
            int Coincidencia = 0;

            IEnumerable<Usuario> ListaUsuario = _context.Usuarios;

            foreach (var item in ListaUsuario)
            {
                if (item.Documento == Documento)
                {
                    Coincidencia += 1;
                }
            }

            return Coincidencia;
        }

        
        public int RolResultado(string RolName)
        {
            IEnumerable<Rol> rols = _context.Rol;
            int retorno = -1;
            foreach (var item in rols)
            {
                if (RolName != item.NombreRol)
                {
                    retorno = -1;
                }
                else
                {
                    retorno = item.RolID;
                }                
            }
            return retorno;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creacion(UsuarioDto Usua)
        {
            int Docu = Usua.Documento;
            int Coincidencia = Existencia(Docu);

            if (ModelState.IsValid && Coincidencia < 1)
            {
                var UsuRegis = new Usuario();
                
                UsuRegis.Documento= Docu;
                UsuRegis.Nombre=Usua.Nombre;
                UsuRegis.Apellido=Usua.Apellido;
                UsuRegis.Celular=Usua.Celular;
                int RolN = 0;
                IEnumerable<Rol> rols = _context.Rol;
                foreach (var item in rols)
                {
                    if (Usua.Rol != item.NombreRol)
                    {
                       
                    }
                    else
                    {
                        RolN = item.RolID;
                    }
                }
                UsuRegis.Rol= RolN;
                UsuRegis.Clave = Usua.Clave;
                _context.Usuarios.Add(UsuRegis);
                _context.SaveChanges();
                TempData["mensaje"] = "Nuevo usuario registrado";
                return RedirectToAction("Listado");
            }
            else
            {
                TempData["mensaje"] = "El número de documento " + Docu + " ya existe";
                return RedirectToAction("Listado");
            }

        }

        public IActionResult Edicion(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["mensaje"] = "Este item no fue encontrado en los registros";
                return RedirectToAction("Listado");
            }

            var UsuarioPrevio = _context.Usuarios.Find(id);
            var UsuPrevioDto = new UsuarioDto();

            IEnumerable<Rol> rols = _context.Rol;

            if (UsuarioPrevio == null)
            {
                return NotFound();
            }
            else
            {

                UsuPrevioDto.UsuarioID = UsuarioPrevio.UsuarioID;
                UsuPrevioDto.Documento = UsuarioPrevio.Documento;
                UsuPrevioDto.Nombre=UsuarioPrevio.Nombre;
                UsuPrevioDto.Apellido = UsuarioPrevio.Apellido;
                UsuPrevioDto.Celular = UsuarioPrevio.Celular;

                
                foreach (var item in rols)
                {
                    if (UsuarioPrevio.Rol == item.RolID)
                    {
                        UsuPrevioDto.Rol = item.NombreRol;
                    }
                }
                UsuPrevioDto.Clave = UsuarioPrevio.Clave;
            }


            ViewBag.Rol = rols;
            return View(UsuPrevioDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edicion(UsuarioDto UsuDto)
        {

            //Conversión de datos//
            int IdUsuario = UsuDto.UsuarioID;
            var Usuario = _context.Usuarios.Find(IdUsuario);
            Usuario.Documento=UsuDto.Documento;
            Usuario.Nombre = UsuDto.Nombre;
            Usuario.Apellido = UsuDto.Apellido;
            Usuario.Celular = UsuDto.Celular;

            IEnumerable<Rol> rols = _context.Rol;
            foreach (var item in rols)
            {
                if (UsuDto.Rol == item.NombreRol)
                {
                    Usuario.Rol = item.RolID;
                }
            }

            Usuario.Clave = UsuDto.Clave;
            //Cierre de conversión de datos//


            
                _context.Usuarios.Update(Usuario);
                _context.SaveChanges();
                TempData["mensaje"] = "Usuario modificado";
                return RedirectToAction("Listado");
            
            /*
                TempData["mensaje"] = "Problema en la transmisión de la información hacía la nube ";
                return RedirectToAction("Listado");
           */

        }

        public IActionResult Elimina(int? id)
        {
            var Usuario = _context.Usuarios.Find(id);
            return View(Usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Elimina(Usuario User)
        {
            TempData["mensaje"] = "El usuario con documento " + User.Documento + " fue eliminado";
            _context.Remove(User);
            _context.SaveChanges();
            return RedirectToAction("Listado");
        }

        public IActionResult inicial2()
        {
            return View();
        }
    }
}
