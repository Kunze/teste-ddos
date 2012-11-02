using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commands.Arguments.Get;

namespace Commands.Get
{
    public class ExecuteGetFacade
    {
        public void Execute(string[] args)
        {
            var forever = new Forever();
            var force = new Force();
            var randon = new Randon();
            var async = new Async();

            forever.SetNext(force);
            force.SetNext(randon);
            randon.SetNext(async);
            //async.SetNext(null);

            forever.Execute(args);
        }
    }
}
