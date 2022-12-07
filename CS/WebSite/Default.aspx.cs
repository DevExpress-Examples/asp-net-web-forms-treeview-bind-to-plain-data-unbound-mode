using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        DataTable table = GetDataTable();
        if (!IsPostBack)
            CreateTreeViewNodesRecursive(table, this.treeView.Nodes, "0");
    }

    private void CreateTreeViewNodesRecursive(DataTable table, TreeViewNodeCollection nodesCollection, string parentID) {
        for (int i = 0; i < table.Rows.Count; i++) {
            if (table.Rows[i]["ParentID"].ToString() == parentID) {
                TreeViewNode node = new TreeViewNode(table.Rows[i]["Title"].ToString(), table.Rows[i]["ID"].ToString());
                nodesCollection.Add(node);
                CreateTreeViewNodesRecursive(table, node.Nodes, node.Name);
            }
        }
    }

    private DataTable GetDataTable() {

        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(System.Int32));
        dt.Columns.Add("Title", typeof(System.String));
        dt.Columns.Add("ParentID", typeof(System.Int32));

        dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };

        dt.Rows.Add(1, "Nokia", 0);
        dt.Rows.Add(2, "N8", 1);
        dt.Rows.Add(3, "N91", 1);
        dt.Rows.Add(4, "Samsung", 0);
        dt.Rows.Add(5, "Corby9", 4);
        dt.Rows.Add(6, "Star", 0);

        return dt;
    }
}
