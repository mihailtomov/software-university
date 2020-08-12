using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            var file = new File("test1", 100, 5);
            var music = new Music("test2", "album", 200, 10);

            var progressInfo1 = new StreamProgressInfo(file);
            var progressInfo2 = new StreamProgressInfo(music);

            Console.WriteLine(progressInfo1.CalculateCurrentPercent());
            Console.WriteLine(progressInfo2.CalculateCurrentPercent());
        }
    }
}
