using System;
using System.Collections.Generic;

namespace SistemaAtraccion
{
    // Clase que representa al usuario
    public class Persona
    {
        // Se agrega '?' para permitir nulos o un valor por defecto para evitar el warning CS8618
        public string Nombre { get; set; } = string.Empty; 
        public int Id { get; set; }

        public override string ToString() => $"[ID: {Id} | Nombre: {Nombre}]";
    }

    // Clase que gestiona la lógica de la cola y asientos
    public class AtraccionControlador
    {
        private Queue<Persona> filaEspera = new Queue<Persona>();
        private const int MAX_ASIENTOS = 30;
        private int contadorId = 1;

        public bool RegistrarPersona(string nombre)
        {
            if (filaEspera.Count < MAX_ASIENTOS)
            {
                filaEspera.Enqueue(new Persona { Nombre = nombre, Id = contadorId++ });
                return true;
            }
            return false;
        }

        public void MostrarReporteria()
        {
            Console.WriteLine("\n--- ESTADO ACTUAL DE LA FILA ---");
            if (filaEspera.Count == 0) Console.WriteLine("La fila está vacía.");
            foreach (var p in filaEspera)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine($"Total en espera: {filaEspera.Count}/{MAX_ASIENTOS}");
        }

        public void IniciarAtraccion()
        {
            if (filaEspera.Count == MAX_ASIENTOS)
            {
                Console.WriteLine("\n¡Capacidad llena! Iniciando atracción...");
                while (filaEspera.Count > 0)
                {
                    Persona p = filaEspera.Dequeue();
                    Console.WriteLine($"Subiendo a: {p.Nombre}...");
                }
                Console.WriteLine("Todos los asientos han sido ocupados y procesados.");
            }
            else
            {
                Console.WriteLine($"\nAún faltan {MAX_ASIENTOS - filaEspera.Count} personas para completar los {MAX_ASIENTOS} asientos.");
            }
        }
    }

    // CLASE PRINCIPAL (Faltaba en tu código)
    class Program
    {
        static void Main(string[] args)
        {
            AtraccionControlador controlador = new AtraccionControlador();

            Console.WriteLine("Simulando registro de 30 personas...");
            
            for (int i = 1; i <= 30; i++)
            {
                controlador.RegistrarPersona($"Persona {i}");
            }

            // Consultar (Reportería)
            controlador.MostrarReporteria();

            // Ejecutar atracción
            controlador.IniciarAtraccion();
        }
    }
}