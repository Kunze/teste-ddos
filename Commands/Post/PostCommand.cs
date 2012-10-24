using System;
using Commands;

namespace ddos.PostCommand
{
    public class PostCommand: BaseCommand
    {
        public override string CommandName
        {
            get
            {
                return "post";
            }
        }

        public override void TryExecute(string command, string[] args)
        {
            if (CommandName.Equals(command))
            {
                throw new NotImplementedException();
            }
            else if(IsThereNextCommand())
                NextCommand.TryExecute(command, args);
        }
    }
}