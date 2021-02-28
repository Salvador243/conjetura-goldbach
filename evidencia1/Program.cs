using System;

namespace evidencia1
{
    class Program
    {
        public static void Main()
        {
            //almacena el tamanio del Array
            int total = 0;
            //indica si el numero dado cumple con las caracteristicas de la conjetura 
            Boolean encontrado = false;
            //controla si se pasa en un do-while
            Boolean pasar = false;
            //variable para el segundo numero primo
            int b = 0;
            //contamos las interaciones que hace el for para 
            int iteraciones = 0;
            Console.WriteLine("Cuantos valores desea ingresar?");
            //paseamos a int la entrada y guardamos en total
            total = int.Parse(Console.ReadLine());
            //declaramos el array que guardara los numeros a los que se les aplicara la conjetura
            int[] numeros = new int[total];
            //ciclo para verificar que el tamanio del array sea menor a 16
            do
            {
                //si el tamanio es mayor a 16 lo pedimos de nuevo
                if (total > 16)
                {
                    Console.WriteLine("El tamaño debe ser menor a 16");
                    //guardamos de nuevo el tamanio nuevo
                    total = int.Parse(Console.ReadLine());
                }
            } while (total > 16);

            //ciclo para llenar el array dependiendo del tamanio
            for (int i = 0; i < total; i++)
            {
                //ciclo para validar el rango de los valores aceptables para llenar el array
                do
                {
                    Console.WriteLine("Ingrese el numero " + (i + 1) + " entre 200 y 600");
                    int aux = int.Parse(Console.ReadLine());
                    //si el numero que se indica es mayor o igual que 200 y menor o igual a 600 se acepta sino, se repite
                    if (aux >= 200 && aux <= 600)
                    {
                        //si se cumple la condicion se puede almacenar el valor, si no se repite
                        numeros[i] = aux;
                        pasar = true;
                    }
                } while (pasar != true);
            }

            //ciclo para tomar cada valor del array con la conjetura
            for (int j = 0; j < total; j++)
            {
                //se valida si es par o no 
                if (numeros[j] % 2 == 0 && numeros[j] > 2)
                {
                    Console.WriteLine("\nLos numero primos, sumados del " + numeros[j]);
                    //ciclo de inicio de conjetura, hace ciclo dependiendo el valor del numero guardado en el array en la posicopm j del ciclo anterior
                    for (int i = 2; i < numeros[j]; i++)
                    {
                        //nos retorna un boolean si es primo o no el valor.
                        if (Primo(i))
                        {
                            //una variable auxilioar b sera igual al valor del array dependiendo el ciclo m=menos el valor de i. de acuerdo a las reglas de la conjetura.
                            //ya que al pasar el if anterior, significa que el valor de i es primo, y para que la suma de estos 2 valores nos den el numero entero dado
                            //hacemo una resta para buscar cual es el primo que hace falta para completar el entero dado.
                            b = numeros[j] - i;
                            //validamos si el valor de b de acuerdo a la resta es primo o no
                            if (Primo(b))
                            {
                                //como ya se han encontrado los 2 valores cambiamos el estado de la variable encontrado para mas adelante en un if
                                encontrado = true;
                                //para evitar que una vez que tengamos un 97 y 103 por ejemplo, los numero se repitan pero en orden inverso, como 103 y 97. 
                                //son los mismos numeros per diferente orden.
                                if (i <= b)
                                {
                                    //imprimos los valores de los numeros primos
                                    Console.WriteLine("Los Numeros Primos Son- " + i + " , " + b);
                                }
                            }
                        }

                        //las iteraciones aumentan aqui por que termina el ciclo, de esa manera sabemos cuantas vueltas dio el ciclo para entontrar el resultado
                        iteraciones++;
                    }

                    //se imprimen las iteraciones
                    Console.WriteLine("El total de Intentos fue de: " + iteraciones);
                    //las reiniciamos, ya que una vez que se termine este cilo se iniciara con la otra posicon del array, asi de esta forma no se nos suman todas y nos
                    //da valores falsos
                    iteraciones = 0;
                    //si encontrado no cambia a entonces es por que no se encontro el valor. auque aun se desconoce si un numero no aplica con la conjetura
                    if (encontrado != true)
                    {
                        //se concatena la iteracion mas 1 para decir que numero no tiene pareja, recuerden que j inicia en cero
                        Console.WriteLine("No se ha encontrado ninguna pareja para el numero " + (j + 1));
                    }
                }
                //si se ingresa un numero impar nos imprime un mensaje 
                else
                {
                    Console.WriteLine("El numero " + (j + 1) + " no es un numero Par");
                }
            }
        }

        //funcion que nos valida y retona un boolean cuando verifique si el valor es o no es primo
        public static bool Primo(int num)
        {
            //se hace un array hasta el valor del numero que se le pase
            for (int i = 2; i < num; i++)
            {
                //si el numero es divisible entre la iteracion y el resultado es cero, entonces no es primo.
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}