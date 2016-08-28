using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public class Drzwi //
    {
        public string opis;//wyświetla się po obejrzeniu drzwi
        public int id;
        public Drzwi(string desc, int Id)
        {
            opis = desc;
            id = Id;           
        }
    }
}
