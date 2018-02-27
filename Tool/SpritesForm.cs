using System.Windows.Forms;
using riptide.Controls;
using riptide.Riptide;

namespace riptide
{
    public partial class SpritesForm : Form
    {
        private Map map;

        public SpritesForm(Map map, Game game)
        {
            InitializeComponent();
            this.map = map;
            
            int i = 0;
            foreach(MapCell cell in map.Cells)
            {
                if (cell.EntityID > 0 || cell.ShootableID > 0)
                {
                    int x = i % map.Width;
                    int y = i / map.Width;
                    ListViewItem item = spritesList.Items.Add(new SpriteListItem(cell, x, y));

                    string spriteName = cell.EntityID > 0 ? Game.EntitySpriteName(cell.EntityID) : Game.ShootableSpriteName(cell.ShootableID);
                    if (spriteName != "")
                    {
                        imageList.Images.Add(game.Archive.GetByName(spriteName).GetSprite(game.MainPalette).MakeIcon(32, 32));
                        item.ImageIndex = imageList.Images.Count - 1;
                    }
                }

                i++;
            }
        }
    }
}
