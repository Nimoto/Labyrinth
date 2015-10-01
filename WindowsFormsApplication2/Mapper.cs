using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Mapper
    {
        private string path = "maps\\map.txt";
        private int width;
        private int height;
        int[][] map;
        private List<Polygon> polygons = new List<Polygon>();
        private List<Polygon> polygonsFloor = new List<Polygon>();
        private List<Polygon> polygonsTop = new List<Polygon>();

        public List<Polygon> Polygons
        {
            get
            {
                return this.polygons;
            }
        }

        public List<Polygon> PolygonsFloor
        {
            get
            {
                return this.polygonsFloor;
            }
        }

        public List<Polygon> PolygonsTop
        {
            get
            {
                return this.polygonsTop;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
        }

        public Mapper() {
            FileReader();
            PolygonCreated();
            this.width = this.height = this.map.Length * this.map.Length;
        }


        private void FileReader(){
            string line;
            int count = 0, i;
            string[] letters;
            char separator = char.Parse(",");
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            int rowsCnt = System.IO.File.ReadAllLines(path).Length;
            this.map = new int[rowsCnt][];
            while ((line = file.ReadLine()) != null)
            {
                letters = line.Split(separator);
                this.map[count] = new int[letters.Count<string>()];
                i = 0;
                foreach (string letter in letters) {
                    this.map[count][i++] = int.Parse(letter);
                }
                count++;
            }
            file.Close();
        }

        public List<Polygon> PolygonCreated() {
            Color color = Color.Gray;
            int wallHeight = 30;
            int cellSize = 30;
            int i = 0, j = 0;
            int x0, x1, y0, y1, z0, z1, count = 0;
            int[][][] arrLCoord = new int[this.map.Length * this.map.Length * 6][][];

            for (i = 0; i < this.map.Length; i++) {
                for (j = 0; j < this.map.Length; j++)
                {
                    x0 = i * cellSize;
                    x1 = x0 + cellSize;
                    y0 = 0;
                    y1 = wallHeight;
                    z0 = j * cellSize;
                    z1 = z0 + cellSize;
                    if (this.map[i][j] == 1)
                    {
                        arrLCoord[count] = new int[4][];
                        for (int k = 0; k < 4; k++)
                        {
                            arrLCoord[count][k] = new int[3];
                        }

                        arrLCoord[count][0][0] = x0;
                        arrLCoord[count][0][1] = y0;
                        arrLCoord[count][0][2] = z0;

                        arrLCoord[count][1][0] = x1;
                        arrLCoord[count][1][1] = y0;
                        arrLCoord[count][1][2] = z0;

                        arrLCoord[count][2][0] = x1;
                        arrLCoord[count][2][1] = y1;
                        arrLCoord[count][2][2] = z0;

                        arrLCoord[count][3][0] = x0;
                        arrLCoord[count][3][1] = y1;
                        arrLCoord[count][3][2] = z0;

                        Polygon polygon1 = new Polygon(arrLCoord[count], color);
                        polygons.Add(polygon1);
                        count++;

                        arrLCoord[count] = new int[4][];
                        for (int k = 0; k < 4; k++)
                        {
                            arrLCoord[count][k] = new int[3];
                        }

                        arrLCoord[count][0][0] = x0;
                        arrLCoord[count][0][1] = y0;
                        arrLCoord[count][0][2] = z0;

                        arrLCoord[count][1][0] = x0;
                        arrLCoord[count][1][1] = y0;
                        arrLCoord[count][1][2] = z1;

                        arrLCoord[count][2][0] = x0;
                        arrLCoord[count][2][1] = y1;
                        arrLCoord[count][2][2] = z1;

                        arrLCoord[count][3][0] = x0;
                        arrLCoord[count][3][1] = y1;
                        arrLCoord[count][3][2] = z0;

                        Polygon polygon2 = new Polygon(arrLCoord[count], color);
                        polygons.Add(polygon2);
                        count++;

                        arrLCoord[count] = new int[4][];
                        for (int k = 0; k < 4; k++)
                        {
                            arrLCoord[count][k] = new int[3];
                        }

                        arrLCoord[count][0][0] = x0;
                        arrLCoord[count][0][1] = y0;
                        arrLCoord[count][0][2] = z1;

                        arrLCoord[count][1][0] = x1;
                        arrLCoord[count][1][1] = y0;
                        arrLCoord[count][1][2] = z1;

                        arrLCoord[count][2][0] = x1;
                        arrLCoord[count][2][1] = y1;
                        arrLCoord[count][2][2] = z1;

                        arrLCoord[count][3][0] = x0;
                        arrLCoord[count][3][1] = y1;
                        arrLCoord[count][3][2] = z1;

                        Polygon polygon3 = new Polygon(arrLCoord[count], color);
                        polygons.Add(polygon3);
                        count++;

                        arrLCoord[count] = new int[4][];
                        for (int k = 0; k < 4; k++)
                        {
                            arrLCoord[count][k] = new int[3];
                        }

                        arrLCoord[count][0][0] = x1;
                        arrLCoord[count][0][1] = y0;
                        arrLCoord[count][0][2] = z0;

                        arrLCoord[count][1][0] = x1;
                        arrLCoord[count][1][1] = y1;
                        arrLCoord[count][1][2] = z0;

                        arrLCoord[count][2][0] = x1;
                        arrLCoord[count][2][1] = y1;
                        arrLCoord[count][2][2] = z1;

                        arrLCoord[count][3][0] = x1;
                        arrLCoord[count][3][1] = y0;
                        arrLCoord[count][3][2] = z1;

                        Polygon polygon4 = new Polygon(arrLCoord[count], color);
                        polygons.Add(polygon4);
                        count++;
                    }
                    arrLCoord[count] = new int[4][];
                    for (int k = 0; k < 4; k++)
                    {
                        arrLCoord[count][k] = new int[3];
                    }
                    arrLCoord[count][0][0] = x1;
                    arrLCoord[count][0][1] = y0;
                    arrLCoord[count][0][2] = z0;

                    arrLCoord[count][1][0] = x1;
                    arrLCoord[count][1][1] = y0;
                    arrLCoord[count][1][2] = z1;

                    arrLCoord[count][2][0] = x0;
                    arrLCoord[count][2][1] = y0;
                    arrLCoord[count][2][2] = z1;

                    arrLCoord[count][3][0] = x0;
                    arrLCoord[count][3][1] = y0;
                    arrLCoord[count][3][2] = z0;

                    Polygon polygon5 = new Polygon(arrLCoord[count], color);
                    polygonsFloor.Add(polygon5);
                    count++;


                    arrLCoord[count] = new int[4][];
                    for (int k = 0; k < 4; k++)
                    {
                        arrLCoord[count][k] = new int[3];
                    }
                    arrLCoord[count][0][0] = x1;
                    arrLCoord[count][0][1] = y1;
                    arrLCoord[count][0][2] = z0;

                    arrLCoord[count][1][0] = x1;
                    arrLCoord[count][1][1] = y1;
                    arrLCoord[count][1][2] = z1;

                    arrLCoord[count][2][0] = x0;
                    arrLCoord[count][2][1] = y1;
                    arrLCoord[count][2][2] = z1;

                    arrLCoord[count][3][0] = x0;
                    arrLCoord[count][3][1] = y1;
                    arrLCoord[count][3][2] = z0;

                    Polygon polygon6 = new Polygon(arrLCoord[count], color);
                    polygonsTop.Add(polygon6);
                    count++;
                }
            }
            return polygons;
        }
    }
}
