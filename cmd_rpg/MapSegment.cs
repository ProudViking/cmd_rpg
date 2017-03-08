using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_rpg
{
    public enum Biome
    {
        Plains,
        Forrest,
        Swamp
    }

    class MapSegment
    {
        public const int SEGMENTSIZE = 50;

        public Biome MapBiome { get; set; }
        public int Trees { get; private set; }
        

        public MapSegment(Biome pBiome)
        {

        }

        private void Generate(Biome pBiome, int pSeed)
        {
            Random vRandom = new Random(pSeed);

            switch(pBiome)
            {
                case Biome.Plains:

                    break;
            }
        }
    }
}
