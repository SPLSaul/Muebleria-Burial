using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muebleria_Burial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Mueblerias Burial ");
            Console.Write("Ingresa la fecha: ");
            string fecha = Console.ReadLine();
            Console.Write("Ingresa tu nombre : ");
            string nombre = Console.ReadLine();
            Console.Write("Ingresa tu numero de cliente : ");
            long numCliente = long.Parse(Console.ReadLine());
            Console.WriteLine("¿Que deseas comprar?\n(1)Sillas\n(2)Mesas\n(3)Colchones\n(4)Bocinas\n");
            int opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Console.WriteLine("Has elegido sillas");
                    Console.Write("Ingresa el modelo de la silla: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Ingresa el precio de la silla: ");
                    float precio = float.Parse(Console.ReadLine());
                    Console.Write("Ingresa la cantidad de sillas que quieres llevar: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    Sillas sillas = new Sillas(nombre, fecha, numCliente, cantidad, precio, modelo);
                    float motomami = sillas.Resultado();
                    sillas.cliente();
                    sillas.Desplegar(motomami);
                    sillas.Mensaje();
                    break;

                case 2:
                    Console.WriteLine("Has elegido Mesas");
                    Console.Write("Ingresa el modelo de la mesa: ");
                     modelo = Console.ReadLine();
                    Console.Write("Ingresa el precio de la mesa: ");
                     precio = float.Parse(Console.ReadLine());
                    Console.Write("Ingresa la cantidad de mesas que quieres llevar: ");
                     cantidad = int.Parse(Console.ReadLine());
                    Mesas mesas = new Mesas(cantidad, precio, modelo, nombre, fecha, numCliente);                    
                    motomami = mesas.Resultado();
                    mesas.cliente();
                    mesas.Desplegar(motomami);
                    mesas.Mensaje();
                    break;

                case 3:
                    Console.WriteLine("Has elegido Colchones");
                    Console.Write("Ingresa el modelo del colchon: ");
                    modelo = Console.ReadLine();
                    Console.Write("Ingresa el precio del colchon: ");
                    precio = float.Parse(Console.ReadLine());
                    Console.Write("Ingresa la cantidad de colchones que quieres llevar: ");
                    cantidad = int.Parse(Console.ReadLine());
                    Colchones colchon = new Colchones(nombre, fecha, numCliente, cantidad, precio, modelo);
                    motomami = colchon.Resultado();
                    colchon.cliente();
                    colchon.Desplegar(motomami);
                    colchon.Mensaje();
                    break;

                case 4:
                    Console.WriteLine("Has elegido Bocinas");
                    Console.Write("Ingresa el modelo de la bocina: ");
                    modelo = Console.ReadLine();
                    Console.Write("Ingresa el precio de la bocina: ");
                    precio = float.Parse(Console.ReadLine());
                    Console.Write("Ingresa la cantidad de bocinas que quieres llevar: ");
                    cantidad = int.Parse(Console.ReadLine());
                    Bocinas bocina = new Bocinas(cantidad, precio, modelo, nombre, fecha, numCliente);
                    //int cantidad, float precio, string modelo, string nombre, string fecha, long numCliente
                    motomami = bocina.Resultado();
                    bocina.cliente();
                    bocina.Desplegar(motomami);
                    bocina.Mensaje();
                    break;
                default:
                    Console.WriteLine("Opcion Incorrecta, trata de nuevo");
                    break;
            }
        }
        abstract class Info
        {  //Se heradara en sillas y colchones
            public string nombre, fecha;
            public long numCliente;

            public Info(string nombre, string fecha, long numCliente)
            {
                this.nombre = nombre;
                this.fecha = fecha;
                this.numCliente = numCliente;
            }
            public void cliente()
            {
                Console.WriteLine($"Fecha: {fecha}\nCliente: {nombre}.   No. Cliente: {numCliente} ");
            }
            public abstract float Resultado();
            public abstract void Desplegar(float motomami);
            public void Mensaje()
            {
                Console.WriteLine("Mensaje desde clase abstracta");
            }
        }

        interface IDatos
        {  // se heredara en mesas y bocinas
            void cliente();

            float Resultado();

            void Desplegar(float motomami);
        }

        class Sillas : Info
        {
            public int cantidad;
            public float precio;
            public string modelo;

            public Sillas(string nombre, string fecha, long numCliente, int cantidad, float precio, string modelo) : base(nombre, fecha, numCliente)
            {
                this.cantidad = cantidad;
                this.precio = precio;
                this.modelo = modelo;
            }
            public override float Resultado() => cantidad * precio;
            public override void Desplegar(float motomami)
            {
                Console.WriteLine($"Modelo {modelo}.\nCantidad: {cantidad}            Precio Unitario: {precio:C}\nTotal de venta: {motomami:C}");
            }
            new public void Mensaje()
            {
                Console.WriteLine("Mensaje desde clase sillas");
            }
            ~Sillas()
            {
                Console.WriteLine("Destructor clase sillas");
            }
        }

        class Colchones : Info
        { //Uso de redifinicion
            public int cantidad;
            public float precio;
            public string modelo;

            public Colchones(string nombre, string fecha, long numCliente, int cantidad, float precio, string modelo) : base(nombre, fecha, numCliente)
            {
                this.cantidad = cantidad;
                this.precio = precio;
                this.modelo = modelo;
            }

            public override float Resultado() => cantidad * precio;
            public override void Desplegar(float motomami)
            {
                Console.WriteLine($"Modelo {modelo}.\nCantidad: {cantidad}            Precio Unitario: {precio:C}\nTotal de venta: {motomami:C}");
            }
            new public void Mensaje()
            {
                Console.WriteLine("Mensaje desde clase Colchones");
            }
            ~Colchones()
            {
                Console.WriteLine("Destructor clase colchones");
            }
        }
        class Mesas : IDatos
        {
            public string nombre, fecha;
            public long numCliente;
            public int cantidad;
            public float precio;
            public string modelo;

            public Mesas(int cantidad, float precio, string modelo, string nombre, string fecha, long numCliente)
            {
                this.cantidad = cantidad;
                this.precio = precio;
                this.modelo = modelo;
                this.nombre = nombre;
                this.fecha = fecha;
                this.numCliente = numCliente;
            }
            public virtual void cliente()
            {
                Console.WriteLine($"Fecha: {fecha}\nCliente: {nombre}.   No. Cliente: {numCliente} ");
            }

            public float Resultado() => cantidad * precio;

            public void Desplegar(float motomami)
            {
                Console.WriteLine($"Modelo {modelo}.\nCantidad: {cantidad}            Precio Unitario: {precio:C}\nTotal de venta: {motomami:C}");
            }
            public virtual void Mensaje()
            {
                Console.WriteLine("Mensaje desde clase Colchones");
            }
            ~Mesas()
            {
                Console.WriteLine("Destructor clase colchones");
            }
        }

        class Bocinas : Mesas
        {
            public Bocinas(int cantidad, float precio, string modelo, string nombre, string fecha, long numCliente) : base(cantidad, precio, modelo, nombre, fecha, numCliente)
            {
                this.cantidad = cantidad;
                this.precio = precio;
                this.modelo = modelo;
                this.nombre = nombre;
                this.fecha = fecha;
                this.numCliente = numCliente;
            }
            public override void cliente()
            {
                Console.WriteLine($"Fecha: {fecha}\nCliente: {nombre}.   No. Cliente: {numCliente} ");
            }

            new public float Resultado() => cantidad * precio;

            new public void Desplegar(float motomami)
            {
                Console.WriteLine($"Modelo {modelo}.\nCantidad: {cantidad}            Precio Unitario: {precio:C}\nTotal de venta: {motomami:C}");
            }
            public override void Mensaje()
            {
                Console.WriteLine("Mensaje desde clase Bocinas");
            }
            ~Bocinas()
            {
                Console.WriteLine("Destructor clase bocinas");
            }
        }
    }
}
