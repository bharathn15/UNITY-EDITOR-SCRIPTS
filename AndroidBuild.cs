using System.IO;
using UnityEditor.Build.Reporting;
using UnityEditor;
using UnityEngine;

public class AndroidBuild
{
    [MenuItem("Custom Build/Android")]
    public static void BuildAPK()
    {
        string outputPath = "Builds/APK/SUTRA.apk";
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
            target = BuildTarget.Android,
        };

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("APK build succeeded.");
        }
        else
        {
            Debug.LogError("Build failed: " + report.summary.result);
        }
    }
}
