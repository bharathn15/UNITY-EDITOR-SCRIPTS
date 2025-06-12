using System.IO;
using UnityEditor.Build.Reporting;
using UnityEditor;
using UnityEngine;

public class WindowsBuild
{
    [MenuItem("Custom Build/Windows")]
    public static void BuildWindows()
    {
        string outputPath = "Builds/Windows/SUTRA_WIN.exe";
        string[] scenes = new[] {
            "Assets/Sutra/Assets/Scenes/***.unity",
            "Assets/Sutra/Assets/Scenes/***.unity",
            "Assets/Sutra/Assets/Scenes/***.unity"
        };

        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.StandaloneWindows64,
        };

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Headless Linux server build succeeded.");
        }
        else
        {
            Debug.LogError("Build failed: " + report.summary.result);
        }
    }
}
