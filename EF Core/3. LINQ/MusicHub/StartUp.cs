namespace MusicHub;

using System;
using System.Globalization;
using System.Text;
using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        DbInitializer.ResetDatabase(context);

        //Test your solutions here
        // - 2. All Albums Produced by Given Producer
        string result = ExportAlbumsInfo(context, 9);
        Console.WriteLine(result);

        // - 3. Songs Above Given Duration
        string result2 = ExportSongsAboveDuration(context, 4);
        Console.WriteLine(result2);
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        var albumInfo = context.Albums
            .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
            .ToArray()
            .OrderByDescending(a => a.Price)
            .Select(a => new
            {
                a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer.Name,
                Songs = a.Songs.Select(s => new
                {
                    SongName = s.Name,
                    Price = s.Price.ToString("f2"),
                    Writer = s.Writer.Name
                })
                .OrderByDescending(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ToArray(),
                AlbumPrice = a.Price.ToString("f2")
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var album in albumInfo)
        {
            sb
                .AppendLine($"-AlbumName: {album.Name}")
                .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                .AppendLine($"-ProducerName: {album.ProducerName}")
                .AppendLine($"-Songs:");

            int songCounter = 1;

            foreach (var song in album.Songs)
            {
                sb
                    .AppendLine($"---#{songCounter}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Price: {song.Price}")
                    .AppendLine($"---Writer: {song.Writer}");

                songCounter++;
            }

            sb.AppendLine($"-AlbumPrice: {album.AlbumPrice}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        var songInfo = context.Songs
            .AsEnumerable()
            .Where(s => s.Duration.TotalSeconds > duration)
            .Select(s => new
            {
                s.Name,
                Performers = s.SongPerformers
                    .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                    .OrderBy(p => p)
                    .ToArray(),
                WriterName = s.Writer.Name,
                AlbumProducer = s.Album.Producer.Name,
                Duration = s.Duration.ToString("c")
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.WriterName)
            .ToArray();

        int songCounter = 1;
        StringBuilder sb = new StringBuilder();

        foreach (var song in songInfo)
        {
            sb
                .AppendLine($"-Song #{songCounter}")
                .AppendLine($"---SongName: {song.Name}")
                .AppendLine($"---Writer: {song.WriterName}");

            foreach (var performer in song.Performers)
            {
                sb
                    .AppendLine($"---Performer: {performer}");
            }

            sb
                .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                .AppendLine($"---Duration: {song.Duration}");

            songCounter++;
        }

        return sb.ToString().TrimEnd();
    }
}
