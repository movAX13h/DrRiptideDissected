
namespace riptide.Riptide
{
    public class Map
    {
        public DatFileEntry Entry { get; private set; }

        public bool Ready { get; private set; } = false;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(DatFileEntry entry)
        {
            Entry = entry;

            int i = 0;

            Width = entry.Data[i];
            i += 2;
            Height = entry.Data[i];
            i += 2;

            Ready = true;
        }
    }
}
