
#if UNITY_IOS

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;
using System.IO;

using Adiscope.PostProcessor;

public class BuildPostProcessor
{
	[PostProcessBuildAttribute(1)]
	public static void OnPostProcessBuild(BuildTarget target, string path)
	{
		switch (target)
		{
			case BuildTarget.iOS: BuildPostProcessorForIos.OnPostProcessBuild(path); break;
			default: break;
		}
	}

	[PostProcessBuild(999)]
	public static void OnPostProcessLastBuild(BuildTarget target, string path)
	{
        if (target != BuildTarget.iOS) return;

        // DT_TOOLCHAIN_DIR 치환
        var xcconfigFiles = Directory.GetFiles(path, "*.xcconfig", SearchOption.AllDirectories);
        foreach (var file in xcconfigFiles)
        {
            var content = File.ReadAllText(file);
            if (content.Contains("DT_TOOLCHAIN_DIR"))
            {
                content = content.Replace("DT_TOOLCHAIN_DIR", "TOOLCHAIN_DIR");
                File.WriteAllText(file, content);
            }
        }
	}
}

#endif