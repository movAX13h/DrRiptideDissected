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
