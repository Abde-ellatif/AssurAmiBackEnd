using System.ComponentModel.DataAnnotations.Schema;

namespace AssurAmiBackEnd.Core.Entity
{
    public class FileStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {  get; set; }
        public string? NomFichier { get; set; }
        public DateTime? DateUpload { get; set; }
        public string? StockagePath { get; set; }
        public string? Status { get; set; }
        public string? Remarque { get; set;}
        public long ErreurId { get; set; }
        public Erreur Erreur { get; set; } = null!;
    }
}
