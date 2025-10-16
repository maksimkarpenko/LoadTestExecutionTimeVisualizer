using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TestSynchronizer;

namespace TestExecutionTimeVisualizer {
    public partial class Form1 : Form {

        TestExecutionTimeMetric[] metricForSeries = new TestExecutionTimeMetric[3];
        Label[] legendLabels = new Label[3];

        public Form1() {
            InitializeComponent();
            legendLabels[0] = lblLegend1;
            legendLabels[1] = lblLegend2;
            legendLabels[2] = lblLegend3;
            ClearChart();
            foreach (ConnectionStringSettings conn in System.Configuration.ConfigurationManager.ConnectionStrings) {
                ddlDatabase.Items.Add(conn.Name);
            }
            ddlDatabase.SelectedItem = "XafTests2";
            RefreshDirectoryTree();
        }

        DatabaseHelper DatabaseHelper {
            get {
                if(ddlDatabase.SelectedItem == null) throw new Exception("Select database first");
                return new DatabaseHelper(ddlDatabase.SelectedItem.ToString());
            }
        }

        void Execute(Action action) {
            try {
                Cursor.Current = Cursors.WaitCursor;
                action();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                Cursor.Current = Cursors.Default;
            }
        }

        void ClearChart() {
            for (int i = 0; i < metricForSeries.Length; i++) {
                chart1.Series[i].Points.Clear();
                legendLabels[i].Text = "";
                metricForSeries[i] = null;
            }
        }

        void RefreshDirectoryTree() {
            Execute(() => {
                treeView1.Nodes.Clear();
                treeView1.BeginUpdate();
                try {
                    var tests = DatabaseHelper.GetTests();
                    foreach (var test in tests) {
                        var testNode = new TreeNode(test.ToString());
                        testNode.Nodes.Add("*");
                        testNode.Tag = test;
                        testNode.ContextMenuStrip = contextMenuStrip1;
                        treeView1.Nodes.Add(testNode);
                    }
                }
                finally {
                    treeView1.EndUpdate();
                }
            });
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            Execute(() => {
                var test = e.Node.Tag as Test;
                if (test != null && e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "*") {
                    e.Node.Nodes.Clear();
                    var metrics = DatabaseHelper.GetTestOperations(test.Id);
                    foreach (var metric in metrics) {
                        TreeNode node = e.Node.Nodes.Add($"{metric.Operation}");
                        node.Tag = metric;
                    }
                }
            });
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            var metric = e.Node.Tag as TestExecutionTimeMetric;
            if (metric != null) {
                if (metricForSeries.IndexOf(metric) == -1) {
                    for (int i = 0; i < metricForSeries.Length; i++) {
                        if (metricForSeries[i] == null) {
                            metricForSeries[i] = metric;
                            RefreshChart();
                            break;
                        }
                    }
                }
            }
        }

        private void RefreshChart() {
            Execute(() => {
                for (int i = 0; i < metricForSeries.Length; i++) {
                    chart1.Series[i].Points.Clear();
                    legendLabels[i].Text = "";
                    if (metricForSeries[i] != null) {
                        double[] points = DatabaseHelper.GetTestExecutionTime(metricForSeries[i]);
                        legendLabels[i].Text = GetLegendText(metricForSeries[i], points);
                        if (cbOnlyAverage.Checked) {
                            points = new double[] { points.Average() };
                        }
                        for (int j = 0; j < points.Length; j++) {
                            chart1.Series[i].Points.AddXY(j, points[j]);
                        }
                    }
                }
            });
        }

        private string GetLegendText(TestExecutionTimeMetric metric, double[] points) {
            string min = points.Min().ToString("F1");
            string avg = points.Average().ToString("F1");
            string max = points.Max().ToString("F1");
            return $"{metric.Test.ToString()} : {metric.Operation} : (min {min} / avg {avg} / max {max})";
        }

        private void btnClearSeries1_Click(object sender, EventArgs e) {
            metricForSeries[0] = null;
            RefreshChart();
        }
        private void btnClearSeries2_Click(object sender, EventArgs e) {
            metricForSeries[1] = null;
            RefreshChart();
        }

        private void btnClearSeries3_Click(object sender, EventArgs e) {
            metricForSeries[2] = null;
            RefreshChart();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Button == MouseButtons.Right) {
            }
        }

        private void cbOnlyAverage_CheckedChanged(object sender, EventArgs e) {
            RefreshChart();
        }

        private void deleteFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
            if (treeView1.SelectedNode?.Tag is Test test) {
                if (MessageBox.Show($"Delete test '{test.ToString()}' from database ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    Execute(() => DatabaseHelper.DeleteTest(test.Id));
                    RefreshDirectoryTree();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            RefreshDirectoryTree();
        }

        private void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshDirectoryTree();
        }
    }
}
