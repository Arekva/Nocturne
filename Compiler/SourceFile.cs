using System.IO;
using System.Text;

namespace Nocturne.Compiler
{
    public class SourceFile
    {
        public string Path { get; }
        public string Content { get; }
        
        
        public SourceFile(string path) : this(path, File.ReadAllText(path, Encoding.Default)) { }
        
        public SourceFile(string path, Encoding encoding) : this(path, File.ReadAllText(path)) { }
        public SourceFile(string path, string content) => (Path, Content) = (path, content);
    }
}