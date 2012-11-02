using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands.Arguments.Get
{
    public class Force : ICommandArgument
    {
        private ICommandArgument nextCommandArgument;

        public void SetNext(ICommandArgument icommand)
        {
            nextCommandArgument = icommand;
        }

        public void Execute(string[] args, object extraArgs = null)
        {
            if (IsThereDisableForceParameter(args))
                nextCommandArgument.Execute(args);
            else
            {
                try
                {
                    nextCommandArgument.Execute(args);
                }
                catch (NotSupportedException)
                {
                }
                catch (Exception)
                {
                }
            }
        }

        private bool IsThereDisableForceParameter(string[] args)
        {
            return args.Contains("-df") || args.Contains("-disable-force");
        }
    }
}