<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128563716/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2873)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Tree View for ASP.NET Web Forms - How to bind the tree to plain data (Unbound mode)

This example demonstrates how to bind [ASPxTreeView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxTreeView) to data stored in DataTable. Nodes are created in [unbound mode](https://docs.devexpress.com/AspNet/3978/components/tree-list/concepts/binding-to-data/unbound-mode).

```csharp
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
```

## Files to Review

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))

## More Examples

* [Tree View for ASP.NET Web Forms - How to bind the tree to plain data (Virtual mode)](https://github.com/DevExpress-Examples/asp-net-web-forms-treeview-bind-to-plain-data-virtual-mode)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-treeview-bind-to-plain-data-unbound-mode&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-treeview-bind-to-plain-data-unbound-mode&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
