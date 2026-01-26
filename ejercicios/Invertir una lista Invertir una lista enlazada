using System;

namespace EjerciciosListas
{
    // Clase que representa un Nodo
    public class Nodo
    {
        public int Valor;
        public Nodo Siguiente;

        public Nodo(int valor)
        {
            this.Valor = valor;
            this.Siguiente = null;
        }
    }

    // Clase que gestiona la Lista Enlazada
    public class ListaEnlazada
    {
        public Nodo Cabeza;

        public ListaEnlazada() { Cabeza = null; }

        // EJERCICIO 1: Función que cuenta los elementos
        public int ContarElementos()
        {
            int contador = 0;
            Nodo actual = Cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        // EJERCICIO 2: Método para invertir la lista
        public void Invertir()
        {
            Nodo anterior = null;
            Nodo actual = Cabeza;
            Nodo siguiente = null;

            while (actual != null)
            {
                siguiente = actual.Siguiente; // Guarda el resto de la lista
                actual.Siguiente = anterior;  // Invierte el puntero
                anterior = actual;            // Se mueve hacia adelante
                actual = siguiente;           // Se mueve hacia adelante
            }
            Cabeza = anterior; // El último nodo procesado es la nueva cabeza
        }

        // Métodos auxiliares
        public void InsertarAlFinal(int valor)
        {
            if (Cabeza == null) { Cabeza = new Nodo(valor); return; }
            Nodo temp = Cabeza;
            while (temp.Siguiente != null) temp = temp.Siguiente;
            temp.Siguiente = new Nodo(valor);
        }

        public void Imprimir()
        {
            Nodo temp = Cabeza;
            while (temp != null)
            {
                Console.Write($"{temp.Valor} -> ");
                temp = temp.Siguiente;
            }
            Console.WriteLine("null");
        }
    }

    // Único punto de entrada del programa
    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada miLista = new ListaEnlazada();
            
            // Insertamos datos de prueba
            miLista.InsertarAlFinal(10);
            miLista.InsertarAlFinal(20);
            miLista.InsertarAlFinal(30);

            Console.WriteLine("--- Lista Original ---");
            miLista.Imprimir();
            Console.WriteLine($"Total elementos: {miLista.ContarElementos()}");

            // Inversión de la lista
            Console.WriteLine("\n--- Invirtiendo Lista... ---");
            miLista.Invertir();
            
            miLista.Imprimir();
            Console.WriteLine($"Total elementos sigue siendo: {miLista.ContarElementos()}");
        }
    }
}
