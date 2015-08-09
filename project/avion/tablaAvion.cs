using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace project
{
    [Table(Name = "[AEROLINEA_UAM].[dbo].[AVION]")]
    class tablaAvion
    {

            [Column(Name = "ID_AVION", IsPrimaryKey = true)]
            public int ID_AVION { get; set; }

            [Column]
            public string NOMBRE_AVION { get; set; }

            [Column]
            public int? ID_VUELO { get; set; }

            [Column]
            public string ESTADO { get; set; }
        }
    }


