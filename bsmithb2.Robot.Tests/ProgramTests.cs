﻿using Autofac;
using bsmithb2.Robot.core;
using bsmithb2.Robot.Tests.Containers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bsmithb2.Robot.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Program_Should_DefaultAContainerForResolution()
        {
            Program.Container = null;
            Program.Main(null);
            Assert.AreNotEqual(null, Program.Container);
        }

        [Test]
        public void Program_Should_Call_TestContainers_IApplication()
        {
            Program.Container = new TestContainer().Configure();
            Program.Main(null);

        }
    }
}
