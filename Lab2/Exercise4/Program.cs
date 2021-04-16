namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Spiral spiral = new Spiral();
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 5, 6, 7 }, { 9, 8, 7 } };
            spiral.sprial(matrix);
        }
    }
}
