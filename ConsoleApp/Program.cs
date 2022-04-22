using System;
using System.Runtime.InteropServices;


//     Zsumowanie wektora danych typu uint (zadeklarowanych po stronie , NET w postaci tablicy1.
//     jednowymiarowej o wymiarze 20 zmiennych). Funkcja ma zwracać pojedynczą wartość (przez
//     rejestr). Wskaźnik na tablicę źródłową oraz jej długość należy podać do funkcji w assemblerze
//     poprzez rejestry.

class Program
{
    [DllImport("DllAsm.dll")]
    private static unsafe extern int ProcAsm3(int *pTablica, int dlTablicy);

    static int[] n1Array = { 12, 10, 10, 10, 10, 10, 10, 10, 10, 13, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11 };

    [DllImport("DLLAsm.dll")]
    private static unsafe extern int Srednia(StructToMean* structurePtr);

    public static float[] a1 = { 8, 4, 6, 8, 10, 12, 14, 16, 2, 4, 6, 8, 10, 12, 14, 16 };
    public static float[] a2 = { 5, 6, 9, 12, 15, 18, 3, 6, 9, 12, 15, 18, 3, 6, 9, 12 };
    public static float[] a3 = new float[16];

    public static StructToMean meanStruct = new StructToMean();

    static void Main(string[] args)
    {
        unsafe
        {
            fixed (int* pTablica = &n1Array[0])
            {
                int c = ProcAsm3(pTablica, 20);
                Console.WriteLine(c);
            }

            fixed (StructToMean* aAddress = &meanStruct)
            {
                fixed (float* ptr1 = a1, ptr2 = a2, ptr3 = a3)
                {
                    meanStruct.tab1 = ptr1;
                    meanStruct.tab2 = ptr2;
                    meanStruct.tab3 = ptr3;

                    Srednia(aAddress);
                };
            }

            Console.WriteLine("Spodziewane wartości:");

            for (var i = 0; i < 16; i++)
                Console.Write($"{(a1[i] + a2[i]) / 2}; ");

            Console.WriteLine("\n Otrzymane wartości:");

            for (var i = 0; i < 16; i++)
                Console.Write($"{a3[i]}; ");
        }  
    }
}

/*class Program
{
    [DllImport("DllAsm.dll")]
    private static unsafe extern int ProcAsm2(int* a, int pos);

    static int[] n1Array = { 1, 2, 3, 4, 5, 6 };
    static void Main(string[] args)
    {

        unsafe
        {
            fixed (int* aAddress = &n1Array[0])
            {
                int c = ProcAsm2(aAddress, 5);
                System.Console.WriteLine(c);
            }
        }

    }
}*/



/*class Program
{
    [DllImport("DllAsm.dll")]
    private static extern int ProcAsm1(int a, int b);
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        unsafe
        {
            int c = ProcAsm1(a, b);
            System.Console.WriteLine(c);
        }
    }
}*/


