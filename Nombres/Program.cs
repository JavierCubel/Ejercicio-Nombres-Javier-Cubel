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
        public static void GuardarFichero()
        {
            Console.WriteLine("Guardando lista ordenada de nombres en fichero de texto...");
            StreamWriter fichero = new StreamWriter("..\\..\\..\\ListaOrdenada.txt");
            for (int i = 0; i < numNombres; i++)
            {
                fichero.WriteLine(getApellidoI(i) + ", " + getNombreI(i));
            }
            fichero.Close();
            Console.WriteLine("Completado con exito");
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

        public static void Menu()
        {
            Console.WriteLine("Elige la opcion:");
            Console.WriteLine("1: Pedir datos");
            Console.WriteLine("2: Ordenar datos");
            Console.WriteLine("3: Mostrar datos datos");
            Console.WriteLine("4: Guardar en fichero");
            Console.WriteLine("5: Buscar por indice");
            Console.WriteLine("6: Buscar por nombre");
            Console.WriteLine("7: Buscar por apellido");
            Console.WriteLine("0: Salir");
        }

        public static void PedirDatos()
        {
            for (int i = 0; i < numNombres; i++)
            {
                Console.WriteLine("Escribe el nombre {0}", i + 1);
                nombres[i].nombre = PedirNombre();
                Console.WriteLine("Escribe el apellido {0}", i + 1);
                nombres[i].apellido = PedirNombre();


            }
        }

        public static void MostrarDatos()
        {
            foreach(Persona dato in nombres)
            {
                Console.WriteLine(dato.apellido + ", " + dato.nombre);
            }
        }

        public static void MostrarI()
        {
            int i=-1;
            Console.WriteLine("Escribe el indice a mostrar");
            if(!Int32.TryParse(Console.ReadLine(), out i) || (i<0) || (i>=numNombres))
            {
                MostrarI();
            }
            else
            {
                Console.WriteLine(getApellidoI(i)+", "+getNombreI(i));
            }
        }

        public static void BuscarNombre()
        {
            int indice = -1;
            Console.WriteLine("Escribe el nombre a mostrar");
            string nombre = Console.ReadLine();
            for(int i=0; i<numNombres; i++)
            {
                if(nombres[i].nombre==nombre)
                {
                    indice = i;
                    i = numNombres;
                }
            }
            if(indice !=-1)
            {
                Console.WriteLine(indice+": "+getApellidoI(indice) + ", " + getNombreI(indice));
            }
            else
            {
                Console.WriteLine("No existe ningun dato con nombre {0}", nombre);
            }
        }

        public static void BuscarApellido()
        {
            int indice = -1;
            Console.WriteLine("Escribe el apellido a mostrar");
            string apellido = Console.ReadLine();
            for (int i = 0; i < numNombres; i++)
            {
                if (nombres[i].apellido == apellido)
                {
                    indice = i;
                    i = numNombres;
                }
            }
            if (indice != -1)
            {
                Console.WriteLine(indice + ": " + getApellidoI(indice) + ", " + getNombreI(indice));
            }
            else
            {
                Console.WriteLine("No existe ningun dato con apellido {0}", apellido);
            }
        }

        static void Main(string[] args)
        {
            int opcion=-1;
            
            Console.WriteLine("Bienvenido!!!");
            Console.ReadLine();
            while(opcion !=0)
            {
                Menu();
                Int32.TryParse(Console.ReadLine(), out opcion);
                switch(opcion)
                {
                    case 0: break;
                    case 1: PedirDatos();  break;
                    case 2: Ordenar();  break;
                    case 3: MostrarDatos(); break;
                    case 4: GuardarFichero(); break;
                    case 5: MostrarI(); break;
                    case 6: BuscarNombre(); break;
                    case 7: BuscarApellido();  break;
                    default: Console.WriteLine("Opcion erronea"); break;

                }
            }
            
            
            
            
            Console.ReadKey();
        }
    }
}
