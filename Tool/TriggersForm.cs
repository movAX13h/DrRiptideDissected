using System.Windows.Forms;
using riptide.Controls;
using riptide.Riptide;

namespace riptide
{
    public partial class TriggersForm : Form
    {
        private Map map;

        public TriggersForm(Map map)
        {
            InitializeComponent();
            this.map = map;

            for(int i = 0; i < map.Triggers.Length; i++)
            {
                int pos = map.Triggers[i];
                if (pos == 0) continue;

                int x = pos % map.Width;
                int y = pos / map.Width;

                positionsList.Items.Add(new PositionsListItem(i, x, y, Game.TriggerEntryTypeByNumber(i, pos)));
            }
        }
    }
}
