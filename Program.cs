using System;

namespace Caesar
{
    class Program
    {
        static int Main(string[] args)
        {
            //ArgumentParser ap = new ArgumentParser(args);
            Statement flag = Statement.DEFAULT;
            CaesarCode cc = null;
            int key = 0;
            int argc = args.Length;
            int numberOfS = 0;
            int numberOfK = 0;

            // Deal with arguments
            if (argc == 0)
            {
                Console.WriteLine("ERROR:   No argument detected.");
                Console.WriteLine("         The first argument must be 'encode', 'decode' or 'help'.");
                Console.WriteLine("Use argument 'help' to see how to use it.");
                return -1;
            }
            switch (args[0])
            {
                case "encode":
                    flag = Statement.ENCODE; break;
                case "decode":
                    flag = Statement.DECODE; break;
                case "help":
                    if (argc != 1)
                    {
                        Console.WriteLine("ERROR:   Too many arguments for 'help'.");
                        Console.WriteLine("Use argument 'help' to see how to use it.");
                        return -1;
                    }
                    PrintHelp();
                    return 0;
                default:
                    flag = Statement.ERROR;
                    Console.WriteLine("ERROR:   The first argument must be 'encode', 'decode' or 'help'.");
                    Console.WriteLine("Use argument 'help' to see how to use it.");
                    return -1;
            }

            for (int i = 1; i < argc; ++i)
            {
                switch (args[i])
                {
                    case "-s": cc = new CaesarCode(args[++i]); ++numberOfS; break;
                    case "-k": key = Int32.Parse(args[++i]); ++numberOfK; break;
                    default:
                        Console.WriteLine("Unknown argument '" + args[i] + "'.");
                        Console.WriteLine("Use argument 'help' to see how to use it.");
                        return -1;
                }
            }
            if (numberOfK == 0)
            {
                Console.WriteLine("ERROR:   The '-k' argument is needed, or the program will not start.");
                Console.WriteLine("Use argument 'help' to see how to use it.");
                return -1;
            }
            if (numberOfK > 1)
            {
                Console.WriteLine("ERROR:   Repeat assignment for argument '-k'.");
                Console.WriteLine("Use argument 'help' to see how to use it.");
                return -1;
            }
            if (key < 1 || key > 26)
            {
                Console.WriteLine("ERROR:   Unavaliable key value, key must be between 1 and 25.");
                Console.WriteLine("Use argument 'help' to see how to use it.");
                return -1;
            }
            if (cc == null)
            {
                Console.WriteLine("ERROR:   Lack of argument '-s', you need to insert a string to encode/decode.");
                Console.WriteLine("Use argument 'help' to see how to use it.");
                return -1;
            }
            if (numberOfS > 1)
            {
                Console.WriteLine("ERROR:   Repeat assignment for argument '-s'.");
                Console.WriteLine("Use argument 'help' to see how to use it.");
                return -1;
            }
            //End of dealing with arguments

            switch (flag)
            {
                case Statement.ENCODE: Console.WriteLine(cc.Encoder(key)); break;
                case Statement.DECODE: Console.WriteLine(cc.Decoder(key)); break;
            }
            return 0;

        }

        static void PrintHelp()
        {
            Console.WriteLine("A Caesar Code based encrypt/decrypt tool.");
            Console.WriteLine();
            Console.WriteLine("SYNOPSIS:Caesar PARAM -s STRING -k KEY");
            Console.WriteLine();
            Console.WriteLine("PARAM:   Program's running mode.");
            Console.WriteLine("         encode -> To encode the STRING with KEY step(s).");
            Console.WriteLine("         decode -> To decode the STRING with KEY step(s).");
            Console.WriteLine("         help   -> Check out the help page.");
            Console.WriteLine();
            Console.WriteLine("STRING:  The string you are going to deal with, followed by '-s'.");
            Console.WriteLine("         If there is SPACE in your STRING, use \" \" to surround it.");
            Console.WriteLine("         By the way, numbers and symbols(include \') will not change.");
            Console.WriteLine("         But if STRING includes \",consider use '\\\"' instead.");
            Console.WriteLine();
            Console.WriteLine("KEY:     Define the number of step(s) to encode/decode the STRING.");
            Console.WriteLine("         The KEY value must between 1 and 25.");
        }
    }

    class CaesarCode
    {
        private readonly string Code;

        public CaesarCode(string code)
        {
            this.Code = code;
        }

        public string Encoder(int key)
        {
            string str = new string("");
            foreach (char c in Code)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    str += (char)((c + key - 'A') % 26 + 'A');
                }
                else if (c >= 'a' && c <= 'z')
                {
                    str += (char)((c + key - 'a') % 26 + 'a');
                }
                else
                {
                    str += c;
                }
            }
            return str;
        }

        public string Decoder(int key)
        {
            string str = new string("");
            foreach (char c in Code)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    str += (char)((c - key - 'A' + 26) % 26 + 'A');
                }
                else if (c >= 'a' && c <= 'z')
                {
                    str += (char)((c - key - 'a' + 26) % 26 + 'a');
                }
                else
                {
                    str += c;
                }
            }
            return str;
        }
    }

    enum Statement
    {
        DEFAULT = 0, ENCODE, DECODE, ERROR
    }
}
