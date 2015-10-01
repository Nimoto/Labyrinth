using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Labyrinth
    {
        private List<Polygon> polygons = new List<Polygon>();
        private List<Polygon> polygonsTop = new List<Polygon>();
        private List<Polygon> polygonsFloor = new List<Polygon>();

        public Labyrinth(List<Polygon> polygons, List<Polygon> polygonsTop, List<Polygon> polygonsFloor)
        {
            this.polygons = polygons;
            this.polygonsTop = polygonsTop;
            this.polygonsFloor = polygonsFloor;
        }

        public void DrawLabyrinth(Texture texture = null)
        {
            foreach (Polygon p in this.polygons)
            {
                p.Draw(texture);
            }
        }

        public void DrawFloor(Texture texture = null)
        {
            foreach (Polygon p in this.polygonsFloor)
            {
                p.Draw(texture);
            }
        }

        public void DrawTop(Texture texture = null)
        {
            foreach (Polygon p in this.polygonsTop)
            {
                p.Draw(texture);
            }
        }

    }
}
