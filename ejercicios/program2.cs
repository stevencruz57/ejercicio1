using System;

namespace EjemploListasEnlazadas
{
    // 1. Definición del Nodo: La unidad básica de la lista
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

    // 2. Definición de la Lista Enlazada y el algoritmo de conteo
    public class ListaEnlazada
    {
        public Nodo Cabeza; // El primer elemento

        public ListaEnlazada()
        {
            Cabeza = null;
        }

        // FUNCIÓN SOLICITADA: Recorre la lista y cuenta los "saltos"
        public int CalcularLongitud()
        {
            int contador = 0;
            Nodo actual = Cabeza;

            // Recorremos hasta que no haya más nodos (llegar al final)
            while (actual != null)
            {
                contador++;          // Incrementamos el contador por cada nodo encontrado
                actual = actual.Siguiente; // Movemos el puntero al siguiente nodo
            }

            return contador;
        }

        // Método auxiliar para insertar elementos al inicio (para la prueba)
        public void InsertarAlInicio(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            nuevoNodo.Siguiente = Cabeza;
            Cabeza = nuevoNodo;
        }
    }

    // 3. Ejecución del programa
    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada miLista = new ListaEnlazada();

            // Agregamos algunos elementos
            miLista.InsertarAlInicio(50);
            miLista.InsertarAlInicio(40);
            miLista.InsertarAlInicio(30);
            miLista.InsertarAlInicio(20);
            miLista.InsertarAlInicio(10);

            // Llamada a la función de conteo
            int cantidad = miLista.CalcularLongitud();

            Console.WriteLine("--- Conteo de Nodos ---");
            Console.WriteLine($"La lista tiene {cantidad} elementos.");
            
            // Esperar para cerrar
            Console.ReadKey();
        }
    }
}