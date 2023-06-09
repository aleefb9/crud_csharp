﻿//Alejandro Fernández Banda

using System;
using System.Collections.Generic;
using System.Net;

namespace Pruebas
{
    class Modelo
    {
        /**
         * Inicializamos la lista Contacto como publica y los datos por los que va a estar compuesta.
         */
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string sexo { get; set; }
        public string edad { get; set; }
        public string sector { get; set; }
        public string nEmpleados { get; set; }
        public string tipo { get; set; }
        public string mascota { get; set; }

        public string notas;
        public int i = 0;

        public List<String> listaNotas = new List<String>();
        public List<Modelo> listOfUsers = new List<Modelo>();

        /**
         * Método de la clase contacto que añade los datos pasados en la lista a la otra lista
         */
        public void CogerDatos(List<List<String>> listaDatos)
        {
            bool repetido = true;
            var buscarDni = listOfUsers.Where(w => w.dni == listaDatos[0][2]).ToList();

            foreach (var item in buscarDni)
            {
                if (item.dni == listaDatos[0][2])
                repetido = false;
            }

            if (repetido)
            {
                listOfUsers.Add(new Modelo() { nombre = listaDatos[0][0], apellidos = listaDatos[0][1], dni = listaDatos[0][2], telefono = listaDatos[0][3], sexo = listaDatos[0][4], edad = listaDatos[0][5], sector = listaDatos[0][6], nEmpleados = listaDatos[0][7], tipo = listaDatos[0][8], mascota = listaDatos[0][9], listaNotas = listaDatos[1].ToList() });
            }
            else
            {
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("El DNI introducido ya está registrado");
                Console.WriteLine("-------------------------------------------");
            }

            listaDatos[0].Clear();
            listaDatos[1].Clear();
        }

        /**
         * Método que nos muestra los datos por pantalla cuando se seleccione la opcion de listar 
         */
        public void MostrarDatos()
        {
            foreach (var item in listOfUsers)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Nombre: " + item.nombre);
                Console.WriteLine("Apellidos: " + item.apellidos);
                Console.WriteLine("DNI: " + item.dni);
                Console.WriteLine("Teléfono: " + item.telefono);
                if (item.tipo == "1")
                {
                    Console.WriteLine("Sexo: " + item.sexo);
                    Console.WriteLine("Edad: " + item.edad);
                    Console.WriteLine("gato/perro: " + item.mascota);
                    Console.WriteLine("TIPO: PERSONA");
                }
                else
                {
                    Console.WriteLine("Sector: " + item.sector);
                    Console.WriteLine("Número Empleados: " + item.nEmpleados);
                    Console.WriteLine("TIPO: EMPRESA");
                }
                Console.WriteLine("Notas: ");    
                for (int i = 0; item.listaNotas.Count > i; i++)
                {
                    Console.WriteLine("\tNotas["+ i +"]: " + item.listaNotas[i]);
                }
                Console.WriteLine("------------------------");
            }
        }

        /**
         * Método que busca un objeto de la lista por el dni y lo borra
         */
        public void BorrarDatos()
        {
            Console.WriteLine("INTRODUZCA DNI DEL CONTACTO QUE QUIERA BORRAR: ");
            string nDni = Console.ReadLine();

            Console.WriteLine("¿Está seguro de querer eliminar al usuario con DNI: " + nDni + "? (s/n)");
            string confirmarBorrado = Console.ReadLine();

            if (confirmarBorrado == "s" || confirmarBorrado == "S")
            {
                var eliminar = listOfUsers.Where(w => w.dni == nDni);

                foreach (var datoBorrado in eliminar.ToArray())
                {
                    listOfUsers.Remove(datoBorrado);
                }

                Console.WriteLine("\n---------------------------------------------------------------");
                Console.WriteLine("el usuario con DNI " + nDni + ", se ha eliminado correctamente");
                Console.WriteLine("---------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("\n---------------------------------------------------------------");
                Console.WriteLine("No se ha eliminado el usuario con DNI " + nDni);
                Console.WriteLine("---------------------------------------------------------------");
            }
        }

        /**
         * Método que busca un objeto de la lista por le dni y muestra su información
         */
        public void BuscarDatos()
        {
            Console.WriteLine("INTRODUZCA DNI DEL CONTACTO QUE QUIERA BUSCAR: ");
            string buscarDni = Console.ReadLine();

            var buscador = listOfUsers.Where(w => w.dni == buscarDni);

            foreach (var item in buscador)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Nombre: " + item.nombre);
                Console.WriteLine("Apellidos: " + item.apellidos);
                Console.WriteLine("DNI: " + item.dni);
                Console.WriteLine("Teléfono: " + item.telefono);
                if (item.tipo == "1")
                {
                    Console.WriteLine("Sexo: " + item.sexo);
                    Console.WriteLine("Edad: " + item.edad);
                    Console.WriteLine("TIPO: PERSONA");
                }
                else
                {
                    Console.WriteLine("Sector: " + item.sector);
                    Console.WriteLine("Número Empleados: " + item.nEmpleados);
                    Console.WriteLine("TIPO: EMPRESA");
                }
                Console.WriteLine("Notas: ");
                for (int i = 0; item.listaNotas.Count > i; i++)
                {
                    Console.WriteLine("\tNotas[" + i + "]: " + item.listaNotas[i]);
                }
                Console.WriteLine("------------------------");
            }
        }

        /**
         * Método que busca un objeto de la lista por le dni y nos permite modificar la información que el usuario seleccione
         */
        public void EditarDatos()
        {
            Console.WriteLine("SELECCIONE EL DNI DEL CONTACTO QUE DESEA MODIFICAR: ");
            string buscarEditarDni = Console.ReadLine();

            foreach (var item in listOfUsers.Where(w => w.dni == buscarEditarDni))
            {
                Console.WriteLine("\n---- ¿QUÉ DESEA EDITAR? ----");
                Console.WriteLine("1.Cambiar nombre");
                Console.WriteLine("2.Cambiar apellidos");
                Console.WriteLine("3.Cambiar DNI");
                Console.WriteLine("4.Cambiar teléfono");
                if (item.tipo == "1")
                {
                    Console.WriteLine("5.Cambiar edad");
                    Console.WriteLine("6.Cambiar sexo");
                }
                else
                {
                    Console.WriteLine("5.Cambiar sector");
                    Console.WriteLine("6.Cambiar nº de Empleados");
                }
                Console.WriteLine("7.Añadir notas");
                Console.WriteLine("8.Salir");
                Console.WriteLine("----------------------------");

                string opciobEdicion = Console.ReadLine();

                if (opciobEdicion != "1" && opciobEdicion != "2" && opciobEdicion != "3" && opciobEdicion != "4" && opciobEdicion != "5" && opciobEdicion != "6" && opciobEdicion != "7" && opciobEdicion != "8")
                {
                    Console.Clear();
                    Console.WriteLine("\n-------------------------------");
                    Console.WriteLine("Introduzca una opción correcta");
                    Console.WriteLine("-------------------------------");
                }
                else
                {
                    if (opciobEdicion == "1")
                    {
                        Console.WriteLine("\nNOMBRE ACTUAL: " + item.nombre);
                        Console.WriteLine("\nINTRODUZCA NUEVO NOMBRE: ");
                        string editarNombre = Console.ReadLine();
                        item.nombre = editarNombre;
                    }
                    if (opciobEdicion == "2")
                    {
                        Console.WriteLine("\nAPELLIDO ACTUAL: " + item.apellidos);
                        Console.WriteLine("\nINTRODUZCA NUEVO APELLIDO: ");
                        string editarApellidos = Console.ReadLine();
                        item.apellidos = editarApellidos;
                    }
                    if (opciobEdicion == "3")
                    {
                        Console.WriteLine("\nDNI ACTUAL: " + item.dni);
                        Console.WriteLine("\nINTRODUZCA NUEVO DNI: ");
                        string editarDni = Console.ReadLine();
                        item.dni = editarDni;
                    }
                    if (opciobEdicion == "4")
                    {
                        Console.WriteLine("\nTELÉFONO ACTUAL: " + item.telefono);
                        Console.WriteLine("\nINTRODUZCA NUEVO TELÉFONO: ");
                        string editarTelefono = Console.ReadLine();
                        item.telefono = editarTelefono;
                    }
                    if (opciobEdicion == "5")
                    {
                        if (item.tipo == "1")
                        {
                            Console.WriteLine("\nEDAD ACTUAL: " + item.edad);
                            Console.WriteLine("\nINTRODUZCA NUEVA EDAD: ");
                            string editarEdad = Console.ReadLine();
                            item.edad = editarEdad;
                        }
                        else
                        {
                            Console.WriteLine("\nSECTOR ACTUAL: " + item.sector);
                            Console.WriteLine("\nINTRODUZCA NUEVO SECTOR: ");
                            string editarSector = Console.ReadLine();
                            item.sector = editarSector;
                        }
                    }
                    if (opciobEdicion == "6")
                    {
                        if (item.tipo == "1")
                        {
                            Console.WriteLine("\n SEXO ACTUAL: " + item.sexo);
                            Console.WriteLine("\nINTRODUZCA NUEVO SEXO: ");
                            string editarSexo = Console.ReadLine();
                            item.sexo = editarSexo;
                        }
                        else
                        {
                            Console.WriteLine("\nNÚMERO DE EMPLEADOS ACTUAL: " + item.nEmpleados);
                            Console.WriteLine("\nINTRODUZCA NUEVO Nº EMPLEADOS: ");
                            string editarNEmpleados = Console.ReadLine();
                            item.nEmpleados = editarNEmpleados;
                        }
                    }
                    if (opciobEdicion == "7")
                    {
                        Console.Clear();
                        Console.WriteLine("\nIntroduce n cuando quieras dejar de añadir notas");
                        while (true)
                        {
                            Console.WriteLine("\nNota[" + i++ + "]: ");
                            notas = Console.ReadLine();

                            if (notas == "n")
                            {
                                break;
                            }

                            foreach(var nuevo in listOfUsers)
                            {
                                nuevo.listaNotas.Add(notas);
                            }
                        }
                    }
                    if (opciobEdicion == "8")
                    {
                        Console.Clear();
                        Console.WriteLine("\n-------------------------------------------------------------");
                        Console.WriteLine("SE HA CANCELADO LA MODIFICACIÓN, HA VUELTO AL MENU PRINCIPAL");
                        Console.WriteLine("-------------------------------------------------------------");
                    }
                }
            }
        }
    }
}

