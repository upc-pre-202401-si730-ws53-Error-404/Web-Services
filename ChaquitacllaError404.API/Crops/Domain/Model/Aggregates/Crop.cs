﻿using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

public class Crop
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string Name { get; private set; }
    public ICollection<Sowing> Sowings { get; private set; } // Collection of Sowings

    public List<CropsDiseases> CropDiseases { get; private set; } 

    public List<CropsPests> CropPests { get; private set; } 

    protected Crop()
    {
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.Sowings = new List<Sowing>();
        this.CropDiseases = new List<CropsDiseases>(); 
        this.CropPests = new List<CropsPests>();
    }

    public Crop(CreateCropCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
    }

    public Crop(UpdateCropCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
    }
    public void Update(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }
}