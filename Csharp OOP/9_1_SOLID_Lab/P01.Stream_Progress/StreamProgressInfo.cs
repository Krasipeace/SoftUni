namespace Stream_Progress
{
    public class StreamProgressInfo
    {
        private readonly IStream stream;

        public StreamProgressInfo(IStream stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }
    }
}
