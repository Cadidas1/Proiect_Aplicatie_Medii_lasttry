using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace Proiect_Aplicatie_Medii_lasttry.Models
{
    public class ListaMasina
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Inchiriere))]
        public int InchiriereID { get; set; }
        public int MasinaID { get; set; }
    }
}
