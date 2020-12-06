using System;
using System.Collections.Generic;
using System.Windows.Forms;

internal static class Class609
{
	internal static bool smethod_0(this TreeView treeView_0, string string_0, Class609.Enum27 enum27_0)
	{
		List<TreeNode> list_ = new List<TreeNode>();
		list_ = Class609.smethod_1(treeView_0.Nodes, list_);
		TreeNode treeNode = Class609.smethod_2(list_, treeView_0.SelectedNode, string_0, enum27_0);
		if (treeNode != null)
		{
			treeView_0.SelectedNode = treeNode;
			treeView_0.SelectedNode.Expand();
			return true;
		}
		return false;
	}

	private static List<TreeNode> smethod_1(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
	{
		foreach (object obj in treeNodeCollection_0)
		{
			TreeNode treeNode = (TreeNode)obj;
			list_0.Add(treeNode);
			list_0 = Class609.smethod_1(treeNode.Nodes, list_0);
		}
		return list_0;
	}

	private static TreeNode smethod_2(List<TreeNode> list_0, TreeNode treeNode_0, string string_0, Class609.Enum27 enum27_0)
	{
		bool flag = enum27_0 == (Class609.Enum27)0 || treeNode_0 == null;
		if (enum27_0 == (Class609.Enum27)2)
		{
			list_0.Reverse();
		}
		foreach (TreeNode treeNode in list_0)
		{
			if (flag && treeNode.Text.ToUpper().Contains(string_0.ToUpper()))
			{
				return treeNode;
			}
			if (treeNode == treeNode_0)
			{
				flag = true;
			}
		}
		return null;
	}

	internal enum Enum27
	{

	}
}
