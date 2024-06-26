﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssurAmiBackEnd.Core.Entity
{
    public class Erreur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public long Id {  get; set; }
        public string? Erreurs { get; set; }
        public ICollection<FileStatus>? FileStatuses { get; set; }
    }
}
