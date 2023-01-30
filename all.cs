using System;

class Program
{
    static void output_mass(int[] mass)
    {
        for (int i = 0; i < mass.Length; i++)
        {
            Console.Write($"{mass[i]} ");
        }
        Console.WriteLine();
    }
    static void input_mass(out int[] mass, int a)
    {
        mass = new int[a];
        int k = 0;
        Console.WriteLine("Введите массив поштучно");
        for (int i = 0; i < a; i++)
        {
            mass[k] = Convert.ToInt32(Console.ReadLine());
            k++;
        }
    }
    static void bet_mx_and_mn(ref int[] mass)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        int min_ps = 0, max_ps = 0;
        for (int i = 0; i < mass.Length; i++)
        {
            if (mass[i] < min)
            {
                min = mass[i];
                min_ps = i;
            }
            if (mass[i] > max) max = mass[i];
        }
        for (int i = 0; i < mass.Length; i++)
        {
            if (mass[i] == max)
            {
                max_ps = i;
                break;
            }

        }
        if (min_ps > max_ps)
        {
            int temp = min_ps;
            min_ps = max_ps;
            max_ps = temp;
        }
        int[] a = new int[max_ps - min_ps - 1];
        int k = 0;
        for (int i = min_ps + 1; i < max_ps; i++)
        {
            a[k] = mass[i];
            k++;
        }
        mass = a;
    }
    static void cyclic_shift(ref int[] mass, int k) // в обе
    {
        int temp;
        if (k < 0)
        {
            while (k < 0)
            {
                temp = mass[mass.Length - 1];

                for (int i = mass.Length - 1; i != 0; i--) mass[i] = mass[i - 1];

                mass[0] = temp;
                k++;
            }
            
        }
        else
        {
            while (k > 0)
            {
                temp = mass[0];
                for (int i = 1; i < mass.Length; i++)
                {
                    mass[i - 1] = mass[i];
                }
                mass[mass.Length - 1] = temp;
                k--;
            }
        }
    }
    static void intersection(int[] mass1, int[] mass2)
    {
        bool f = true;
        for (int i = 0; i < mass1.Length; i++)
        {
            for (int j = 0; j < mass2.Length; j++)
            {
                if (mass1[i] == mass2[j]) {
                    f = true;
                    for (int i1 = 0; i1 < i; i1++)
                    {
                        if (mass1[i1] == mass1[i]) { 
                            f = false;
                            break;
                        }
                    }
                    if (f)
                    {
                        Console.Write($"{mass1[i]} ");
                        f = false;
                        break;
                    }
                }
            }
        }
        Console.WriteLine();
    }
    static void del_same(ref int[] mass3)
    {
        int[] a = new int[mass3.Length];
        int i = 0;
        int j = 0;
        int k = 0;
        while (i < mass3.Length - 1)
        {
            if (mass3[i] == mass3[i + 1])
            {
                a[k] = mass3[i];
                k++;
                for (j = i + 1; j < mass3.Length - 1; j++)
                {
                    if (mass3[j] != mass3[j + 1]) break;

                }
                i = j;
            }
            else
            {
                i++;
            }

        }

        mass3 = a;
    }
    public static void Main()
    {
        //Console.WriteLine("Введите длину массива, из которого будет удалены элементы, которые не идут меньше первым большим и последним меньшим элементом");
        //int a = Convert.ToInt32(Console.ReadLine());
        //int[] mass = new int[a];
        //input_mass(out mass, a);
        //bet_mx_and_mn(ref mass);
        //Console.WriteLine("Обработанный массив: ");
        //output_mass(mass);
        Console.WriteLine("Введите длину массива, в котором нужно циклически сдвинуть элементы");
        int a4 = Convert.ToInt32(Console.ReadLine());
        int[] mass4 = new int[a4];
        input_mass(out mass4, a4);
        Console.WriteLine("Введите количество элементов, на которое нужно сдвинуть массив циклически влево");
        int k = Convert.ToInt32(Console.ReadLine());
        cyclic_shift(ref mass4, k);
        Console.WriteLine("Циклически сдвинутый массив : ");
        output_mass(mass4);
        Console.WriteLine("Введите длинну первого массива, для которого буде применено пересечение множеств");
        int a1 = Convert.ToInt32(Console.ReadLine());
        int[] mass1 = new int[a1];
        input_mass(out mass1, a1);
        Console.WriteLine("Введите длинну второго массива, для которого буде применено пересечение множеств");
        int a2 = Convert.ToInt32(Console.ReadLine());
        int[] mass2 = new int[a2];
        input_mass(out mass2, a2);
        Console.WriteLine("Объединение: ");
        intersection(mass1, mass2);
        //Console.WriteLine("Введите длину массива, из которого будет удалены одинаковые идущие эллементы");
        //int a3 = Convert.ToInt32(Console.ReadLine());
        //int[] mass3 = new int[a3];
        //input_mass(out mass3, a3);
        //del_same(ref mass3);
        //Console.WriteLine("Массив без повторяющихся идущих подряд элементов: ");
        //output_mass(mass3);
    }
}
