using MasivianProject.BI.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianProject.BI
{
    /// <summary>
    /// This class contains the logic for work with tree of numbers
    /// </summary>
    public class TreeLogic
    {
        #region Properties

        private TreeModel treeModel;

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_treeModel">Tree of numbers</param>
        public TreeLogic(TreeModel _treeModel)
        {
            treeModel = _treeModel;
        }

        /// <summary>
        /// This method fiend the nearest ancestor between child 1 and child 2
        /// </summary>
        /// <param name="child1">Number of firts child through of nodes</param>
        /// <param name="child2">Number of second child through of nodes</param>
        /// <returns>The number of the ancestor</returns>
        public string GetAncestor(int child1, int child2, ref bool err)
        {
            string ancestor = string.Empty;
            string ch1 = child1.ToString();
            string ch2 = child2.ToString();
            string parent1 = string.Empty;
            string parent1Pre = string.Empty;
            string parent2 = string.Empty;
            string parent2Pre = string.Empty;
            bool flag1 = false;
            bool flag2 = false;
            string node1 = string.Empty;
            string node2 = string.Empty;

            // Find the children on the nodes
            foreach (var node in treeModel.Nodes)
            {
                if (!flag1)
                {
                    if (node.ParentLv1.Equals(ch1))
                    {
                        node1 = node.ParentLv1;
                        parent1 = treeModel.Parent.ToString();
                        flag1 = true;
                    }
                    else if (node.NodeLv1.Contains(ch1))
                    {
                        // Evalues each number into node
                        string[] lvParts = node.NodeLv1.Split(',');

                        for (int i = 0; i < lvParts.Length; i++)
                        {
                            if (lvParts[i].Trim().Equals(ch1))
                            {
                                node1 = node.NodeLv1;
                                parent1 = node.ParentLv1;
                                parent1Pre = treeModel.Parent.ToString();
                                flag1 = true;
                            }
                        }
                    }
                    else if (node.ParentLv2.Equals(ch1))
                    {
                        node1 = node.ParentLv2;
                        parent1 = treeModel.Parent.ToString();
                        flag1 = true;
                    }
                    else if (node.NodeLv2.Contains(ch1))
                    {
                        // Evalues each number into node
                        string[] lvParts = node.NodeLv2.Split(',');

                        for (int i = 0; i < lvParts.Length; i++)
                        {
                            if (lvParts[i].Trim().Equals(ch1))
                            {
                                node1 = node.NodeLv2;
                                parent1 = node.ParentLv2;
                                parent1Pre = node.ParentLv1;
                                flag1 = true;
                            }
                        }
                    }
                }

                if (!flag2)
                {
                    if (node.ParentLv1.Equals(ch2))
                    {
                        node2 = node.ParentLv1;
                        parent2 = treeModel.Parent.ToString();
                        flag2 = true;
                    }
                    else if (node.NodeLv1.Contains(ch2))
                    {
                        // Evalues each number into node
                        string[] lvParts = node.NodeLv1.Split(',');

                        for (int i = 0; i < lvParts.Length; i++)
                        {
                            if (lvParts[i].Trim().Equals(ch2))
                            {
                                node2 = node.NodeLv1;
                                parent2 = node.ParentLv1;
                                parent2Pre = treeModel.Parent.ToString();
                                flag2 = true;
                            }
                        }
                    }
                    else if (node.ParentLv2.Equals(ch2))
                    {
                        node2 = node.ParentLv2;
                        parent2 = treeModel.Parent.ToString();
                        flag2 = true;
                    }
                    else if (node.NodeLv2.Contains(ch2))
                    {
                        // Evalues each number into node
                        string[] lvParts = node.NodeLv1.Split(',');

                        for (int i = 0; i < lvParts.Length; i++)
                        {
                            if (lvParts[i].Trim().Equals(ch2))
                            {
                                node2 = node.NodeLv2;
                                parent2 = node.ParentLv2;
                                parent2Pre = node.ParentLv1;
                                flag2 = true;
                            }
                        }
                    }
                }

                // Match on nodes
                if (flag1 && flag2)
                {
                    if (parent1.Equals(parent2))
                    {
                        ancestor = parent1;
                    }
                    else if (parent1Pre.Equals(parent2))
                    {
                        ancestor = parent2;
                    }
                    else if (parent1.Equals(parent2Pre))
                    {
                        ancestor = parent1;
                    }
                    else if (parent1Pre.Equals(parent2Pre))
                    {
                        ancestor = parent1Pre;
                    }
                    else
                    {
                        ancestor = treeModel.Parent.ToString();
                    }

                    return ancestor;
                }
            }

            // Evalues if children don't exit 
            if (!flag1)
            {
                ancestor = $"El numero {ch1} no se encuentra en ningún nodo";
                err = true;
            }

            if (!flag2)
            {
                ancestor = $"El numero {ch2} no se encuentra en ningún nodo";
                err = true;
            }

            return ancestor;
        }

        #endregion
    }
}
