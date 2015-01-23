using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Pixills.Tools.Compression
{
    [Cmdlet(VerbsData.Compress, "tar")]
    public class TarballCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public string Flags { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string InputDirectory { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true)]
        public string OutputFile { get; set; }

        protected override void BeginProcessing()
        {
            if (!File.Exists(OutputFile))
                File.Create(OutputFile);

        }

        protected override void ProcessRecord()
        {

        }

        protected override void EndProcessing()
        {

        }
    }
}
