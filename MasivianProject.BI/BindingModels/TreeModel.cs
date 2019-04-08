using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianProject.BI.BindingModels
{
    /// <summary>
    /// Main model for build the tree
    /// </summary>
    public class TreeModel
    {
        #region Properties

        /// <summary>
        /// Principal number
        /// </summary>
        public int Parent { get; set; }
        public int Child1 { get; set; }
        public int Child2 { get; set; }

        /// <summary>
        /// Set of tree´s nodes
        /// </summary>
        public List<TreeNodesModel> Nodes { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public TreeModel()
        {
            Nodes = new List<TreeNodesModel>();
        }

        #endregion
    }

    /// <summary>
    /// This model is used for details about the tree´s nodes
    /// </summary>
    public class TreeNodesModel
    {
        public string ParentLv1 { get; set; }
        public string NodeLv1 { get; set; }
        public string ParentLv2 { get; set; }
        public string NodeLv2 { get; set; }
    }
}
