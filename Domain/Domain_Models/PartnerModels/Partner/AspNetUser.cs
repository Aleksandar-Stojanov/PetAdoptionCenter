using System;
using System.Collections.Generic;

namespace PetAdoptionCenter.Domain.Domain_Models.PartnerModels.Partner;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();


}
