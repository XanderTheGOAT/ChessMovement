using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement.Tests
{
    [TestClass()]
    public class UtilTests
    {
        [TestMethod()]
        public void GeneralSetupTestPawnInPositionOneOne()
        {
            Util util = new Util();
            util.GeneralSetup();
            Assert.IsTrue(util.GetBoard()[1, 1].name == 'P');
        }

        [TestMethod()]
        public void GeneralSetupTestRookInPositionZeroZero()
        {
            Util util = new Util();
            util.GeneralSetup();
            Assert.IsTrue(util.GetBoard()[0, 0].name == 'R');
        }

        [TestMethod()]
        public void ProcessInputValidMoveTest()
        {
            Util util = new Util();
            util.GeneralSetup();

            util.ProcessInput("a2 a3");
            Assert.IsTrue(util.GetBoard()[0, 5] != null);
        }

        [TestMethod()]
        public void ProcessInputInvalidMoveTest()
        {
            Util util = new Util();
            util.GeneralSetup();

            util.ProcessInput("a2 a5");
            Assert.IsTrue(util.GetBoard()[0, 3] == null);
        }

        [TestMethod()]
        public void PiecePlaceTest()
        {

            Util util = new Util();
            util.GeneralSetup();

            King k = new King();
            k.color = 'd';
            util.PiecePlace(3, 3, k);
            Assert.IsNotNull(util.GetBoard()[3, 3]);
        }

        [TestMethod()]
        public void GetBoardTest()
        {
            Util util = new Util();
            Assert.IsNotNull(util.GetBoard());
        }

        [TestMethod()]
        public void CheckLastPlayerMovementChanges()
        {
            Util util = new Util();
            util.GeneralSetup();

            util.ProcessInput("a2 a3");
            Assert.IsTrue(!util.lightPlayerTurn);
        }

        [TestMethod()]
        public void CheckLastPlayerMovementDoesNotChangeOnInvalidInput()
        {
            Util util = new Util();
            util.GeneralSetup();

            util.ProcessInput("a2 a5");
            Assert.IsTrue(util.lightPlayerTurn);
        }
    }
}