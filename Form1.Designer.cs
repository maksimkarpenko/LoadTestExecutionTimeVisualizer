namespace TestExecutionTimeVisualizer {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblLegend3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnClearSeries3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLegend2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClearSeries2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLegend1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClearSeries1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbOnlyAverage = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1596, 663);
            this.splitContainer1.SplitterDistance = 546;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(546, 663);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Title = "Worker";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            chartArea1.AxisY.Title = "Time, ms";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 72);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Blue;
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series3.Name = "Series3";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1046, 591);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblLegend3);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.btnClearSeries3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 48);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1046, 24);
            this.panel5.TabIndex = 3;
            // 
            // lblLegend3
            // 
            this.lblLegend3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLegend3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegend3.Location = new System.Drawing.Point(31, 0);
            this.lblLegend3.Name = "lblLegend3";
            this.lblLegend3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblLegend3.Size = new System.Drawing.Size(978, 24);
            this.lblLegend3.TabIndex = 1;
            this.lblLegend3.Text = "lblLegend3";
            this.lblLegend3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(31, 24);
            this.panel6.TabIndex = 0;
            // 
            // btnClearSeries3
            // 
            this.btnClearSeries3.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearSeries3.Location = new System.Drawing.Point(1009, 0);
            this.btnClearSeries3.Name = "btnClearSeries3";
            this.btnClearSeries3.Size = new System.Drawing.Size(37, 24);
            this.btnClearSeries3.TabIndex = 3;
            this.btnClearSeries3.Text = "X";
            this.btnClearSeries3.UseVisualStyleBackColor = true;
            this.btnClearSeries3.Click += new System.EventHandler(this.btnClearSeries3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblLegend2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.btnClearSeries2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1046, 24);
            this.panel3.TabIndex = 1;
            // 
            // lblLegend2
            // 
            this.lblLegend2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLegend2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegend2.Location = new System.Drawing.Point(31, 0);
            this.lblLegend2.Name = "lblLegend2";
            this.lblLegend2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblLegend2.Size = new System.Drawing.Size(978, 24);
            this.lblLegend2.TabIndex = 1;
            this.lblLegend2.Text = "lblLegend2";
            this.lblLegend2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Blue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(31, 24);
            this.panel4.TabIndex = 0;
            // 
            // btnClearSeries2
            // 
            this.btnClearSeries2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearSeries2.Location = new System.Drawing.Point(1009, 0);
            this.btnClearSeries2.Name = "btnClearSeries2";
            this.btnClearSeries2.Size = new System.Drawing.Size(37, 24);
            this.btnClearSeries2.TabIndex = 3;
            this.btnClearSeries2.Text = "X";
            this.btnClearSeries2.UseVisualStyleBackColor = true;
            this.btnClearSeries2.Click += new System.EventHandler(this.btnClearSeries2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLegend1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnClearSeries1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 24);
            this.panel1.TabIndex = 0;
            // 
            // lblLegend1
            // 
            this.lblLegend1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLegend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegend1.Location = new System.Drawing.Point(31, 0);
            this.lblLegend1.Name = "lblLegend1";
            this.lblLegend1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblLegend1.Size = new System.Drawing.Size(978, 24);
            this.lblLegend1.TabIndex = 1;
            this.lblLegend1.Text = "lblLegend1";
            this.lblLegend1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(31, 24);
            this.panel2.TabIndex = 0;
            // 
            // btnClearSeries1
            // 
            this.btnClearSeries1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearSeries1.Location = new System.Drawing.Point(1009, 0);
            this.btnClearSeries1.Name = "btnClearSeries1";
            this.btnClearSeries1.Size = new System.Drawing.Size(37, 24);
            this.btnClearSeries1.TabIndex = 2;
            this.btnClearSeries1.Text = "X";
            this.btnClearSeries1.UseVisualStyleBackColor = true;
            this.btnClearSeries1.Click += new System.EventHandler(this.btnClearSeries1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteFromDatabaseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 26);
            // 
            // deleteFromDatabaseToolStripMenuItem
            // 
            this.deleteFromDatabaseToolStripMenuItem.Name = "deleteFromDatabaseToolStripMenuItem";
            this.deleteFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.deleteFromDatabaseToolStripMenuItem.Text = "Delete Test from Database";
            this.deleteFromDatabaseToolStripMenuItem.Click += new System.EventHandler(this.deleteFromDatabaseToolStripMenuItem_Click);
            // 
            // cbOnlyAverage
            // 
            this.cbOnlyAverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOnlyAverage.AutoSize = true;
            this.cbOnlyAverage.Location = new System.Drawing.Point(1454, 16);
            this.cbOnlyAverage.Name = "cbOnlyAverage";
            this.cbOnlyAverage.Size = new System.Drawing.Size(154, 17);
            this.cbOnlyAverage.TabIndex = 2;
            this.cbOnlyAverage.Text = "Show single avarage value";
            this.cbOnlyAverage.UseVisualStyleBackColor = true;
            this.cbOnlyAverage.CheckedChanged += new System.EventHandler(this.cbOnlyAverage_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 716);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbOnlyAverage);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Test Execution Time Visualizer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblLegend2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLegend1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnClearSeries1;
        private System.Windows.Forms.Button btnClearSeries2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox cbOnlyAverage;
        private System.Windows.Forms.ToolStripMenuItem deleteFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblLegend3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnClearSeries3;
        private System.Windows.Forms.Button btnRefresh;
    }
}

