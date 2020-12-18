using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository_Komodo_Badge_Repository;

namespace BadgesContentTest
{
    [TestClass]
    public class BadgesRepositoryTest
    {
        public BadgeContentRepository _repo;
        public Badges _badges;


        [TestInitialize]
        public void Arrange()
        {
            List<string> listOfDoors = new List<string>();
            _repo = new BadgeContentRepository();
            _badges = new Badges();

            _repo.AddBadgeToDictionary(_badges);

            
        }

        [TestMethod]
        public void ViewTest()
        {
            var x = _repo.GetBadgesDictionary();

            Assert.IsNotNull(x);
            Assert.IsTrue(x.Count > 0);
        }

    }
}
