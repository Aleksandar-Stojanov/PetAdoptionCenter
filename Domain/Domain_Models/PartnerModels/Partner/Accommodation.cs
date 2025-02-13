using System;
using System.Collections.Generic;

namespace PetAdoptionCenter.Domain.Domain_Models.PartnerModels.Partner;

public partial class Accommodation
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public decimal PricePerNight { get; set; }

    public int MaxNumberOfRooms { get; set; }

    public virtual ICollection<TravelPackage> TravelPackages { get; set; } = new List<TravelPackage>();
}
