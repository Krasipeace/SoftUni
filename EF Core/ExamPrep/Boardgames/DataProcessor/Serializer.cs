namespace Boardgames.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames
                .Any())
                .Include(c => c.Boardgames)
                .AsNoTracking()
                .ToList()
                .Select(c => new ExportCreatorDto()
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    Boardgames = c.Boardgames
                    .Select(b => new ExportBoardgameDto()
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished,
                    })
                    .OrderBy(b => b.BoardgameName)
                    .ToList()
                })
                .OrderByDescending(c => c.Boardgames.Count)
                .ThenBy(c => c.CreatorName)
                .ToList();

            return Serialize(creators, out StringWriter writer);
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers
                    .Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Include(s => s.BoardgamesSellers)
                .ThenInclude(bs => bs.Boardgame)
                .AsNoTracking()
                .ToList()
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                    .Select(bs => new
                    {
                        bs.Boardgame.Name,
                        bs.Boardgame.Rating,
                        bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                    .ToList()
                })
                .OrderByDescending(s => s.Boardgames.Count)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToList();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }

        private static string Serialize(List<ExportCreatorDto> creators, out StringWriter writer)
        {
            var sb = new StringBuilder();
            var root = new XmlRootAttribute("Creators");
            var serializer = new XmlSerializer(typeof(List<ExportCreatorDto>), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            writer = new StringWriter(sb);
            serializer.Serialize(writer, creators, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}