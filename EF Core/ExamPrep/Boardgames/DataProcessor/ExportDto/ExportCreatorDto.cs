namespace Boardgames.DataProcessor.ExportDto
{
    using System.Xml.Serialization;
    
    [XmlType("Creator")]
    public class ExportCreatorDto
    {
        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }

        [XmlElement("CreatorName")]
        public string CreatorName { get; set; } 

        [XmlArray("Boardgames")]
        public List<ExportBoardgameDto> Boardgames { get; set; } = new List<ExportBoardgameDto>();
    }
}
