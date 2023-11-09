internal class CSVReader
{
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("Test.csv");
        int line_count = 0;
        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            line_count++;
            // 첫 번째 행
            if (line_count == 1)
            {
                continue;
            }
            // 두 번째 행 부터
            else
            {
                // 열 나누기
                string[] data = line.Split(",");
                // 각 값들 출력
                foreach (string value in data)
                {
                    Console.Write(value + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}