using System.ComponentModel.DataAnnotations.Schema;

namespace AssurAmiBackEnd.Core.Entity
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {  get; set; }
        public string? Matricule { get; set; }
        public string? Name { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set;}
        public DateOnly? DateNaissance { get; set; }
        public string? Sexe { get; set; }
        public DateOnly? DateFeet { get; set; }
        public DateOnly? DateSortie { get; set; }
        public int IdGestionnaire { get; set; }
        public Gestionnaire? gestionnaire { get; set; } = null!;
        public int IdAssureur { get; set; }
        public Assureur? assureur { get; set; }=null!;
    }
}
