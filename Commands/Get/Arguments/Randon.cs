using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands.Arguments.Get
{
    public class RandonArgs
    {
        public Uri Uri;

        public bool IsThereRandonArg()
        {
            return Uri != null;
        }
    }

    public class Randon:ICommandArgument
    {
        private ICommandArgument nextCommandArgument;

        public void SetNext(ICommandArgument icommand)
        {
            nextCommandArgument = icommand;
        }

        public void Execute(string[] args, object extraArgs = null)
        {
            var randonArg = new RandonArgs();

            if (IsThereRandonParameter(args))
                randonArg.Uri = new Uri(string.Format("{0}?{1}={2}", args[0] /* url */, Guid.NewGuid(), Guid.NewGuid()));
            else
                randonArg.Uri = new Uri(args[0]);

            nextCommandArgument.Execute(args, randonArg);
        }

        private bool IsThereRandonParameter(string[] args)
        {
            return args.Contains("-rp") || args.Contains("-randon_parameters");
        }
    }
}