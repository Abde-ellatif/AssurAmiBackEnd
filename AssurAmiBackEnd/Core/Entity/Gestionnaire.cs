using System.ComponentModel.DataAnnotations.Schema;

namespace AssurAmiBackEnd.Core.Entity
{
    public class Gestionnaire
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? CodeGestionnaire { get; set; }
        public string? Libellet { get; set; }
        public ICollection<Client> clients { get; set; } = new List<Client>();
    }
}
