using System; // все работает только с положительными числами

class Program
{
    static void output_mass(int[] mass)
    {
        for (int i = 0; i < mass.Length; i++)
        {
            Console.WriteLine(mass[i]);
        }
    }
    static void input_mass(out int[] mass, int a){
        mass= new int[a+1];
        int k = 0;
            for (int i = 0; i <= a; i++)
            {
                mass[k] = Convert.ToInt32(Console.ReadLine());
                k++;
            }        
    }
    static void bet_mx_and_mn(int[] mass)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        int min_ps=0, max_ps=0;
        for (int i = 0; i < mass.Length; i++)
        {
            if (mass[i] < min) { 
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
            min_ps=max_ps;
            max_ps = temp;
        }
        int[] a = new int[max_ps - min_ps-1];
        int k = 0;
        for (int i = min_ps+1; i < max_ps; i++)
        {
            a[k] = mass[i];
            k++;
        }
        output_mass(a);
    }
    static void cyclic_shift(int [] mass, int k)
    {
        int  temp;
        while (k > 0)
        {
            temp = mass[0];
            for (int i =1; i < mass.Length; i++)
            {
                mass[i-1] = mass[i];
            }
            mass[mass.Length-1] = temp;
            k--;
        }
    }
    static void intersection(int[] mass1, int[] mass2)
    {
        for (int i = 0; i < mass1.Length; i++)
        {
            for (int j = 0; j < mass2.Length; j++)
            {
                if (mass1[i] == mass2[j]) { Console.WriteLine(mass1[i]); break; }
            }
        }
    }
    static void del_same(ref int [] mass3)
    {
        int[] a = new int[mass3.Length];
        int i = 0;
        int j = 0;
        int k = 0;
        while ( i < mass3.Length-1) {
            if (mass3[i] == mass3[i+1]) {
                a[k] = mass3[i];
                k++;
                for (j = i+1; j < mass3.Length-1; j++) {
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
        int a = Convert.ToInt32(Console.ReadLine());
        int[] mass = new int[a+1];
        input_mass(out mass, a);
        bet_mx_and_mn(mass);
        Console.WriteLine("_____________");
        int k = Convert.ToInt32(Console.ReadLine());
        cyclic_shift(mass, k);
        Console.WriteLine("________________");
        int a1 = Convert.ToInt32(Console.ReadLine());
        int[] mass1 = new int[a1 + 1];
        int[] mass2 = new int[a1 + 1];
        input_mass(out mass1, a1);
        input_mass(out mass2, a1);
        int a2 = Convert.ToInt32(Console.ReadLine());
        int[] mass3 = new int[a2 + 1];
        input_mass(out mass3, a2);

        del_same(ref mass);
        output_mass(mass);
    }
}
