using System;
using Extensions;

namespace Commands
{
    public abstract class BaseCommand
    {
        protected BaseCommand NextCommand { get; set; }
        public abstract string CommandName { get; }

        public void Execute(string[] args)
        {
            if (args == null)
                throw new Exception("args null");

            var command = args[0];
            if (command == null)
                throw new Exception("command null");

            if (args.Length < 2)
                throw new Exception("no parameters");

            TryExecute(command, args.RemoveAt(0));
        }

        public void SetNext(BaseCommand nextCommand)
        {
            NextCommand = nextCommand;
        }

        protected bool IsThereNextCommand()
        {
            return NextCommand != null;
        }

        public abstract void TryExecute(string command, string[] args);
    }
}