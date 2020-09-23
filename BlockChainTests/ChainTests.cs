﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Tests
{
    [TestClass()]
    public class ChainTests
    {
        [TestMethod()]
        public void ChainTest()
        {
            var chain = new Chain();
            chain.Add("blog", "Admin");
            Assert.AreEqual(2,chain.Blocks.Count);
            Assert.AreEqual("blog", chain.Last.Data);
        }
    }
}