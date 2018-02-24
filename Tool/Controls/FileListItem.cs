using System.Drawing;
using System.Windows.Forms;
using riptide.Riptide;

namespace riptide.Controls
{
    public class FileListItem : ListViewItem
    {
        public DatFileEntry Entry { get; private set; }

        private ListViewSubItem nameItem;
        private ListViewSubItem typeItem;
        private ListViewSubItem sizeItem;

        public FileListItem(DatFileEntry entry)
        {
            Entry = entry;
            UseItemStyleForSubItems = false;
            
            nameItem = SubItems.Add(new ListViewSubItem());
            typeItem = SubItems.Add(new ListViewSubItem());
            sizeItem = SubItems.Add(new ListViewSubItem());

            sizeItem.Font = new System.Drawing.Font("Consolas", 10);

            switch(entry.Type)
            {
                case DatFileEntry.DataType.Image:
                    BackColor = Color.FromArgb(255, 220, 255, 220);
                    break;
                case DatFileEntry.DataType.Map:
                    BackColor = Color.FromArgb(255, 220, 220, 255);
                    break;
                case DatFileEntry.DataType.Music:
                    BackColor = Color.FromArgb(255, 255, 255, 220);
                    break;
                case DatFileEntry.DataType.SoundFX:
                    BackColor = Color.FromArgb(255, 255, 255, 180);
                    break;
                case DatFileEntry.DataType.SpeakerSound:
                    BackColor = Color.FromArgb(255, 255, 255, 140);
                    break;
                case DatFileEntry.DataType.Sprite:
                    BackColor = Color.FromArgb(255, 180, 255, 180);
                    break;
                case DatFileEntry.DataType.Text:
                    BackColor = Color.FromArgb(255, 220, 220, 220);
                    break;
                case DatFileEntry.DataType.Unknown:
                default:
                    BackColor = Color.FromArgb(255, 255, 0, 0);
                    break;
            }

            updateCaptions();
        }

        private void updateCaptions()
        {
            Text = Entry.ID.ToString();
            nameItem.Text = Entry.Filename;
            typeItem.Text = Entry.TypeString;
            sizeItem.Text = Entry.Size.ToString();
        }

        
    }
}
