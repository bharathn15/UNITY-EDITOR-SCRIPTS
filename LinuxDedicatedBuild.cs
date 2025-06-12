using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.IO;
using System.Linq;

/// <summary>
/// Linux Builds.
/// 
/// Note : Requires
/// Linux Build Support (MONO)
/// Linux Dedicated Server Build Support
/// </summary>
public static class LinuxDedicatedBuild
{
    [MenuItem("Custom Build/Linux SUTRA Server x86_64 MONO")]
    public static void BuildLinuxServer()
    {
        string outputPath = "Builds/Linux Server/SUTRAServer.x86_64";
        string[] scenes = new[] {
            "Assets/***/Assets/Scenes/***.unity",
            "Assets/***/Assets/Scenes/***.unity",
            "Assets/***/Assets/Scenes/***.unity"
        };

        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.StandaloneLinux64,
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
