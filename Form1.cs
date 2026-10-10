using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Point = Tekla.Structures.Geometry3d.Point;
namespace TeklaFirstTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            MessageBox.Show("Connection: " +
                model.GetConnectionStatus()
                + "\nModel path: " + model.GetInfo().ModelPath);
        }
        private void btnCreateBeam_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            Beam beam = new Beam(
                new Tekla.Structures.Geometry3d.Point(0, 0, 0),
                new Tekla.Structures.Geometry3d.Point(6000, 0, 0));
            beam.Profile.ProfileString = "W16X40";
            beam.Material.MaterialString = "A992";
            bool inserted = beam.Insert();
            bool committed = model.CommitChanges();
            MessageBox.Show("Inserted: " + inserted + "\nCommitted: " + committed);
        }
        private void btnCreateColumn_Click(object sender, EventArgs e)
        {
            Model model = new Model();

            Beam column = new Beam(new Point(0, 0, 0), new Point(0, 0, 4000));
            column.Profile.ProfileString = "W12X26";
            column.Material.MaterialString = "A992";
            column.Position.Depth = Position.DepthEnum.MIDDLE;
            column.Position.Plane = Position.PlaneEnum.MIDDLE;

            bool inserted = column.Insert();
            model.CommitChanges();

            MessageBox.Show("Inserted: " + inserted);
        }
    }
}
