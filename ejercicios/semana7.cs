using System;
using System.Collections.Generic;

namespace TareaEstructurasDatos
{
    class Program
    {
        // Pilas globales para el problema de Hanoi
        static Stack<int> torreOrigen = new Stack<int>();
        static Stack<int> torreAuxiliar = new Stack<int>();
        static Stack<int> torreDestino = new Stack<int>();

        static void Main(string[] args)
        {
            // --- EJERCICIO 1: VERIFICACIÓN DE BALANCEO ---
            Console.WriteLine("=== EJERCICIO 1: BALANCEO DE EXPRESIONES ===");
            string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
            bool resultado = VerificarParentesis(expresion);
            
            Console.WriteLine($"Expresión: {expresion}");
            Console.WriteLine(resultado ? "Salida: Fórmula balanceada." : "Salida: Fórmula NO balanceada.");
            Console.WriteLine("\n" + new string('-', 50) + "\n");

            // --- EJERCICIO 2: TORRES DE HANOI ---
            Console.WriteLine("=== EJERCICIO 2: TORRES DE HANOI (CON PILAS) ===");
            int discos = 3;
            InicializarHanoi(discos);
            ResolverHanoi(discos, torreOrigen, torreDestino, torreAuxiliar, "Origen", "Destino", "Auxiliar");
            Console.WriteLine("¡Resolución completada!");
            Console.ReadKey();
        }

        #region Lógica Ejercicio 1
        /// <summary>
        /// Verifica si los delimitadores (), [], {} están correctamente cerrados y anidados.
        /// </summary>
        static bool VerificarParentesis(string texto)
        {
            Stack<char> pila = new Stack<char>();
            foreach (char c in texto)
            {
                // Si es apertura, se guarda en la pila
                if (c == '(' || c == '{' || c == '[') pila.Push(c);
                
                // Si es cierre, verificamos si coincide con el último abierto
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (pila.Count == 0) return false; // Cierre sin apertura previa
                    char top = pila.Pop();
                    if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
                        return false; // No coincide el par
                }
            }
            return pila.Count == 0; // Si queda algo en la pila, no se cerró correctamente
        }
        #endregion

        #region Lógica Ejercicio 2
        static void InicializarHanoi(int n)
        {
            torreOrigen.Clear(); torreAuxiliar.Clear(); torreDestino.Clear();
            // Los discos se apilan de mayor a menor (el más grande al fondo)
            for (int i = n; i >= 1; i--) torreOrigen.Push(i);
            ImprimirTorres();
        }

        /// <summary>
        /// Algoritmo recursivo para mover discos gestionando objetos Stack.
        /// </summary>
        static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nO, string nD, string nA)
        {
            if (n == 1)
            {
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Movimiento: Disco {disco} de {nO} a {nD}");
                ImprimirTorres();
                return;
            }

            // Mover n-1 discos al poste auxiliar para liberar el más grande
            ResolverHanoi(n - 1, origen, auxiliar, destino, nO, nA, nD);
            
            // Mover el disco grande al destino
            int discoG = origen.Pop();
            destino.Push(discoG);
            Console.WriteLine($"Movimiento: Disco {discoG} de {nO} a {nD}");
            ImprimirTorres();

            // Mover los n-1 discos del auxiliar al destino final
            ResolverHanoi(n - 1, auxiliar, destino, origen, nA, nD, nO);
        }

        static void ImprimirTorres()
        {
            // Mostramos el contenido de las pilas en una sola línea
            Console.WriteLine($"  [O]: {string.Join("-", torreOrigen.ToArray())}");
            Console.WriteLine($"  [A]: {string.Join("-", torreAuxiliar.ToArray())}");
            Console.WriteLine($"  [D]: {string.Join("-", torreDestino.ToArray())}");
            Console.WriteLine("-------------------------------------------");
        }
        #endregion
    }
}