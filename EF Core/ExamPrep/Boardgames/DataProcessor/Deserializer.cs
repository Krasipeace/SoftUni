namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;

    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var root = new XmlRootAttribute("Creators");
            var serializer = new XmlSerializer(typeof(List<ImportCreatorDto>), root);
            using var reader = new StringReader(xmlString);
            var creators = (List<ImportCreatorDto>)serializer.Deserialize(reader)!;

            var sb = new StringBuilder();
            var validCreators = new List<Creator>();
            foreach (var creator in creators)
            {
                if (!IsValid(creator))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var entity = new Creator()
                {
                    FirstName = creator.FirstName,
                    LastName = creator.LastName,
                    Boardgames = new List<Boardgame>()
                };

                foreach (var boardGame in creator.Boardgames)
                {
                    if (!IsValid(boardGame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validBoardgame = new Boardgame()
                    {
                        Name = boardGame.Name,
                        Rating = boardGame.Rating,
                        YearPublished = boardGame.YearPublished,
                        CategoryType = (CategoryType)boardGame.CategoryType,
                        Mechanics = boardGame.Mechanics
                    };
                    entity.Boardgames.Add(validBoardgame);
                }

                validCreators.Add(entity);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, entity.FirstName, entity.LastName, entity.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sellers = JsonConvert.DeserializeObject<List<ImportSellerDto>>(jsonString)!;
            var boardgamesIds = context.Boardgames
                .AsNoTracking()
                .Select(b => b.Id)
                .ToList();

            var validBoardgames = new List<Seller>();
            var sb = new StringBuilder();
            foreach (var dto in sellers)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var entity = new Seller()
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Country = dto.Country,
                    Website = dto.Website,
                    BoardgamesSellers = new List<BoardgameSeller>()
                };

                foreach (var id in dto.Boardgames.Distinct().ToList())
                {
                    if (!boardgamesIds.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var seller = new BoardgameSeller()
                    {
                        BoardgameId = id,
                        Seller = entity
                    };
                    entity.BoardgamesSellers.Add(seller);
                }
                validBoardgames.Add(entity);

                sb.AppendLine(string.Format(SuccessfullyImportedSeller, entity.Name, entity.BoardgamesSellers.Count));
            }
            context.Sellers.AddRange(validBoardgames);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
