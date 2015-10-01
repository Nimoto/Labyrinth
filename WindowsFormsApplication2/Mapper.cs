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
        //private int[][] map = new int[10][];
        //private string path = "D:\Проекты\WindowsFormsApplication2\WindowsFormsApplication2\img\pol.jpg";
        private string path = "maps\\map.txt";

        private int[][] FileReader(){
            int[][] map = new int[10][];
            string line;
            int count = 0, i;
            string[] letters = new string[10];
            char separator = char.Parse(",");
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            while ((line = file.ReadLine()) != null)
            {
                map[count] = new int[10];
                letters = line.Split(separator);
                i = 0;
                foreach (string letter in letters) {
                    map[count][i++] = int.Parse(letter);
                }
                count++;
            }
            file.Close();
            return map;
        }

        public List<Polygon> PolygonCreated() {
            Color color = Color.Blue;
            int[][] map = FileReader();
            List<Polygon> polygons = new List<Polygon>();
            int wallHeight = 30;
            int cellSize = 30;
            int i = 0, j = 0;
            int x0, x1, y0, y1, z0, z1, count = 0;
            int[][][] arrLCoord = new int[400][][];
            for (i = 0; i < 10; i++) {
                for (j = 0; j < 10; j++) {
                    if (map[i][j] == 1) {
                        arrLCoord[count] = new int[4][];
                        for (int k = 0; k < 4; k++)
                        {
                            arrLCoord[count][k] = new int[3];
                        }
                        x0 = i * cellSize;
                        x1 = x0 + cellSize;
                        y0 = 0;
                        y1 = wallHeight;
                        z0 = j * cellSize;
                        z1 = z0 + cellSize;

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
                }
            }
            return polygons;
        }
    }
}
