using System.Collections.Generic;
using System.Linq;
using template.Models;
using template.Extensions;

namespace template.Extensions
{
    public static class ListExtensions
    {
        public static List<ModelDto> ToLightWeight(this List<Model> list, string language = "en-US") => list.Select(item => new ModelDto
        {
            Id = item.Id,
            Name = language == "en-US" ? item.Name : item.NameDE,
            Race = language == "en-US" ? item.Race : item.RaceDE,
            Price = item.Price
        }).ToList();
        public static List<ModelsDetailsDTO> ToDetails(this List<Model> list, string language = "en-US") => list.Select(item => new ModelsDetailsDTO 
        {
            Id = item.Id,
            Name = language == "en-US" ? item.Name : item.NameDE,
            Race = language == "en-US" ? item.Race : item.RaceDE,
            Price = item.Price,
            Description = language == "en-US" ? item.Description : item.DescriptionDE,
            Rarity = item.Rarity,
            DifficultyLevel = language == "en-US" ? item.DifficultyLevel : item.DifficultyLevelDE,
            YearOfRelease = item.YearOfRelease,
            ImageUrl = item.ImageUrl
        }).ToList();
    }
}