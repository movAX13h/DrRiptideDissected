using riptide.Riptide;
using System.Drawing;
using System.Windows.Forms;

namespace riptide.Controls
{
    public class SpriteListItem : ListViewItem
    {
        private MapCell cell;
        private int x;
        private int y;

        private ListViewSubItem xItem;
        private ListViewSubItem yItem;
        private ListViewSubItem typeItem;
        private ListViewSubItem assignmentItem;
        private ListViewSubItem infoItem;

        public SpriteListItem(MapCell cell, int x, int y)
        {
            this.cell = cell;
            this.x = x;
            this.y = y;

            UseItemStyleForSubItems = false;
                        
            xItem = SubItems.Add(new ListViewSubItem());
            yItem = SubItems.Add(new ListViewSubItem());
            typeItem = SubItems.Add(new ListViewSubItem());
            assignmentItem = SubItems.Add(new ListViewSubItem());
            infoItem = SubItems.Add(new ListViewSubItem());
            
            updateCaptions();
        }

        private void updateCaptions()
        {
            Text = cell.EntityID > 0 ? cell.EntityID.ToString() : cell.ShootableID.ToString();
            xItem.Text = x.ToString();
            yItem.Text = y.ToString();
            typeItem.Text = cell.EntityID > 0 ? "entity" : "shootable";

            string a = cell.EntityID > 0 ? Game.EntitySpriteName(cell.EntityID, x % 2 == 0) : Game.ShootableSpriteName(cell.ShootableID, x % 2 == 0);
            assignmentItem.Text = a.Length > 0 ? a : "unknown";
            if (a.Length == 0) assignmentItem.BackColor = Color.Red;

            infoItem.Text = cell.EntityID > 0 ? Game.EntityInfo(cell.EntityID, x % 2 == 0) : Game.ShootableInfo(cell.ShootableID, x % 2 == 0);
        }


    }
}
