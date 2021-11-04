using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

namespace UnityUtils.AnimatorControllerMerger
{
    public class GetAnimatorLayer
    {
        [MenuItem("Tools/Unity Utils/Show Animator Layer Index")]
        public static void Show()
        {
            var tool = EditorWindow.focusedWindow;
            var toolType = tool.GetType();

            if (toolType.FullName != "UnityEditor.Graphs.AnimatorControllerTool")
            {
                EditorUtility.DisplayDialog("Animator Layer Index", "Please focus an Animator window before using this tool.", "Okay");
                return;
            }

            int layerIndex = (int)toolType.GetProperty("selectedLayerIndex").GetValue(tool);
            EditorUtility.DisplayDialog("Animator Layer Index", $"Layer index is: {layerIndex}", "Okay");
        }
    }
}