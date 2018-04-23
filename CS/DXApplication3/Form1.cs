using System;

namespace DXApplication3
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nWindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.nWindDataSet.Products);
            var helper = new GroupHelper(gridView1) { VisibleNumber = 7 };
            gridView1.Columns["ReorderLevel"].Group();
            gridView1.ExpandAllGroups();
        }
    }
}
