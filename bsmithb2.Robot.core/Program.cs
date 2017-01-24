﻿using Autofac;
using bsmithb2.Robot.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bsmithb2.Robot.core
{
    public class Program
    {
        public static IContainer Container;

        public static void Main(string[] args)
        {
            if (Container == null)
            {
                Container = new DependencyContainer().Configure();
            }

            using (var scope = Container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
