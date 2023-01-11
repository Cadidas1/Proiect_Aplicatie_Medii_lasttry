using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace Proiect_Aplicatie_Medii_lasttry.Models
{
    public class Masina
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descriere { get; set; }
        [OneToMany]
        public List<ListaMasina> ListaMasini { get; set; }
    }
}
