using System;
using Extensions;
using ddos.Get;
using ddos.PostCommand;

namespace Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                args = Console.ReadLine().ToArgs();

            var get = new GetCommand();
            var post = new PostCommand();

            get.SetNext(post);
            get.Execute(args);
        }
    }
}