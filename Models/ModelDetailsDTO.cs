namespace template.Models
{
    public class ModelsDetailsDTO : HyperMediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Rarity { get; set; }
        public string DifficultyLevel { get; set; }
        public int YearOfRelease { get; set; }
        public string ImageUrl { get; set; }
        public static implicit operator ModelsDetailsDTO(Model model)
        {
            return new ModelsDetailsDTO(){ 

                Id = model.Id, 
                Name = model.Name, 
                Race = model.Race, 
                Price = model.Price, 
                Description = model.Description, 
                Rarity = model.Rarity, 
                DifficultyLevel = model.DifficultyLevel, 
                YearOfRelease = model.YearOfRelease, 
                ImageUrl = model.ImageUrl 
            
            };
        }
        /* 
        public ModelsDetailsDTO(Model model) 
        {
            
            Id = model.Id; 
            Name = model.Name; 
            Race = model.Race; 
            Price = model.Price; 
            Description = model.Description; 
            Rarity = model.Rarity; 
            DifficultyLevel = model.DifficultyLevel; 
            YearOfRelease = model.YearOfRelease; 
            ImageUrl = model.ImageUrl; 
        }
        */
    }
}