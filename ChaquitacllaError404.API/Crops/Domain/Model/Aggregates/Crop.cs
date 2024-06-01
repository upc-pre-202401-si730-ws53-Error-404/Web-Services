using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using System.Collections.Generic;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates
{
    public class Crop
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
        public ICollection<Sowing> Sowings { get; private set; } // Collection of Sowings

        public List<Disease> Diseases { get; private set; } 
        public List<Pest> Pests { get; private set; } 

        protected Crop()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Sowings = new List<Sowing>();
            this.Diseases = new List<Disease>();
            this.Pests = new List<Pest>();
        }

        public Crop(CreateCropCommand command)
        {
            this.Name = command.Name;
            this.Description = command.Description;
            this.Diseases = new List<Disease>();
            this.Pests = new List<Pest>();
        }
    }
}