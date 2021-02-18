using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Nocturne.Extensions;

namespace Nocturne.Compiler
{
    public class Project
    {
        public string Name { get; init; }
        public string Directory { get; init; }
        public Package[] Packages { get; init; }

        public Project(string path)
        {
            if (!path.HasContents()) throw new ArgumentNullException(nameof(path), "Please specify a project path.");
            
            string file = File.ReadAllText(path);
            if (file == null || !file.HasContents()) throw new SourceException("Specified file has no content at all.");

            Name = Path.GetFileNameWithoutExtension(path);
            Directory = Path.GetDirectoryName(path);

            string[] packages = null;

            try
            {
                packages = JsonSerializer.Deserialize<ProjectJson>(file).Packages;
            }
            catch (JsonException je)
            {
                throw new SourceException("Path does not lead to a valid project file.");
            }

            if(packages.Length == 0) throw new SourceException("Project does not contain any packages.");

            int pcount = packages.Length;

            Packages = new Package[pcount];
            Parallel.For(0, pcount, i => Packages[i] = new Package(Path.Combine(Directory, packages[i])));
        }
    }
}