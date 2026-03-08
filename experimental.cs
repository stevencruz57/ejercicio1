using System;
using System.Collections.Generic;

namespace BibliotecaConjuntos
{
    // Clase que representa la entidad Libro
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        // Sobrescribimos Equals y GetHashCode para que el HashSet 
        // identifique duplicados basados en el ISBN.
        public override bool Equals(object obj)
        {
            if (obj is Libro otroLibro)
                return ISBN == otroLibro.ISBN;
            return false;
        }

        public override int GetHashCode()
        {
            return ISBN != null ? ISBN.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return $"[ISBN: {ISBN}] Título: {Titulo} - Autor: {Autor}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Libro> biblioteca = new HashSet<Libro>();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- SISTEMA DE BIBLIOTECA (TEORÍA DE CONJUNTOS) ---");
                Console.WriteLine("1. Registrar Libro");
                Console.WriteLine("2. Visualizar Inventario");
                Console.WriteLine("3. Consultar por ISBN");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Ingrese Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese Autor: ");
                        string autor = Console.ReadLine();

                        Libro nuevoLibro = new Libro { ISBN = isbn, Titulo = titulo, Autor = autor };
                        
                        // La operación Add devuelve false si el elemento ya existe (Propiedad de Conjunto)
                        if (biblioteca.Add(nuevoLibro))
                            Console.WriteLine("Libro registrado exitosamente.");
                        else
                            Console.WriteLine("Error: El libro con ese ISBN ya existe en el conjunto.");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Reporte de Libros ---");
                        foreach (var libro in biblioteca)
                            Console.WriteLine(libro);
                        break;

                    case "3":
                        Console.Write("Ingrese ISBN a buscar: ");
                        string buscarIsbn = Console.ReadLine();
                        // Simulación de consulta en conjunto
                        Libro busqueda = null;
                        foreach(var l in biblioteca) if(l.ISBN == buscarIsbn) busqueda = l;

                        if (busqueda != null)
                            Console.WriteLine("Resultado: " + busqueda);
                        else
                            Console.WriteLine("Libro no encontrado.");
                        break;

                    case "4":
                        continuar = false;
                        break;
                }
            }
        }
    }
}