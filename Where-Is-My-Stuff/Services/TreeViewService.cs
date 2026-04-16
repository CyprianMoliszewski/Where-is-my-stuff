using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Where_Is_My_Stuff.Database;

namespace Where_Is_My_Stuff.Services
{
    internal class TreeViewService
    {
        private List<TreeNodeLocation> GetNodesForTree()
        {
            List<TreeNodeLocation> nodes = new List<TreeNodeLocation>();
            nodes.AddRange(DatabaseHandler.Instance.GetAllLocationsForTreeView());
            nodes.AddRange(DatabaseHandler.Instance.GetAllItemsForTreeView());

            return nodes;
        }

        private Dictionary<int, List<TreeNodeLocation>> GroupNodesByParents(List<TreeNodeLocation> treeNodes)
        {
            var groupedNodes = new Dictionary<int, List<TreeNodeLocation>>();

            
            foreach (var node in treeNodes)
            {
                if (!groupedNodes.ContainsKey(node.ParentId))
                {
                    groupedNodes[node.ParentId] = new List<TreeNodeLocation>();
                }

                groupedNodes[node.ParentId].Add(node);
            }

            return groupedNodes;
        }

        public void PopulateTree(TreeView tree)
        {
            var allNodes = GetNodesForTree();
            var allNodesGrouped = GroupNodesByParents(allNodes);

            AddNodesToBranches(-1, allNodesGrouped, tree.Nodes);
        }

        private void AddNodesToBranches(int parentId, Dictionary<int, List<TreeNodeLocation>> allNodesGrouped, TreeNodeCollection branch)
        {
            if (!allNodesGrouped.ContainsKey(parentId)) return;

            foreach (var locationOrItem in allNodesGrouped[parentId])
            {
                TreeNode node = new TreeNode(locationOrItem.Name);
                node.Tag = locationOrItem;
                branch.Add(node);

                if (!locationOrItem.IsLocation) continue;

                AddNodesToBranches(locationOrItem.Id, allNodesGrouped, node.Nodes);
            }
        }
    }


    /// <summary>
    /// TREE NODE LOCATION
    /// </summary>
    internal class TreeNodeLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int TypeId { get; set; }
        public bool IsLocation { get; set; }

        public TreeNodeLocation(int id, string name, int parentId, int typeId)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            TypeId = typeId;
            IsLocation = true;
        }

        public override string ToString()
        {
            return Id + Name + ParentId + TypeId;
        }
    }

    /// <summary>
    /// TREE NODE ITEM
    /// </summary>
    internal class TreeNodeItem : TreeNodeLocation
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int OwnerId { get; set; }

        public TreeNodeItem(int id, string name, int parentId, string description, int categoryId, int ownerId)
            : base(id, name, parentId, 4)
        {
            Description = description;
            CategoryId = categoryId;
            OwnerId = ownerId;
            IsLocation = false;
        }
    }
}
