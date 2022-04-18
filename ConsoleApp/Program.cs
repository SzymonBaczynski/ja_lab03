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
    static void Main(string[] args)
    {
        unsafe
        {
            fixed (int* pTablica = &n1Array[0])
            {
                int c = ProcAsm3(pTablica, 20);
                System.Console.WriteLine(c);
            }
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


