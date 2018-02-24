using System.Windows.Forms;

namespace riptide.Controls
{
    public class PositionsListItem : ListViewItem
    {
        private int x;
        private int y;
        private int nr;
        private string type;

        private ListViewSubItem xItem;
        private ListViewSubItem yItem;
        private ListViewSubItem typeItem;

        public PositionsListItem(int nr, int x, int y, string type)
        {
            this.x = x;
            this.y = y;
            this.nr = nr;
            this.type = type;

            UseItemStyleForSubItems = false;
                        
            xItem = SubItems.Add(new ListViewSubItem());
            yItem = SubItems.Add(new ListViewSubItem());
            typeItem = SubItems.Add(new ListViewSubItem());
            
            updateCaptions();
        }

        private void updateCaptions()
        {
            Text = nr.ToString();
            xItem.Text = x.ToString();
            yItem.Text = y.ToString();
            typeItem.Text = type;
        }


    }
}
