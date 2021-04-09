using Landing_page.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landing_page.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        
        // GET: Home/Details/5
        public ActionResult Details(int id_vendedor)
        {
            ActualizacionVendedor av = new ActualizacionVendedor();
            Vendedor ven = av.Recuperar(id_vendedor);
            return View(ven);
        }
        
        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ActualizacionVendedor av = new ActualizacionVendedor();
            Vendedor ven = new Vendedor
            {
                //Id_vendedor = int.Parse(collection["id_vendedor"].ToString()),
                Nombre_tienda = collection["nombre_tienda"].ToString(),
                Categoria_tienda = collection["categoria_tienda"].ToString(),
                Nombres_vendedor = collection["nombres_vendedor"].ToString(),
                Apellidos_vendedor = collection["apellidos_vendedor"].ToString(),
                Correo_vendedor = collection["correo_vendedor"].ToString(),
                Celular_vendedor = collection["celular_vendedor"].ToString()
            };
            av.Alta(ven);
            return RedirectToAction("Index");
        }
        
        // GET: Home/Edit/5
        public ActionResult Edit(int id_usuario)
        {
            ActualizacionVendedor av = new ActualizacionVendedor();
            Vendedor ven = av.Recuperar(id_usuario);
            return View(ven);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id_vendedor, FormCollection collection)
        {
            ActualizacionVendedor av = new ActualizacionVendedor();
            Vendedor ven = new Vendedor
            {
                Id_vendedor = id_vendedor,
                Nombre_tienda = collection["nombre_tienda"].ToString(),
                Categoria_tienda = collection["categoria_tienda"].ToString(),
                Nombres_vendedor = collection["nombres_vendedor"].ToString(),
                Apellidos_vendedor = collection["apellidos_vendedor"].ToString(),
                Correo_vendedor = collection["correo_vendedor"].ToString(),
                Celular_vendedor = collection["celular_vendedor"].ToString()
            };
            av.Modificar(ven);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id_vendedor)
        {
            ActualizacionVendedor av = new ActualizacionVendedor();
            Vendedor ven = av.Recuperar(id_vendedor);
            return View(ven);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id_vendedor, FormCollection collection)
        {
            ActualizacionVendedor av = new ActualizacionVendedor();
            av.Borrar(id_vendedor);
            return RedirectToAction("Index");
        }
        public ActionResult Listado()
        {
            ActualizacionVendedor av = new ActualizacionVendedor();
            return View(av.RecuperarTodos());
        }

    }
}
