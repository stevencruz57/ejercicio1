using System;

namespace ArbolBinarioBusqueda
{
    // 1. Clase Nodo: Define la estructura de cada elemento del árbol
    public class Nodo
    {
        public int Valor;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // 2. Clase BST: Contiene la lógica del Árbol Binario de Búsqueda
    public class BST
    {
        public Nodo Raiz;

        public BST() => Raiz = null;

        // Insertar un nuevo valor
        public void Insertar(int valor) => Raiz = InsertarRecursivo(Raiz, valor);

        private Nodo InsertarRecursivo(Nodo actual, int valor)
        {
            if (actual == null) return new Nodo(valor);

            if (valor < actual.Valor)
                actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, valor);
            else if (valor > actual.Valor)
                actual.Derecho = InsertarRecursivo(actual.Derecho, valor);

            return actual;
        }

        // Buscar un valor
        public bool Buscar(int valor) => BuscarRecursivo(Raiz, valor);

        private bool BuscarRecursivo(Nodo actual, int valor)
        {
            if (actual == null) return false;
            if (valor == actual.Valor) return true;

            return valor < actual.Valor 
                ? BuscarRecursivo(actual.Izquierdo, valor) 
                : BuscarRecursivo(actual.Derecho, valor);
        }

        // Eliminar un valor
        public void Eliminar(int valor) => Raiz = EliminarRecursivo(Raiz, valor);

        private Nodo EliminarRecursivo(Nodo actual, int valor)
        {
            if (actual == null) return null;

            if (valor < actual.Valor)
                actual.Izquierdo = EliminarRecursivo(actual.Izquierdo, valor);
            else if (valor > actual.Valor)
                actual.Derecho = EliminarRecursivo(actual.Derecho, valor);
            else
            {
                // Nodo con un solo hijo o sin hijos
                if (actual.Izquierdo == null) return actual.Derecho;
                if (actual.Derecho == null) return actual.Izquierdo;

                // Nodo con dos hijos: obtener el sucesor inorden (mínimo del subárbol derecho)
                actual.Valor = ValorMinimo(actual.Derecho);
                actual.Derecho = EliminarRecursivo(actual.Derecho, actual.Valor);
            }
            return actual;
        }

        // Funciones de utilidad
        public int ValorMinimo(Nodo actual)
        {
            int min = actual.Valor;
            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
                min = actual.Valor;
            }
            return min;
        }

        public int ValorMaximo(Nodo actual)
        {
            int max = actual.Valor;
            while (actual.Derecho != null)
            {
                actual = actual.Derecho;
                max = actual.Valor;
            }
            return max;
        }

        public int ObtenerAltura(Nodo actual)
        {
            if (actual == null) return 0;
            return 1 + Math.Max(ObtenerAltura(actual.Izquierdo), ObtenerAltura(actual.Derecho));
        }

        // Recorridos
        public void Preorden(Nodo actual)
        {
            if (actual == null) return;
            Console.Write(actual.Valor + " ");
            Preorden(actual.Izquierdo);
            Preorden(actual.Derecho);
        }

        public void Inorden(Nodo actual)
        {
            if (actual == null) return;
            Inorden(actual.Izquierdo);
            Console.Write(actual.Valor + " ");
            Inorden(actual.Derecho);
        }

        public void Postorden(Nodo actual)
        {
            if (actual == null) return;
            Postorden(actual.Izquierdo);
            Postorden(actual.Derecho);
            Console.Write(actual.Valor + " ");
        }

        public void Limpiar() => Raiz = null;
    }

    // 3. Clase Principal: Interfaz de usuario en consola
    class Program
    {
        static void Main(string[] args)
        {
            BST arbol = new BST();
            int opcion = -1;

            while (opcion != 0)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("   SISTEMA DE GESTIÓN DE ÁRBOL (BST)   ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Mostrar recorridos (Pre, In, Post)");
                Console.WriteLine("5. Ver Mínimo, Máximo y Altura");
                Console.WriteLine("6. Limpiar árbol completo");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out int valIns))
                        {
                            arbol.Insertar(valIns);
                            Console.WriteLine("Valor insertado con éxito.");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valBus))
                        {
                            bool encontrado = arbol.Buscar(valBus);
                            Console.WriteLine(encontrado ? "¡El valor existe en el árbol!" : "El valor NO se encuentra.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int valEli))
                        {
                            arbol.Eliminar(valEli);
                            Console.WriteLine("Operación de eliminación realizada.");
                        }
                        break;

                    case 4:
                        if (arbol.Raiz == null) Console.WriteLine("El árbol está vacío.");
                        else
                        {
                            Console.Write("\nPreorden:  "); arbol.Preorden(arbol.Raiz);
                            Console.Write("\nInorden:   "); arbol.Inorden(arbol.Raiz);
                            Console.Write("\nPostorden: "); arbol.Postorden(arbol.Raiz);
                            Console.WriteLine();
                        }
                        break;

                    case 5:
                        if (arbol.Raiz == null) Console.WriteLine("El árbol está vacío.");
                        else
                        {
                            Console.WriteLine($"\nValor Mínimo: {arbol.ValorMinimo(arbol.Raiz)}");
                            Console.WriteLine($"Valor Máximo: {arbol.ValorMaximo(arbol.Raiz)}");
                            Console.WriteLine($"Altura del Árbol: {arbol.ObtenerAltura(arbol.Raiz)}");
                        }
                        break;

                    case 6:
                        arbol.Limpiar();
                        Console.WriteLine("Árbol eliminado correctamente.");
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}