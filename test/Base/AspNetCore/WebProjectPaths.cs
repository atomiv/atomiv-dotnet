using System.IO;

namespace Optivem.Framework.Test.AspNetCore
{
    public class WebProjectPaths
    {
        public WebProjectPaths(string projectDirectoryPath, string publishDirectoryPath, string publishFileName)
        {
            ProjectDirectoryPath = projectDirectoryPath;
            PublishDirectoryPath = publishDirectoryPath;
            PublishFileName = publishFileName;
            PublishFilePath = Path.Combine(PublishDirectoryPath, PublishFileName);
        }

        public string ProjectDirectoryPath { get; }

        public string PublishDirectoryPath { get; }

        public string PublishFileName { get; }

        public string PublishFilePath { get; }

        public bool ExistsProjectDirectory()
        {
            return Directory.Exists(ProjectDirectoryPath);
        }

        public bool ExistsPublishFilePath()
        {
            return File.Exists(PublishFilePath);
        }
    }
}
