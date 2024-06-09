using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class TramiteByMonthResponse
    {
        public int EstadoAprobado {  get; set; }
        public int EstadoRevision {  get; set; }
        public int EstadoRechazado { get; set; }
    }
}
