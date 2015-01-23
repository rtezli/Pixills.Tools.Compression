using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pixills.Tools.Compression
{
    public class Tarball
    {
        public readonly byte[] Magic = new byte[] { (byte)'u', (byte)'s', (byte)'t', (byte)'a', (byte)'t' };
    }
}
