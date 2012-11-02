using System;
using System.Net;
using Extensions;
using Commands;
using Commands.Arguments.Get;
using Commands.Get;

namespace ddos.Get
{
    public class GetCommand : BaseCommand
    {
        public override string CommandName
        {
            get
            {
                return "get";
            }
        }

        public override void TryExecute(string command, string[] args)
        {
            if (CommandName.Equals(command))
            {
                if (string.IsNullOrWhiteSpace(args[0]))
                    throw new Exception("null url");

                Execute(args);
            }
            else if (IsThereNextCommand())
                NextCommand.TryExecute(args[0], args);
        }

        private new void Execute(string[] args)
        {
            var getFacade = new ExecuteGetFacade();
            getFacade.Execute(args);
        }
    }
}