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
        throw new NotImplementedException();
    }
}
