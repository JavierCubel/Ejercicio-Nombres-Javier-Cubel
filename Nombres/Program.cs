using System;
using System.IO;

namespace Nombres
{
    class Program
    {
        public struct Persona
        {
            public string nombre;
            public string apellido;
        }
        // Se define una variable entera que representa el numero de nombres y un array de tipo string
        //en el que se almacenaran los nombres
        public static int numNombres = 5;
        public static Persona[] nombres = new Persona[numNombres];


        //Metodo que se usa para pedir los nombres
        public static string PedirNombre()
        {
            
            return Console.ReadLine();
        }

        //Funcion que devuelve el nombre de la posicion que indica el indice
        public static string getNombreI(int indice)
        {
            return nombres[indice].nombre;
        }

        //Funcion que devuelve el apellido de la posicion que indica el indice
        public static string getApellidoI(int indice)
        {
            return nombres[indice].apellido;
        }

        //Metodo que guarda los nombres en un fichero de nombre "ListaOrdenada.txt"
        public static void GuardarNombres()
        {
            StreamWriter fichero = new StreamWriter("..\\..\\..\\ListaOrdenada.txt");
            for (int i = 0; i < numNombres; i++)
            {
                fichero.WriteLine(getApellidoI(i) + ", " + getNombreI(i));
            }
            fichero.Close();
        }

        //Metodo que ordena los datos del array "nombres"
        public static void Ordenar()
        {
            Array.Sort
                (nombres, delegate (Persona p1, Persona p2) 
                    {
                        if(p1.apellido != p2.apellido)
                        {
                            return p1.apellido.CompareTo(p2.apellido);
                        }
                        else
                        {
                            return p1.nombre.CompareTo(p2.nombre);
                        }
                        
                    }
                );
        }

        static void Main(string[] args)
        {
            
            
            Console.WriteLine("Bienvenido!!!");
            Console.ReadLine();
            for(int i=0; i<numNombres; i++)
            {
                Console.WriteLine("Escribe el nombre {0}",i+1);
                nombres[i].nombre = PedirNombre();
                Console.WriteLine("Escribe el apellido {0}", i+1);
                nombres[i].apellido = PedirNombre();
                
                
            }
            Ordenar();
            Console.WriteLine();
            Console.WriteLine("Estos son los nombres ordenados alfabeticamente:");
            for (int i = 0; i < numNombres; i++)
            {
                Console.WriteLine(getApellidoI(i)+", "+getNombreI(i));
            }
            Console.WriteLine("Guardando lista ordenada de nombres en fichero de texto...");
            GuardarNombres();
            Console.WriteLine();
            Console.WriteLine("Nombres guardados correctamente");
            Console.ReadKey();
        }
    }
}
