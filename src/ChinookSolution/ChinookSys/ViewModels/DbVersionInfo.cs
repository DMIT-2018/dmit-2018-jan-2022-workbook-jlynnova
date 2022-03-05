using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSys.ViewModels
{
    public class DbVersionInfo
    {

        //the view is used by the "outside user"
        //access must match the method where the class is used (typically public)
        //purpose: used to simply carry data
        //          consists of the "raw data" of the query
        //          create data fields as auto implemented properties
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; } 
        public DateTime ReleaseDate { get; set; }
    }
}
