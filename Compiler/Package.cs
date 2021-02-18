using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nocturne.Compiler
{
    public class Package
    {
        public string Name { get; init; }
        public SourceFile[] Includes { get; init; }

        public Package(string path)
        {
            string[] includes = JsonSerializer.Deserialize<PackageJson>(File.ReadAllText(path)).Includes;
            int icount = includes.Length;
            
            Name = Path.GetFileNameWithoutExtension(path);
            Includes = new SourceFile[icount];
            
            Parallel.For(0, icount, i => Includes[i] = new SourceFile(Path.Combine(Path.GetDirectoryName(path), includes[i])));
        }
    }
}