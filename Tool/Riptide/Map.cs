using System;
using System.Collections.Generic;
using System.Drawing;

namespace riptide.Riptide
{
    public class Map
    {
        public DatFileEntry Entry { get; private set; }

        public bool Ready { get; private set; } = false;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public MapCell[] Cells { get; private set; }
        public MapTile[] Tiles { get; private set; }
        public Color[] Palette { get; private set; }
        public int[] Positions { get; private set; }

        public int PlayerSpawn = 0;


        public Map(DatFileEntry entry)
        {
            Entry = entry;

            int i = 0;

            Width = entry.Data[i];
            i += 2;
            Height = entry.Data[i];
            i += 2;

            loadPalette();

            // load cells
            int numCells = Width * Height;
            Cells = new MapCell[numCells];

            for(int j = 0; j < numCells; j++)
            {
                MapCell cell = new MapCell();
                cell.TileID = entry.Data[i] + entry.Data[i + 1] * 256;
                cell.SolidEntityID = entry.Data[i + 2];
                cell.EntityID = entry.Data[i + 3];
                Cells[j] = cell;
                i += 4;
            }

            // load tiles
            Tiles = new MapTile[512];

            for(int j = 0; j < 512; j++)
            {
                MapTile tile = new MapTile();
                if (!tile.Load(entry.Data.SubArray(i, 64), Palette)) return;

                Tiles[j] = tile;
                i += 64;
            }

            loadPositions();

            Ready = true;
        }

        private void loadPositions()
        {
            Positions = new int[52];
            int num = 0;

            for (int i = Entry.Data.Length - 104; i < Entry.Data.Length; i += 2)
            {
                int pos = Entry.Data[i] + Entry.Data[i + 1] * 256;
                if (pos != 0) Positions[num] = pos;
                num++;
            }
        }

        private void loadPalette()
        {
            Palette = new Color[256];
            int i = Entry.Data.Length - 872;

            for (int j = 0; j < 256; j++)
            {
                byte r = (byte)Math.Floor(Entry.Data[i    ] * 255f / 63f);
                byte g = (byte)Math.Floor(Entry.Data[i + 1] * 255f / 63f);
                byte b = (byte)Math.Floor(Entry.Data[i + 2] * 255f / 63f);

                Color col = Color.FromArgb(255, r, g, b);
                Palette[j] = col;

                i += 3;
            }
        }
    }
}
