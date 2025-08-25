namespace LocationEquipementApi.Dtos
{
    public class EquipementDto
    {

        //Permet d'evite de charger tout les location anterieur d'un equipement
        public int EquipementId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public bool Actif{ get; set; }
        public DateOnly? DateDe { get; set; }
        public DateOnly? DateA{get; set;}
    }
}
