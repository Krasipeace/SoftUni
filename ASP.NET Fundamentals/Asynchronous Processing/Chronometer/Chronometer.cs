using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private const string TimeFormat = @"mm\:ss\.ffff";

        private Stopwatch stopWatch;
        private List<string> laps;

        public Chronometer()
        {
            stopWatch = new Stopwatch();
            laps = new List<string>();
        }

        public string GetTime => stopWatch.Elapsed.ToString(TimeFormat);

        public List<string> Laps => laps;

        public string Lap()
        {
            string result = GetTime;
            laps.Add(result);

            return result;
        }

        public void Reset()
        {
            stopWatch.Reset();
            laps.Clear();
        }

        public void Start()
        {
            stopWatch.Start();
        }

        public void Stop()
        {
            stopWatch.Stop();
        }
    }
}
