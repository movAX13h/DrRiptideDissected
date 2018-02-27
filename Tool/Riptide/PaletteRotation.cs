namespace riptide.Riptide
{
    public class PaletteRotation
    {
        public byte Start;
        public byte End;
        public byte Speed; // 0 = every frame, 1 = skip 1 frame, 2 = skip 2 frames ...
        public byte Unknown; // is is the last byte of the map file

        public int Length { get { return End - Start; } }
    }
}
