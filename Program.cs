using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using BlogML.Helper.BlogML;

namespace BlogML.Helper
{
    class Program
    {
        readonly static XNamespace blogmlNS = "http://www.blogml.com/2006/09/BlogML";

        static void Main(string[] args)
        {
            try
            {
                //Parse and create settings
                Setting setting = ParseInput(args);

                //Check if action is present
                if (setting.ToolAction == ToolAction.Unknown)
                {
                    Console.WriteLine("/Action: { RemoveComments | ExportToWRX | QATarget | QASource | NewWRXWithOnlyFailedPosts} is Mandatory");
                    return;
                }

                //We got Action
                switch (setting.ToolAction)
                {
                    case ToolAction.RemoveComments:
                        if (RequiredParametersPrintUsage(ToolAction.RemoveComments, args))
                        {
                            RemoveAllComments(setting.BlogMLFileName);
                            Console.WriteLine("All comments removed from the file : {0}", setting.BlogMLFileName);
                        }
                        break;
                    case ToolAction.ExportToWRX:
                        if (RequiredParametersPrintUsage(ToolAction.ExportToWRX, args))
                        {
                            string wrxFileName = BlogMLToWRXConverter.GenerateWRXFile(setting.BlogMLFileName);
                            Console.WriteLine("Successfully created WRX format");

                            //Generate ReDirect, SourceQA and TargetQA File
                            BlogMLToWRXConverter.GenerateHelperFiles(setting.SourceBaseUrl, setting.TargetBaseUrl, wrxFileName);
                        }
                        break;
                    case ToolAction.QATarget:
                        if (RequiredParametersPrintUsage(ToolAction.QATarget, args))
                        {
                            QATarget(setting.QATargetFileName);
                        }
                        break;
                    case ToolAction.NewWRXWithOnlyFailedPosts:
                        if (RequiredParametersPrintUsage(ToolAction.NewWRXWithOnlyFailedPosts, args))
                        {
                            string wrxFileName = BlogMLToWRXConverter.GenerateWRXFileWithFailedPosts(setting.WRXFileName, setting.QAReportFileName);
                            Console.WriteLine("Successfully created WRX file with only error post names");


                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine("ALL Done");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine();
                PringUsage();
            }
        }

        private static void RemoveAllComments(string fileName)
        {
            try
            {
                XDocument xd = XDocument.Load(fileName);
                var posts = from c in xd.Descendants(blogmlNS + "post")
                            select c;

                foreach (var post in posts)
                {
                    var comments = post.Element(blogmlNS + "comments");
                    if (comments != null)
                    {
                        string postName = post.Element(blogmlNS + "post-name").Value;
                        var commentsCount = from r in comments.Descendants(blogmlNS + "comment")
                                            select r;

                        Console.WriteLine("{0}. {1}. REMOVED", commentsCount.Count(), postName);
                        comments.Remove();
                    }
                }

                xd.Save(fileName);

            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("An error occurred. {0}", ex)));
            }
        }

        private static void QATarget(string fileName)
        {
            //string url = "http://blogbiztalk360.azurewebsites.net/extended-xmlvalidation-pipeline-component";

            string qaReportFileName = string.Format("{0}.Report.txt", Path.GetFileNameWithoutExtension(fileName));
            StreamWriter swQACheck = File.CreateText(qaReportFileName);


            foreach (var url in File.ReadAllLines(fileName))
            {
                string format;
                try
                {
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                    using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                    {
                        format = string.Format("{0},{1}", response.StatusCode, url);
                    }
                }
                catch (WebException ex)
                {
                    format = string.Format("{0},{1}", ex.Status, url);
                }

                Console.WriteLine(format);
                swQACheck.WriteLine(format);
            }
            swQACheck.Close();
        }

        

        private static Setting ParseInput(string[] args)
        {
            const string validArguments = "/Action: /BlogMLFile: /WRXFile: /QASourceFile: /QATargetFile: /QAReportFile: /SourceUrl: /TargetUrl: /NewWRXWithOnlyFailedPosts:";

            Setting setting = new Setting();
            foreach (string s in args)
            {
                if (s.IndexOf(':') == -1)
                    throw new Exception("Arguments not in the format /Key:Valye");

                string argumentKey = s.Split(':')[0].ToUpper();
                string argumentValue = s.Split(':')[1];

                if (!validArguments.ToUpper().Contains(argumentKey))
                {
                    throw new Exception("Unknown parameters passed. Valid values are " + validArguments);
                }

                if (argumentKey == "/ACTION")
                    setting.ToolAction = (ToolAction)Enum.Parse(typeof(ToolAction), argumentValue, false);

                if (argumentKey == "/BLOGMLFILE")
                    setting.BlogMLFileName = argumentValue;

                if (argumentKey == "/WRXFILE")
                    setting.WRXFileName = argumentValue;

                if (argumentKey == "/QASOURCEFILE")
                    setting.QASourceFileName = argumentValue;

                if (argumentKey == "/QATARGETFILE")
                    setting.QATargetFileName = argumentValue;

                if (argumentKey == "/SOURCEURL")
                    setting.SourceBaseUrl = argumentValue;

                if (argumentKey == "/TARGETURL")
                    setting.TargetBaseUrl = argumentValue;

                if (argumentKey == "/TARGETURL")
                    setting.TargetBaseUrl = argumentValue;

                if (argumentKey == "/QAREPORTFILE")
                    setting.QAReportFileName = argumentValue;
            }

            return setting;
        }

        private static void PringUsage()
        {
            const string exeName = "BlogML.Helper";

            Console.WriteLine("BlogML to WRX Converter by Saravana Kumar (http://www.biztalk360.com)");
            Console.WriteLine("This tool helps to convert BlogML to WRX and also helps to generate some QA text files for verifications");
            Console.WriteLine();
            Console.WriteLine("Remove Comments: If  you got lot of spam comments, it's worth removing it.");
            Console.WriteLine("{0} /Action:RemoveComments /BlogMLFile:yourblogmlfile.xml", exeName);
            Console.WriteLine();
            Console.WriteLine("Export To WRX: Will create WordPress Export file (WRX) and also supporting redirect, source and target QA files (for verification).");
            Console.WriteLine("{0} /Action:ExportToWRX /BlogMLFile:yourblogmlfile.xml /SourceUrl:blogs.digitaldeposit.net /TargetUrl:blogs.biztalk360.com", exeName);
            Console.WriteLine();
            Console.WriteLine("QA Source. Check whether all the original url are redirection to 301");
            Console.WriteLine("{0} /Action:QASource /QASourceFile:QASourceFile.xml ", exeName);
            Console.WriteLine();
            Console.WriteLine("QA Target. Check whether all the new urls are correct. Will produce a report file with HTTP Status.");
            Console.WriteLine("{0} /Action:QATarget /QATargetFile:QATargetFile.xml ", exeName);
        }

        private static bool RequiredParametersPrintUsage(ToolAction action, string[] args)
        {
            string validArguments;

            switch (action)
            {
                case ToolAction.RemoveComments:
                    validArguments = "/Action: /BlogMLFile:";
                    if (args.Length != 2)
                    {
                        Console.WriteLine("/BlogMLFile: is mandatory");
                        return false;
                    }
                    break;
                case ToolAction.ExportToWRX:
                    validArguments = "/Action: /BlogMLFile: /SourceUrl: /TargetUrl:";
                    if (args.Length != 4)
                    {
                        Console.WriteLine("/BlogMLFile: /SourceUrl: /TargetUrl: are mandatory");
                        return false;
                    }
                    break;
                case ToolAction.QATarget:
                    validArguments = "/Action: /QATargetFile:";
                    if (args.Length != 2)
                    {
                        Console.WriteLine("/QATargetFile: is mandatory");
                        return false;
                    }
                    break;
                case ToolAction.QASource:
                    validArguments = "/Action: /QASourceFile:";
                    if (args.Length != 2)
                    {
                        Console.WriteLine("/QASourceFile: is mandatory");
                        return false;
                    }
                    break;
                case ToolAction.NewWRXWithOnlyFailedPosts:
                    validArguments = "/Action: /WRXFile: /QAReportFile:";
                    if (args.Length != 3)
                    {
                        Console.WriteLine("/WRXFile: /QAReportFile are mandatory");
                        return false;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("action");
            }

            foreach (string s in args)
            {
                string argumentKey = s.Split(':')[0].ToUpper();
                if (!validArguments.ToUpper().Contains(argumentKey))
                {
                    Console.WriteLine("Unknown parameters passed. Valid values are " + validArguments);
                    return false;
                }
            }

            return true;
        }
    }

    enum ToolAction
    {
        Unknown,
        RemoveComments,
        ExportToWRX,
        QATarget,
        QASource,
        NewWRXWithOnlyFailedPosts
    }

    class Setting
    {
        public ToolAction ToolAction { get; set; }
        public string BlogMLFileName { get; set; }
        public string WRXFileName { get; set; }
        public string QASourceFileName { get; set; }
        public string QATargetFileName { get; set; }
        public string SourceBaseUrl { get; set; }
        public string TargetBaseUrl { get; set; }
        public string QAReportFileName { get; set; }
    }
}
