using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Commands.Arguments.Get
{
    public class Async : ICommandArgument
    {
        private ICommandArgument nextCommandArgument;

        public void SetNext(ICommandArgument icommand)
        {
            nextCommandArgument = icommand;
        }

        public void Execute(string[] args, object extraArgs = null)
        {
            var randonArg = (RandonArgs)extraArgs;

            var webClient = new WebClient();

            if (IsThereAssincronousParameter(args))
                webClient.DownloadStringAsync(randonArg.Uri);
            else
                webClient.DownloadString(randonArg.Uri);
        }

        private bool IsThereAssincronousParameter(string[] args)
        {
            return args.Contains("-a") || args.Contains("-async");
        }
    }
}
