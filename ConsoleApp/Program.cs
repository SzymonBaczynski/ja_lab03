using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("DllAsm.dll")]
    private static unsafe extern int ProcSum(int *pArr, int arrLen);

    static int[] n1Array = { 12, 10, 10, 10, 10, 10, 10, 10, 10, 13, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11 };

    [DllImport("DLLAsm.dll")]
    private static unsafe extern int ProcMean(StructToMean* structurePtr);

    public static float[] a1 = { 8, 4, 6, 8, 10, 12, 14, 16, 2, 4, 6, 8, 10, 12, 14, 16 };
    public static float[] a2 = { 5, 6, 9, 12, 15, 18, 3, 6, 9, 12, 15, 18, 3, 6, 9, 12 };
    public static float[] a3 = new float[16];

    public static StructToMean meanStruct = new StructToMean();

    static void Main(string[] args)
    {
        unsafe
        {
            fixed (int* pArr = &n1Array[0])
            {
                int sum = ProcSum(pArr, 20);
                Console.WriteLine("Suma tablicy:");
                Console.WriteLine(sum + "\n");
            }

            fixed (StructToMean* aAddress = &meanStruct)
            {
                fixed (float* ptr1 = a1, ptr2 = a2, ptr3 = a3)
                {
                    meanStruct.tab1 = ptr1;
                    meanStruct.tab2 = ptr2;
                    meanStruct.tab3 = ptr3;

                    ProcMean(aAddress);
                };
            }

            Console.WriteLine("Spodziewane wartości:");

            for (var i = 0; i < 16; i++)
                Console.Write($"{(a1[i] + a2[i]) / 2}; ");

            Console.WriteLine("\nOtrzymane wartości:");

            for (var i = 0; i < 16; i++)
                Console.Write($"{a3[i]}; ");
        }  
    }
}



