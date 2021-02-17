using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nocturne.Compiler
{
    public class Package
    {
        public SourceFile[] Includes { get; init; }

        public Package(string path)
        {
            string[] files = JsonSerializer.Deserialize<PackageJson>(path).Includes;
            int fcount = files.Length;

            throw new NotImplementedException();
            //Parallel.For(0, fcount, i => Includes[i] = new Package(Path.Combine(Directory, files[i])));
        }
    }
}