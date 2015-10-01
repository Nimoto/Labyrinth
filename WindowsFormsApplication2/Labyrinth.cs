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

        public Labyrinth(List<Polygon> polygons)
        {
            this.polygons = polygons;
        }

        public void DrawLabyrinth(Texture texture = null)
        {
            foreach (Polygon p in this.polygons) {
                p.Draw(texture);
            }
        }

    }
}
