using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriatgePeces
{
    public class Peca
    {
        public string Tipus { get; set; } = string.Empty;
        public double Area { get; set; }
        public string Data { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }
}
