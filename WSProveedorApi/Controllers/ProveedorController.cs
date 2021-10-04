using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSProveedorApi.Classes;
using WSProveedorApi.Models;

namespace WSProveedorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProveedorController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            List<ProveedorCLS> listaProveedor = new List<ProveedorCLS>();
            using (BDProveedorContext db = new BDProveedorContext())
            {
                listaProveedor = (from proveedor in db.Proveedor
                                  where proveedor.Bhabilitado == 1
                                  select new ProveedorCLS { 
                                   iidproveedor = proveedor.Iidproveedor,
                                   nombre = proveedor.Nombre,
                                   telefono = proveedor.Telefono,
                                   direccion = proveedor.Direccion,
                                   empresa = proveedor.Empresa
                                  
                                  }).ToList();
            }


                return Ok(listaProveedor);
        }

        [HttpPost]
        public IActionResult add(ProveedorCLS oproveedorCLS)
        {
            try
            {
                List<ProveedorCLS> listaProveedor = new List<ProveedorCLS>();
                using (BDProveedorContext db = new BDProveedorContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return Ok(oproveedorCLS);
                    }
                    else
                    {
                        Proveedor obj = new Proveedor();
                        obj.Nombre = oproveedorCLS.nombre;
                        obj.Telefono = oproveedorCLS.telefono;
                        obj.Direccion = oproveedorCLS.direccion;
                        obj.Empresa = oproveedorCLS.empresa;
                        obj.Bhabilitado = 1;
                        db.Proveedor.Add(obj);
                        db.SaveChanges();

                    }
                }
            }
            catch(Exception)
            {
                return Ok(oproveedorCLS);
            }
            return Ok(oproveedorCLS);

        }


        [HttpPut]
        public IActionResult Edit(ProveedorCLS OproveedorCSL)
        {
            string error;
            try
            {
                ProveedorCLS editProveedor = new ProveedorCLS();
                using (BDProveedorContext db = new BDProveedorContext())
                {

                    Proveedor obj = db.Proveedor.Find(OproveedorCSL.iidproveedor);
                    obj.Nombre = OproveedorCSL.nombre;
                    obj.Telefono = OproveedorCSL.telefono;
                    obj.Direccion = OproveedorCSL.direccion;
                    obj.Empresa = OproveedorCSL.empresa;
                    obj.Bhabilitado = 1;
                    db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Ok(OproveedorCSL);
        
        }
        
        [HttpDelete]
        public IActionResult delete(ProveedorCLS oProveedorCLS)
        {
            string error;
            try
            {
                using (BDProveedorContext db = new BDProveedorContext())
                {
                    Proveedor Oproveedor = db.Proveedor.Where(p => p.Iidproveedor == oProveedorCLS.iidproveedor).First();
                    db.Proveedor.Remove(Oproveedor);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
            return Ok(oProveedorCLS);
        }

       
    }
}
