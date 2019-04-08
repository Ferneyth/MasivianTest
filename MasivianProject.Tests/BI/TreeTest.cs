using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasivianProject.BI;
using MasivianProject.BI.BindingModels;
using System.Collections.Generic;

namespace MasivianProject.Tests.BI
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void GetAncestor()
        {
            #region Arrange

            TreeModel treeModel = new TreeModel();
            List<TreeNodesModel> treeNodesModel = new List<TreeNodesModel>();

            treeNodesModel.Add(new TreeNodesModel
            {
                ParentLv1 = "55",
                NodeLv1 = "84, 21, 62",
                ParentLv2 = "21",
                NodeLv2 = "14, 57, 95"
            });

            treeNodesModel.Add(new TreeNodesModel
            {
                ParentLv1 = "33",
                NodeLv1 = "12, 28, 53",
                ParentLv2 = "53",
                NodeLv2 = "91, 38, 15"
            });

            treeModel.Parent = 100;
            treeModel.Child1 = 21;
            treeModel.Child2 = 84;
            treeModel.Nodes = treeNodesModel;

            string resultExpected = "55";

            #endregion

            #region Act

            TreeLogic treeLogic = new TreeLogic(treeModel);
            bool err = false;
            string result = treeLogic.GetAncestor(treeModel.Child1, treeModel.Child2, ref err);

            #endregion

            #region Assert

            Assert.AreEqual(resultExpected, result);

            #endregion
        }
    }
}
