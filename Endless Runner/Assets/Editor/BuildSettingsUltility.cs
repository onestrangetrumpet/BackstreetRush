using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildSettingsSetter : MonoBehaviour
{
    [MenuItem("GameU Tools/Set Build Settings")]
    public static void SetBuildSettings()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;
        BuildTargetGroup targetGroup = BuildPipeline.GetBuildTargetGroup(buildTarget);
        var namedBuildTarget = UnityEditor.Build.NamedBuildTarget.FromBuildTargetGroup(targetGroup);

        // Set build target to WebGL
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);

        // Set WebGL compression format to Gzip
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Gzip;

        // Set code optimization to Shorter Build Time
        EditorUserBuildSettings.SetPlatformSettings(BuildPipeline.GetBuildTargetName(BuildTarget.WebGL), "CodeOptimization", "Shorter Build Time");

        // Set IL2CPP Code Generation to Faster (smaller) builds
        //PlayerSettings.SetIl2CppCodeGeneration(namedBuildTarget, Il2CppCodeGeneration.OptimizeSize);

        #if UNITY_2022_3_OR_NEWER
            // For Unity 2020.3 or newer, use SetIl2CppCodeGeneration
            // Set IL2CPP Code Generation to Faster (smaller) builds
            PlayerSettings.SetIl2CppCodeGeneration(namedBuildTarget, Il2CppCodeGeneration.OptimizeSize);
        #else
            // For older Unity versions, provide an alternative or a warning
            Debug.LogWarning("SetIl2CppCodeGeneration is not supported in this Unity version. Consider upgrading Unity.");
        #endif

        // Notify user of changes
        EditorUtility.DisplayDialog("Build Settings", "Build settings updated for WebGL:\n- Compression: Gzip\n- Code Optimization: Shorter Build Time\n- IL2CPP Code Generation: Faster (smaller) builds", "OK");
    }
}
