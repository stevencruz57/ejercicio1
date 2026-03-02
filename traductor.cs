using System;
using System.Collections.Generic;

namespace TraductorDiccionario
{
    class Program
    {
        // Diccionario global para que sea accesible desde todos los métodos
        static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        static void Main(string[] args)
        {
            InicializarDiccionario();
            int opcion;

            do
            {
                Console.WriteLine("\n==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        TraducirFrase();
                        break;
                    case 2:
                        AgregarPalabra();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }

        static void InicializarDiccionario()
        {
            // Agregamos las palabras base (Inglés -> Español y viceversa para bidireccionalidad simple)
            string[,] palabrasIniciales = {
                {"time", "tiempo"}, {"person", "persona"}, {"year", "año"},
                {"way", "camino"}, {"day", "día"}, {"thing", "cosa"},
                {"man", "hombre"}, {"world", "mundo"}, {"life", "vida"},
                {"hand", "mano"}, {"part", "parte"}, {"child", "niño"},
                {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"},
                {"work", "trabajo"}, {"week", "semana"}, {"case", "caso"},
                {"point", "punto"}, {"government", "gobierno"}, {"company", "empresa"}
            };

            for (int i = 0; i < palabrasIniciales.GetLength(0); i++)
            {
                string eng = palabrasIniciales[i, 0];
                string esp = palabrasIniciales[i, 1];
                
                // Agregamos ambas direcciones para que traduzca de Inglés a Español y viceversa
                if (!diccionario.ContainsKey(eng)) diccionario.Add(eng, esp);
                if (!diccionario.ContainsKey(esp)) diccionario.Add(esp, eng);
            }
        }

        static void TraducirFrase()
        {
            Console.Write("\nIngrese la frase a traducir: ");
            string frase = Console.ReadLine();
            
            // Dividimos la frase por espacios y signos comunes
            string[] palabras = frase.Split(' ');
            List<string> fraseTraducida = new List<string>();

            foreach (string palabra in palabras)
            {
                // Limpiamos la palabra de signos de puntuación para buscarla
                string palabraLimpia = palabra.Trim(new char[] { '.', ',', '!', '?', '¡', '¿' });
                
                if (diccionario.ContainsKey(palabraLimpia))
                {
                    // Reemplazamos manteniendo los signos originales si es posible
                    string traducida = diccionario[palabraLimpia];
                    fraseTraducida.Add(palabra.Replace(palabraLimpia, traducida));
                }
                else
                {
                    fraseTraducida.Add(palabra);
                }
            }

            Console.WriteLine("\nTraducción esperada: " + string.Join(" ", fraseTraducida));
        }

        static void AgregarPalabra()
        {
            Console.Write("\nIngrese la palabra en Inglés: ");
            string eng = Console.ReadLine().Trim();
            Console.Write("Ingrese su traducción al Español: ");
            string esp = Console.ReadLine().Trim();

            if (!diccionario.ContainsKey(eng) && !diccionario.ContainsKey(esp))
            {
                diccionario.Add(eng, esp);
                diccionario.Add(esp, eng);
                Console.WriteLine("¡Palabra agregada con éxito!");
            }
            else
            {
                Console.WriteLine("La palabra ya existe en el diccionario.");
            }
        }
    }
}