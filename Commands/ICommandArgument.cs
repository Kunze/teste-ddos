using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands
{
    public interface ICommandArgument
    {
        void SetNext(ICommandArgument icommand);
        void Execute(string[] args, object extraArgs = null);
    }
}