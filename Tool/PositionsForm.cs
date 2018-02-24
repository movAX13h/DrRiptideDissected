using System.Windows.Forms;
using riptide.Controls;
using riptide.Riptide;

namespace riptide
{
    public partial class PositionsForm : Form
    {
        private Map map;

        public PositionsForm(Map map)
        {
            InitializeComponent();
            this.map = map;

            for(int i = 0; i < map.Positions.Length; i++)
            {
                int pos = map.Positions[i];
                if (pos == 0) continue;

                int x = pos % map.Width;
                int y = pos / map.Width;

                positionsList.Items.Add(new PositionsListItem(i, x, y, Map.PositionEntryTypeByNumber(i, pos)));
            }
        }
    }
}
