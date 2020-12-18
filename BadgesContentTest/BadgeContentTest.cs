using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository_Komodo_Badge_Repository;

namespace BadgesContentTest
{
    [TestClass]
    public class BadgeContentTest
    {
        [TestMethod]
        public void SetBadgeId_ShouldGetCorrectNumber()
        {
            Badges content = new Badges();

            content.BadgeId = 7;

            int expected = 7;
            int actual = content.BadgeId;

            Assert.AreEqual(expected, actual);


        }
    }
}
