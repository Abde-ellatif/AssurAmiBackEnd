using System.ComponentModel.DataAnnotations.Schema;

namespace AssurAmiBackEnd.Core.Entity
{
    public class Assureur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? CodeAssureur {  get; set; }
        public string? libelet { get; set; }
        public ICollection<Client>clients { get; set; }=new List<Client>();
    }
}
