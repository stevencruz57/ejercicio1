using System;
using System.Collections.Generic;
using System.Linq;

namespace CampanaVacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Crear el universo de 500 ciudadanos
            HashSet<string> universo = new HashSet<string>();
            for (int i = 1; i <= 500; i++) universo.Add($"Ciudadano {i}");

            // 2. Crear conjunto de vacunados con Pfizer (75 ciudadanos)
            // Simulamos que son los ciudadanos del 1 al 75
            HashSet<string> pfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++) pfizer.Add($"Ciudadano {i}");

            // 3. Crear conjunto de vacunados con AstraZeneca (75 ciudadanos)
            // Simulamos que del 50 al 125 para que haya una intersección (doble dosis)
            HashSet<string> astrazeneca = new HashSet<string>();
            for (int i = 50; i <= 124; i++) astrazeneca.Add($"Ciudadano {i}");

            // --- OPERACIONES DE CONJUNTOS ---

            // A. Ciudadanos que han recibido ambas dosis (Intersección)
            HashSet<string> ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astrazeneca);

            // B. Ciudadanos que NO se han vacunado (Universo - (Pfizer UNION AstraZeneca))
            HashSet<string> todosVacunados = new HashSet<string>(pfizer);
            todosVacunados.UnionWith(astrazeneca);
            
            HashSet<string> noVacunados = new HashSet<string>(universo);
            noVacunados.ExceptWith(todosVacunados);

            // C. Ciudadanos que solo tienen Pfizer (Diferencia)
            HashSet<string> soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astrazeneca);

            // D. Ciudadanos que solo tienen AstraZeneca (Diferencia)
            HashSet<string> soloAstra = new HashSet<string>(astrazeneca);
            soloAstra.ExceptWith(pfizer);

            // --- MOSTRAR RESULTADOS (Resumen) ---
            Console.WriteLine("REPORTE DE VACUNACIÓN COVID-19");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Total ciudadanos no vacunados: {noVacunados.Count}");
            Console.WriteLine($"Ciudadanos con ambas dosis: {ambasDosis.Count}");
            Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
            Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");
            
            // Ejemplo de listado (Primeros 5 no vacunados)
            Console.WriteLine("\nMuestra de ciudadanos no vacunados:");
            foreach (var c in noVacunados.Take(5)) Console.WriteLine($"- {c}");
        }
    }
}