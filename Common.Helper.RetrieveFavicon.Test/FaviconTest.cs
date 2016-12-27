using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Helper.RetrieveFavicon.Test
{
    [TestClass]
    public class FaviconTest
    {
        [TestMethod]
        public void CanGetFaviconIco()
        {
            var faviconUrl = Common.Helper.RetrieveFavicon.Favicon.RetrieveFavicon("https://github.com/parryqiu");
            Debug.Print(faviconUrl);
            Assert.IsTrue(faviconUrl != null);
        }
    }
}
