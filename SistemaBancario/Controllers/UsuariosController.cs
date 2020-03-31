using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaBancario.Controllers
{
    public class UsuariosController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CrearEmpleado()
        {
            return View();
        }

        public IActionResult CrearCliente()
        {
            return View();
        }
      

        /* CONEXION A LA BASE DE DATOS*/
        void connectionString()
        {
            con.ConnectionString = "Data Source=sql5052.site4now.net;User ID=DB_A56E4E_CoopITLA_admin;Password=CoopITLA2020";
        }
        [HttpPost]

        /* CREAR USUARIOS CLIENTE Y EMPLEADO*/
        public void CrearUsuario(RegistroUsuario ru)
        {
           
            connectionString();
            con.Open();
            com.Connection = con;

            if (ru.nombreEmpleado == null)
            {
                com.CommandText = "EXEC REGISTRAR_CLIENTE '" + ru.cedulaCliente + "', '" + ru.nombreCliente + "', '" + ru.apellidoCliente + "', '" + ru.sexoCliente + "', '" + ru.telefonoCliente + "', '" + ru.direccionCliente + "', '" + ru.numeroCuentaCliente + "', '" + ru.fechaNacimientoCliente + "', " + int.Parse(ru.salarioCliente) + ", '" + ru.usuarioCliente + "', '" + ru.contrasenaCliente + "', " + int.Parse(ru.ahorroCliente) + ", '" + (ru.cedulaFamiliarCliente) + "', '" + (ru.nombreFamiliarCliente) + "', '" + (ru.apellidoFamiliarCliente) + "', '" + (ru.parentescoCliente) + "'";
                try
                {
                dr = com.ExecuteReader();
                con.Close();
                Response.Redirect("ListadoClientes");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex;
                }
            }
            else
            {
                com.CommandText = "EXEC REGISTRAR_EMPLEADO '" + ru.cedulaEmpleado + "', '" + ru.nombreEmpleado + "', '" + ru.apellidoEmpleado + "', '" + ru.sexoEmpleado + "', '" + ru.telefonoEmpleado + "', '" + ru.direccionEmpleado + "','" + ru.fechaNacimientoEmpleado + "','" + ru.cargoEmpleado + "', '" + ru.numeroCuentaEmpleado + "'," + int.Parse(ru.salarioEmpleado) + ", '" + ru.usuarioEmpleado + "', '" + ru.contrasenaEmpleado + "'";
                try
                {
                    dr = com.ExecuteReader();
                    con.Close();
                    Response.Redirect("ListadoEmpleados");
                }
                catch (Exception ex)
                {
                    
                    ViewBag.Error = ex;
                    Response.Redirect("CrearEmpleado");
                    
                }
            }
        }

        /* Funcion para editar informacion de usuario*/
        public void updateUsuario(ListadoUsuarios lu)
        {
            connectionString();
            con.Open();
            com.Connection = con;

            if (lu.nombreEmpleado == null)
            {
                com.CommandText = "EXEC UPDATE_CLIENTE " + int.Parse(lu.idCliente) + ",'" + lu.cedulaCliente + "', '" + lu.nombreCliente + "', '" + lu.apellidoCliente + "', '" + lu.sexoCliente + "', '" + lu.telefonoCliente + "', '" + lu.direccionCliente + "', '" + lu.numeroCuentaCliente + "', '" + lu.fechaNacimientoCliente + "', " + int.Parse(lu.salarioCliente) + ", '" + lu.usuarioCliente + "', '" + lu.contrasenaCliente + "', " + int.Parse(lu.ahorroCliente) + ", '" + lu.estatusCliente + "', '" + (lu.cedulaFamiliarCliente) + "', '" + (lu.nombreFamiliarCliente) + "', '" + (lu.apellidoFamiliarCliente) + "', '" + (lu.parentescoCliente) + "'";
                dr = com.ExecuteReader();
                Response.Redirect("../Usuarios/ListadoClientes");
            }
            else
            {
                com.CommandText = "EXEC UPDATE_EMPLEADO " + int.Parse(lu.idEmpleado) + ",'" + lu.cedulaEmpleado + "', '" + lu.nombreEmpleado + "', '" + lu.apellidoEmpleado + "', '" + lu.sexoEmpleado + "', '" + lu.telefonoEmpleado + "', '" + lu.direccionEmpleado + "','" + lu.fechaNacimientoEmpleado + "','" + lu.cargoEmpleado + "','" + lu.estatusEmpleado + "', '" + lu.numeroCuentaEmpleado + "', " + int.Parse(lu.salarioEmpleado) + ", '" + lu.usuarioEmpleado + "', '" + lu.contrasenaEmpleado + "'";
                dr = com.ExecuteReader();
                Response.Redirect("../Usuarios/ListadoEmpleados");
            }
        }

        /*---------------------------------------------------------------ACCIONES PARA USUARIO CLIENTE---------------------------------------------------------------*/

        /* CONTROLADOR DE VISTA DE LISTA DE CLIENTES*/
        public IActionResult ListadoClientes()
        {
            List<ListadoUsuarios> clienteLista = new List<ListadoUsuarios>();
            clienteLista = ListaClientes().ToList();
            return View(clienteLista);
        }

        /* SELECT TODOS LOS CLIENTES PARA VISUALIZACION*/
        public IEnumerable<ListadoUsuarios> ListaClientes()
        {

            List<ListadoUsuarios> clienteLista = new List<ListadoUsuarios>();

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM CLIENTES";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListadoUsuarios cliente = new ListadoUsuarios();
                cliente.idCliente = dr["ID_Cliente"].ToString();
                cliente.cedulaCliente = dr["Cedula"].ToString();
                cliente.nombreCliente = dr["Nombre"].ToString();
                cliente.apellidoCliente = dr["Apellido"].ToString();
                cliente.fechaNacimientoCliente = dr["FechaNacimiento"].ToString();
                cliente.sexoCliente = dr["Sexo"].ToString();
                cliente.direccionCliente = dr["Direccion"].ToString();
                cliente.telefonoCliente = dr["Telefono"].ToString();
                cliente.usuarioCliente = dr["Usuario"].ToString();
                cliente.contrasenaCliente = dr["Contrasena"].ToString();
                cliente.salarioCliente = dr["salario"].ToString();
                cliente.numeroCuentaCliente = dr["cuentaBancaria"].ToString();
                cliente.ahorroCliente = dr["DescuentoMensual"].ToString();
                cliente.fechaRegistroCliente = dr["FechaRegistro"].ToString();
                cliente.estatusCliente = dr["Estatus"].ToString();
                cliente.cedulaFamiliarCliente = dr["CedulaFamiliar"].ToString();
                cliente.nombreFamiliarCliente = dr["nombreFamiliar"].ToString();
                cliente.apellidoFamiliarCliente = dr["ApellidoFamiliar"].ToString();
                cliente.parentescoCliente = dr["Parentesco"].ToString();

                clienteLista.Add(cliente);
            }
            con.Close();
            return clienteLista;
        }

        /* CONTROLADOR DE VISTA PARA EDITAR CLIENTE. RECIBE INFORMACION BY ID*/
        public IActionResult EditarCliente(int id)
        {
            ListadoUsuarios clienteInfo = new ListadoUsuarios();
            clienteInfo = infoCliente(id);
            return View(clienteInfo);
        }

        /*Vista para ver infoRmacion general de cliente. Recibe datos de empleado por medio de ID*/
        public IActionResult InformacionCliente(int id)
        {
            ListadoUsuarios clienteInfo = new ListadoUsuarios();
            clienteInfo = infoCliente(id);
            return View(clienteInfo);
        }


        /* SELECT INFO DE CLIENTE BY ID*/
        public ListadoUsuarios infoCliente(int id)
        {
            ListadoUsuarios Info = new ListadoUsuarios();
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM CLIENTES where ID_CLIENTE = " + id + "";
            dr = com.ExecuteReader();

            while (dr.Read())
            {     
                Info.idCliente = dr["ID_Cliente"].ToString();
                Info.cedulaCliente = dr["Cedula"].ToString();
                Info.nombreCliente = dr["Nombre"].ToString();
                Info.apellidoCliente = dr["Apellido"].ToString();
                Info.fechaNacimientoCliente = dr["FechaNacimiento"].ToString();
                Info.sexoCliente = dr["Sexo"].ToString();
                Info.direccionCliente = dr["Direccion"].ToString();
                Info.telefonoCliente = dr["Telefono"].ToString();
                Info.usuarioCliente = dr["Usuario"].ToString();
                Info.contrasenaCliente = dr["Contrasena"].ToString();
                Info.salarioCliente = dr["salario"].ToString();
                Info.numeroCuentaCliente = dr["cuentaBancaria"].ToString();
                Info.ahorroCliente = dr["DescuentoMensual"].ToString();
                Info.fechaRegistroCliente = dr["FechaRegistro"].ToString();
                Info.estatusCliente = dr["Estatus"].ToString();
                Info.cedulaFamiliarCliente = dr["CedulaFamiliar"].ToString();
                Info.nombreFamiliarCliente = dr["nombreFamiliar"].ToString();
                Info.apellidoFamiliarCliente = dr["ApellidoFamiliar"].ToString();
                Info.parentescoCliente = dr["Parentesco"].ToString();
            }
            con.Close();
            return Info;
        }


        /*ELIMINAR CLIENTE BY ID*/
        public void EliminarCliente(int id)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "DELETE FROM CLIENTES WHERE ID_CLIENTE =" + id + "";
            dr = com.ExecuteReader();

            con.Close();
            Response.Redirect("../ListadoClientes");

        }



        /* vISTA INFO DE CLIENTE BY CELDULA PARA LISTADO*/
        public IActionResult BuscarCliente(BuscarUsuario bu)
        {
            ListadoUsuarios lu = new ListadoUsuarios();

            lu = ClienteBuscar(bu.cedula);

            return View(lu);
        }

        /* SELECT INFO DE CLIENTE BY CELDULA PARA LISTADO*/
        public ListadoUsuarios ClienteBuscar(string cedula)
        {
            ListadoUsuarios Info = new ListadoUsuarios();
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM CLIENTES where Cedula = '" + cedula + "'";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                Info.idCliente = dr["ID_Cliente"].ToString();
                Info.cedulaCliente = dr["Cedula"].ToString();
                Info.nombreCliente = dr["Nombre"].ToString();
                Info.apellidoCliente = dr["Apellido"].ToString();
                Info.fechaNacimientoCliente = dr["FechaNacimiento"].ToString();
                Info.sexoCliente = dr["Sexo"].ToString();
                Info.direccionCliente = dr["Direccion"].ToString();
                Info.telefonoCliente = dr["Telefono"].ToString();
                Info.usuarioCliente = dr["Usuario"].ToString();
                Info.contrasenaCliente = dr["Contrasena"].ToString();
                Info.salarioCliente = dr["salario"].ToString();
                Info.numeroCuentaCliente = dr["cuentaBancaria"].ToString();
                Info.ahorroCliente = dr["DescuentoMensual"].ToString();
                Info.fechaRegistroCliente = dr["FechaRegistro"].ToString();
                Info.estatusCliente = dr["Estatus"].ToString();
                Info.cedulaFamiliarCliente = dr["CedulaFamiliar"].ToString();
                Info.nombreFamiliarCliente = dr["nombreFamiliar"].ToString();
                Info.apellidoFamiliarCliente = dr["ApellidoFamiliar"].ToString();
                Info.parentescoCliente = dr["Parentesco"].ToString();
            }
            con.Close();
            return Info;
        }











        /*---------------------------------------------------------------ACCIONES PARA USUARIO EMPLEADO---------------------------------------------------------------*/

        /*Vista para editar empleado. Recibe datos de empleado por medio de ID*/
        public IActionResult EditarEmpleado(int id)
        {
            ListadoUsuarios empleadoInfo = new ListadoUsuarios();
            empleadoInfo = infoEmpledo(id);
            return View(empleadoInfo);
        }

        /*Vista para ver informacion general de empleado. Recibe datos de empleado por medio de ID*/
        public IActionResult InformacionEmpleado(int id)
        {
            ListadoUsuarios empleadoInfo = new ListadoUsuarios();
            empleadoInfo = infoEmpledo(id);
            return View(empleadoInfo);
        }

        /* SELECT INFO DE EMPLEADO BY ID*/
        public ListadoUsuarios infoEmpledo(int id)
        {
            ListadoUsuarios Info = new ListadoUsuarios();
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM EMPLEADOS where ID_EMPLEADO = " + id + "";
            dr = com.ExecuteReader();
            while (dr.Read())
            { 
                Info.idEmpleado = dr["ID_Empleado"].ToString();
                Info.cedulaEmpleado = dr["Cedula"].ToString();
                Info.nombreEmpleado = dr["Nombre"].ToString();
                Info.apellidoEmpleado = dr["Apellido"].ToString();
                Info.fechaNacimientoEmpleado = dr["FechaNacimiento"].ToString();
                Info.sexoEmpleado = dr["Sexo"].ToString();
                Info.direccionEmpleado = dr["Direccion"].ToString();
                Info.telefonoEmpleado = dr["Telefono"].ToString();
                Info.usuarioEmpleado = dr["Usuario"].ToString();
                Info.contrasenaEmpleado = dr["Contrasena"].ToString();
                Info.salarioEmpleado = dr["salario"].ToString();
                Info.numeroCuentaEmpleado = dr["cuentaBancaria"].ToString();
                Info.cargoEmpleado = dr["Cargo"].ToString();
                Info.fechaRegistroEmpleado = dr["FechaEntrada"].ToString();
                Info.estatusEmpleado = dr["Estatus"].ToString();  
            }
            con.Close();
            return Info;
        }

        /* CONTROLADOR DE VISTA DE LISTA DE EMPLEADOS*/
        public IActionResult ListadoEmpleados()
        {
            List<ListadoUsuarios> empleadoLista = new List<ListadoUsuarios>();
            empleadoLista = ListaEmpleados().ToList();
            return View(empleadoLista); 
        }

        /* SELECT TODOS LOS EMPLEADOS PARA VISUALIZACION*/
        public IEnumerable<ListadoUsuarios> ListaEmpleados()
        {

            List<ListadoUsuarios> empleadoLista = new List<ListadoUsuarios>();

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM EMPLEADOS";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListadoUsuarios empleado = new ListadoUsuarios();
                empleado.idEmpleado = dr["ID_Empleado"].ToString();
                empleado.cedulaEmpleado = dr["Cedula"].ToString();
                empleado.nombreEmpleado = dr["Nombre"].ToString();
                empleado.apellidoEmpleado = dr["Apellido"].ToString();
                empleado.fechaNacimientoEmpleado = dr["FechaNacimiento"].ToString();
                empleado.sexoEmpleado = dr["Sexo"].ToString();
                empleado.direccionEmpleado = dr["Direccion"].ToString();
                empleado.telefonoEmpleado = dr["Telefono"].ToString();
                empleado.usuarioEmpleado = dr["Usuario"].ToString();
                empleado.contrasenaEmpleado = dr["Contrasena"].ToString();
                empleado.salarioEmpleado = dr["salario"].ToString();
                empleado.numeroCuentaEmpleado = dr["cuentaBancaria"].ToString();
                empleado.cargoEmpleado = dr["Cargo"].ToString();
                empleado.fechaRegistroEmpleado = dr["FechaEntrada"].ToString();
                empleado.estatusEmpleado = dr["Estatus"].ToString();

                empleadoLista.Add(empleado);
            }
            con.Close();
            return empleadoLista;
        }

        /*ELIMINAR EMPLEADO BY ID*/
        public void EliminarEmpleado(int id)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "DELETE FROM EMPLEADOS WHERE ID_EMPLEADO =" + id + "";
            dr = com.ExecuteReader();

            con.Close();
            Response.Redirect("../ListadoEmpleados");
        }


        /* vISTA INFO DE EMPLEADO BY CELDULA PARA LISTADO*/
        public IActionResult BuscarEmpleado(BuscarUsuario bu)
        {
            ListadoUsuarios lu = new ListadoUsuarios();

            lu = EmpleadoBuscar(bu.cedula);

            return View(lu);
        }

        /* SELECT INFO DE EMPLEADO BY CELDULA PARA LISTADO*/
        public ListadoUsuarios EmpleadoBuscar(string cedula)
        {
            ListadoUsuarios Info = new ListadoUsuarios();
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM EMPLEADOS where Cedula = '"+cedula+"'";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                Info.idEmpleado = dr["ID_Empleado"].ToString();
                Info.cedulaEmpleado = dr["Cedula"].ToString();
                Info.nombreEmpleado = dr["Nombre"].ToString();
                Info.apellidoEmpleado = dr["Apellido"].ToString();
                Info.fechaNacimientoEmpleado = dr["FechaNacimiento"].ToString();
                Info.sexoEmpleado = dr["Sexo"].ToString();
                Info.direccionEmpleado = dr["Direccion"].ToString();
                Info.telefonoEmpleado = dr["Telefono"].ToString();
                Info.usuarioEmpleado = dr["Usuario"].ToString();
                Info.contrasenaEmpleado = dr["Contrasena"].ToString();
                Info.salarioEmpleado = dr["salario"].ToString();
                Info.numeroCuentaEmpleado = dr["cuentaBancaria"].ToString();
                Info.cargoEmpleado = dr["Cargo"].ToString();
                Info.fechaRegistroEmpleado = dr["FechaEntrada"].ToString();
                Info.estatusEmpleado = dr["Estatus"].ToString();
            }
            con.Close();
            return Info;
        }



    }
}