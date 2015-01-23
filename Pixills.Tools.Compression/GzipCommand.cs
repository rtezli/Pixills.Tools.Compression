using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.IO.Compression;

namespace Pixills.Tools.Compression
{
    [Cmdlet(VerbsData.Compress, "gzip")]
    public class GzipCommand : PSCmdlet
    {
        private bool _compress;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string Args { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string InputFile { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string OutputFile { get; set; }

        private void ParseArgs()
        {
            if (Args.Contains("-c"))
                _compress = true;
            if (Args.Contains("-h"))
                PrintHelp();
        }

        protected override void BeginProcessing()
        {
            ParseArgs();

            if (!File.Exists(InputFile))
                return;

            using (var inStream = File.OpenRead(InputFile))
            {
                if (_compress)
                {
                    using (var outStream = new FileStream(OutputFile, FileMode.OpenOrCreate))
                    {
                        using (var zipStream = new GZipStream(outStream, CompressionMode.Compress))
                        {
                            inStream.CopyTo(zipStream);
                        }
                    }
                }
                else
                {
                    using (var outStream = new FileStream(OutputFile, FileMode.OpenOrCreate))
                    {
                        using (var zipStream = new GZipStream(outStream, CompressionMode.Decompress))
                        {
                            inStream.CopyTo(zipStream);
                        }
                    }
                }
            }
        }

        protected override void ProcessRecord()
        {

        }

        protected override void EndProcessing()
        {

        }

        private void PrintHelp()
        {

        }
    }
}
