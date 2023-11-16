using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UnityUtils.AnimatorControllerMerger
{
    public static class Screenshot
    {
        [MenuItem("Tools/Unity Utils/Capture Game View/Camera Resolution")]
        public static void Screenshot1X() => TakeScreenshot(1);
        [MenuItem("Tools/Unity Utils/Capture Game View/Camera Resolution x2")]
        public static void Screenshot2X() => TakeScreenshot(2);
        [MenuItem("Tools/Unity Utils/Capture Game View/Camera Resolution x4")]
        public static void Screenshot4X() => TakeScreenshot(4);
        [MenuItem("Tools/Unity Utils/Capture Game View/Camera Resolution x8")]
        public static void Screenshot8X() => TakeScreenshot(8);

        public static void TakeScreenshot(int superSize)
        {
            var path = EditorUtility.SaveFilePanel(
                "Save screenshot",
                "",
                "screenshot.png",
                "png");

            if (path.Length != 0)
            {
                ScreenCapture.CaptureScreenshot(path, superSize);
            }
        }
    }
}