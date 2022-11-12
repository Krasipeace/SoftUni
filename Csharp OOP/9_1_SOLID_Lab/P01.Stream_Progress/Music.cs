namespace Stream_Progress
{
    public class Music : IStream
    {
        public Music(string artist, string album, int length, int bytesSent)
        {
            this.Artist = artist;
            this.Album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }
        public string Artist { get; private set; }
        public string Album { get; private set; }
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
