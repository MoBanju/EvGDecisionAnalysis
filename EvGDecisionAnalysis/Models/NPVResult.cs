using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvGDecisionAnalysis.Models
{
    public class NPVResult
    {
        public int Id { get; set; }
        public double NPVE1 { get; set; }
        public double PE1 { get; set; }
        public double NPVE2 { get; set; }
        public double PE2 { get; set; }
        public double CalculatedNPV { get; set; }
    }
}
