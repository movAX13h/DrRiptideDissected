using System.Windows.Forms;
using Be.Windows.Forms;
using riptide.Riptide;

namespace riptide
{
    public partial class EditForm : Form
    {
        public DatFileEntry Entry { get; private set; }

        private HexBox hexBox;
        private Game game;

        public EditForm(Game game, DatFileEntry entry)
        {
            InitializeComponent();
            Entry = entry;
            this.game = game;
            
            hexBox = new HexBox();
            hexBox.Width = hexPanel.Width;
            hexBox.Height = hexPanel.Height;
            hexBox.ByteProvider = new DynamicByteProvider(entry.Data);
            hexBox.GroupSize = 4;
            hexBox.Dock = DockStyle.Fill;
            hexBox.GroupSeparatorVisible = true;
            hexBox.VScrollBarVisible = true;
            hexBox.LineInfoVisible = true;
            hexPanel.Controls.Add(hexBox);
        }

        private void saveAndCloseButton_Click(object sender, System.EventArgs e)
        {
            //if (MessageBox.Show("This will modify the DAT file permanently. Do you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            Entry.Data = (hexBox.ByteProvider as DynamicByteProvider).Bytes.ToArray();
            if (game.Archive.Save()) Close();
            else MessageBox.Show("Failed to save DAT file!", "Something went wrong...", MessageBoxButtons.OK);
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            Entry.Data = (hexBox.ByteProvider as DynamicByteProvider).Bytes.ToArray();
            if (!game.Archive.Save()) MessageBox.Show("Failed to save DAT file!", "Something went wrong...", MessageBoxButtons.OK);
        }
    }
}
