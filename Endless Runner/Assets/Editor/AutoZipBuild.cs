using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

class AutoZipBuild : IPostprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPostprocessBuild(BuildReport report)
    {
        string directoryPath = report.summary.outputPath;
        FileInfo directoryName = new FileInfo(directoryPath);
        string zipFilePath = System.IO.Directory.GetParent(directoryPath).ToString();
        FileInfo projectName = new FileInfo(zipFilePath);
        string zipFileFullPath = Path.Combine(zipFilePath, projectName.Name + "_Build.zip");
        if (File.Exists(zipFileFullPath))
        {
            File.Delete(zipFileFullPath);
        }
        //wait 0 seconds to ensure there isn't a conflict with the process of deleting the zip file
        Task.Delay(0).ContinueWith(t=> ZipBuildOutput(directoryPath, zipFileFullPath));
    }

    private static void ZipBuildOutput(string sourceDir, string zipFileFullPath)
    {
        ZipFile.CreateFromDirectory(sourceDir, zipFileFullPath);

    }
}