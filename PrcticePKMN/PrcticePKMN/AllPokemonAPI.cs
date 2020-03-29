using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrcticePKMN
{
    class AllPokemonAPI
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }

        public List<AllPokemonResult> results { get; set; }
    }

    public class AllPokemonResult
    {
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
