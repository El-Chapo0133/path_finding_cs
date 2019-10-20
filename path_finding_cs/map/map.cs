using System;
using System.Linq;

namespace path_finding_cs.map {
    class Map
    {
        const int MAXX = 40, MAXY = 30, ZERO = 0, EMPTY = 0, STARTPOINT = 1, DESTPOINT = 2, WALL = 3, STARTPOINTX = 10, STARTPOINTY = 15, DESTPOINTX = 30, DESTPOINTY = 15;
        private byte[,] map = new byte[MAXX, MAXY];
        public Map() {
            /** set starting point en dest point by default */
            this.map[STARTPOINTX, STARTPOINTY] = STARTPOINT;
            this.map[DESTPOINTX, DESTPOINTY] = DESTPOINT;
        }
        public byte getElement(int x, int y) {
            return this.map[x, y];
        }
        public byte[,] getMap() {
            return this.map;
        }
        public void setElement(int x, int y, byte value) {
            this.map[x, y] = value;
        }
        public void createWall(int x, int y) {
            this.map[x, y] = WALL;
        }
        public void disposeWall(int x, int y) {
            this.map[x, y] = EMPTY;
        }
        public int[] getStartPoint()
        {
            int[] values = new int[3];

            values[0] = STARTPOINTX;
            values[1] = STARTPOINTY;
            values[2] = this.map[STARTPOINTX, STARTPOINTY];

            return values;
        }
        public int[] getDestPoint()
        {
            int[] values = new int[3];

            values[0] = DESTPOINTX;
            values[1] = DESTPOINTY;
            values[2] = this.map[DESTPOINTX, DESTPOINTY];

            return values;
        }
        public void reset()
        {
            for (int indexX = 0; indexX < MAXX; indexX++) 
            {
                for (int indexY = 0; indexY < MAXY; indexY++)
                {
                    this.map[indexX, indexY] = EMPTY;
                }
            }
            this.map[STARTPOINTX, STARTPOINTY] = STARTPOINT;
            this.map[DESTPOINTX, DESTPOINTY] = DESTPOINT;
        }
        /// moveElement
        /// move anyElement from an origin to a destination, origin wil be remplaced by EMPTY
        /// <param name="origin_x">origin point X</param>
        /// <param name="origin_y">origin point Y</param>
        /// <param name="dest_x">destination point X</param>
        /// <param name="dest_y">destination point Y</param>
        public void moveElement(int origin_x, int origin_y, int dest_x, int dest_y) {
            this.map[dest_x, dest_y] = this.map[origin_x, origin_y];
            this.map[origin_x, origin_y] = EMPTY;
        }
        /// isValueRight
        /// check is the value is any of your accepted value
        /// <param name="value">value input</param>
        private bool isValueRight(byte value) {
            if (Enumerable.Range(EMPTY, WALL).Contains(value)) {
                return true;
            } else {
                return false;
            }
        }
        private bool isInMapX(int value) {
            if (Enumerable.Range(0, MAXX).Contains(value)) {
                return true;
            } else {
                return false;
            }
        }
        private bool isInMapY(int value) {
            if (Enumerable.Range(0, MAXY).Contains(value)) {
                return true;
            } else {
                return false;
            }
        }
    }
}