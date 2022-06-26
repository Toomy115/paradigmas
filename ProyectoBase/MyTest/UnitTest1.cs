using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace MyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCollition()
        {
            Transform transform1 = new Transform();
            Transform transform2 = new Transform();

            transform1.Position = new Vector2(1, 1);
            transform1.Size = new Vector2(1, 1);

            transform2.Position = new Vector2(3, 3);
            transform2.Size = new Vector2(1, 1);

            Collider collider = new Collider(new Vector2(1, 1), new Vector2(1, 1));
            bool res = collider.IsBoxColliding(transform1.Position, transform1.Size, transform2.Position, transform2.Size);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void TestPointsTexture()
        {
            PointsManager pointsManager = new PointsManager();
            //string path;
            string res = pointsManager.ChangeTexture("", "4");
            Assert.AreEqual(res, "Textures/HUD/Numbers/4.png");
        }
    }
}
