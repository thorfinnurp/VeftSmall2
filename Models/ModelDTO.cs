namespace template.Models
{
    public class ModelDto : HyperMediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public double Price { get; set; }

        public static implicit operator ModelDto(Model model)
        {
            return new ModelDto() {
                Id = model.Id,
                Name = model.Name,
                Race = model.Race,
                Price = model.Price
            };
        }
    }
}