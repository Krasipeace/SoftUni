namespace Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStream file = new File("Filename", 100, 50);
            IStream music = new Music("T3", "T4", 100, 30);

            StreamProgressInfo streamProgress = new StreamProgressInfo(file);
            streamProgress = new StreamProgressInfo(music);
        }
    }
}
