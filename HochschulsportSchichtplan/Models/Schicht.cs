using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HochschulsportSchichtplan.Models
{
    public class Schicht
    {
        public int Id { get; set; }
        public string SchichtName{ get; set; }

        [DataType(DataType.Date)]
        public DateTime Tag { get; set; }

        [DataType(DataType.Time)]
        public DateTime Start{ get; set; }

        [DataType(DataType.Time)]
        public DateTime Ende { get; set; }

        public List<ApplicationUser> Inhaber{ get; set; }
        public Decimal Stunden { get; set; }
    }
}

