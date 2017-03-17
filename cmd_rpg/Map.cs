using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    class Map
    {
        public string MapName { get; set; }
        public List<MapSegment> Segments { get; set; }
        private Random Rand { get; set; }

        public Map(string pName, Random pRand)
        {
            Segments = new List<MapSegment>();
            Rand = pRand;
            BuildLand(new Position(0,0));
        }

        public void BuildLand(Position pLoc, int pDist = 1)
        {
            //pLoc marks the player location
            //We need to build all land around the player so that when the player travels in any direction we already have the land ready.
            /* Example:
                ###
                #*# Player is marked with *
                ### Land which we need to build is marked with #
            */

            for (int y = pLoc.Y - pDist; y <= pLoc.Y + pDist; y++)
            {
                for (int x = pLoc.X - pDist; x <= pLoc.X + pDist; x++)
                {
                    Position vSegLoc = new Position(x, y);
                    if (!LandExists(vSegLoc))
                    {
                        MapSegment vSegment = new MapSegment(Rand, vSegLoc);
                        Segments.Add(vSegment);
                        Debug.WriteLine("Generated new land: " + vSegment);
                    }
                }
            }
        }
        public MapSegment GetSegment(Position pLoc)
        {
            return Segments.FirstOrDefault(v => v.Location == pLoc);
        }
        public bool LandExists(Position pLoc)
        {
            return GetSegment(pLoc) != null;
        }
    }

    class MapSegment
    {
        //public const int SEGMENTSIZE = 50;

        public Biome MapBiome   { get; set; }
        public int Trees        { get; private set; }
        public Position Location   { get; private set; }

        public MapSegment(Random pRand, Position pLoc)
        {
            Generate(pRand, pLoc);
        }

        public void Generate(Random pRand, Position pLoc)
        {
            MapBiome = (Biome)pRand.Next(3);
            Location = pLoc;

            switch (MapBiome)
            {
                case Biome.Plains:
                    Trees = pRand.Next(10);
                    break;
                case Biome.Forrest:
                    Trees = pRand.Next(50);
                    break;
                case Biome.Swamp:
                    Trees = pRand.Next(30);
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("Mapsegment @ {0}\tBiome: {1}", Location, MapBiome);
        }
    }
}
