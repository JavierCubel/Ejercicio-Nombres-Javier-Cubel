using System;
using System.IO;

namespace Nombres
{
    class Program
    {
        // Se define una variable entera que representa el numero de nombres y un array de tipo string
        //en el que se almacenaran los nombres
        public static int numNombres = 5;
        public static string[] nombres = new string[numNombres];

        //Metodo que se usa para pedir los nombres
        public static string PedirNombre()
        {
            
            return Console.ReadLine();
        }

        //Funcion que devuelve el nombre de la posicion que indica el indice
        public static string getNombreI(int indice)
        {
            return nombres[indice];
        }

        //Metodo que guarda los nombres en un fichero de nombre "ListaOrdenada.txt"
        public static void GuardarNombres()
        {
            StreamWriter fichero = new StreamWriter("..\\..\\..\\ListaOrdenada.txt");
            for (int i = 0; i < numNombres; i++)
            {
                fichero.WriteLine(getNombreI(i));
            }
            fichero.Close();
        }

        //Metodo que ordena los datos del array "nombres"
        public static void Ordenar()
        {
            
            Array.Sort(nombres);
        }

        static void Main(string[] args)
        {
            string nombre;
            string apellido;
            string completo;
            Console.WriteLine("Bienvenido!!!");
            Console.ReadLine();
            for(int i=0; i<numNombres; i++)
            {
                Console.WriteLine("Escribe el nombre {0}",i+1);
                nombre= PedirNombre();
                Console.WriteLine("Escribe el apellido {0}", i+1);
                apellido = PedirNombre();
                completo = apellido + ", "+nombre;
                nombres[i] = completo;
            }
            Ordenar();
            Console.WriteLine();
            Console.WriteLine("Estos son los nombres ordenados alfabeticamente:");
            for (int i = 0; i < numNombres; i++)
            {
                Console.WriteLine(getNombreI(i));
            }
            Console.WriteLine("Guardando lista ordenada de nombres en fichero de texto...");
            GuardarNombres();
            Console.WriteLine();
            Console.WriteLine("Nombres guardados correctamente");
            Console.ReadKey();
        }
    }
}
