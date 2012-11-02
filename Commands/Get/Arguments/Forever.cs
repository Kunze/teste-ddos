using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands.Arguments.Get
{
    public class Forever : ICommandArgument
    {
        private ICommandArgument nextCommandArgument;

        public void SetNext(ICommandArgument icommand)
        {
            nextCommandArgument = icommand;
        }

        public void Execute(string[] args, object extraArgs = null)
        {
            var count = 0;

            Action ShowCount = () =>
            {
                Console.Clear();
                Console.Write(++count);
            };

            if (IsThereForeverParameter(args))
            {
                while (true)
                {
                    nextCommandArgument.Execute(args);

                    ShowCount();
                }
            }
            else
            {
                for (int i = 0; i < (TryGetQuantityParameter(args) ?? 1); i++)
                {
                    nextCommandArgument.Execute(args);

                    ShowCount();
                }
            }
        }

        private bool IsThereForeverParameter(string[] args)
        {
            return args.Contains("-rf") || args.Contains("-repeat_forever");
        }

        private Int64? TryGetQuantityParameter(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-q" || args[i] == "-quantity")
                {
                    return Int64.Parse(args[i + 1]);
                }
            }

            return null;
        }
    }
}
