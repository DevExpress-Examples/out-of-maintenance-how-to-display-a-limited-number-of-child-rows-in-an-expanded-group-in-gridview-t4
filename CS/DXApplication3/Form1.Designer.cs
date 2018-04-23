namespace DXApplication3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nWindDataSet = new DXApplication3.NWindDataSet();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter = new DXApplication3.NWindDataSetTableAdapters.ProductsTableAdapter();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityPerUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitsInStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitsOnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReorderLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscontinued = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(632, 278);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductID,
            this.colProductName,
            this.colQuantityPerUnit,
            this.colUnitPrice,
            this.colUnitsInStock,
            this.colUnitsOnOrder,
            this.colReorderLevel,
            this.colDiscontinued});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // nWindDataSet
            // 
            this.nWindDataSet.DataSetName = "NWindDataSet";
            this.nWindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.nWindDataSet;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // colProductID
            // 
            this.colProductID.FieldName = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 0;
            // 
            // colProductName
            // 
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 1;
            // 
            // colQuantityPerUnit
            // 
            this.colQuantityPerUnit.FieldName = "QuantityPerUnit";
            this.colQuantityPerUnit.Name = "colQuantityPerUnit";
            this.colQuantityPerUnit.Visible = true;
            this.colQuantityPerUnit.VisibleIndex = 2;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 3;
            // 
            // colUnitsInStock
            // 
            this.colUnitsInStock.FieldName = "UnitsInStock";
            this.colUnitsInStock.Name = "colUnitsInStock";
            this.colUnitsInStock.Visible = true;
            this.colUnitsInStock.VisibleIndex = 4;
            // 
            // colUnitsOnOrder
            // 
            this.colUnitsOnOrder.FieldName = "UnitsOnOrder";
            this.colUnitsOnOrder.Name = "colUnitsOnOrder";
            this.colUnitsOnOrder.Visible = true;
            this.colUnitsOnOrder.VisibleIndex = 5;
            // 
            // colReorderLevel
            // 
            this.colReorderLevel.FieldName = "ReorderLevel";
            this.colReorderLevel.Name = "colReorderLevel";
            this.colReorderLevel.Visible = true;
            this.colReorderLevel.VisibleIndex = 6;
            // 
            // colDiscontinued
            // 
            this.colDiscontinued.FieldName = "Discontinued";
            this.colDiscontinued.Name = "colDiscontinued";
            this.colDiscontinued.Visible = true;
            this.colDiscontinued.VisibleIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 278);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private NWindDataSet nWindDataSet;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private NWindDataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityPerUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitsInStock;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitsOnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colReorderLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscontinued;
    }
}

