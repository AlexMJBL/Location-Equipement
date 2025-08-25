using System;
using System.Collections.Generic;

namespace LocationEquipementApi.Entites;

public partial class Equipement
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
