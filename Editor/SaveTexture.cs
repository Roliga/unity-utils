// From https://docs.unity3d.com/ScriptReference/EditorUtility.SaveFilePanel.html
using UnityEditor;
using UnityEngine;
using System.IO;

namespace UnityUtils.AnimatorControllerMerger
{
    public class SaveTexture
    {
        [MenuItem("Tools/Unity Utils/Save Selected Texture")]
        static void Save()
        {
            Texture2D texture = Selection.activeObject as Texture2D;
            if (texture == null)
            {
                EditorUtility.DisplayDialog(
                    "Save Selected Texture",
                    "You Must Select a Texture first!",
                    "Ok");
                return;
            }

            var path = EditorUtility.SaveFilePanel(
                "Save texture as PNG",
                "",
                texture.name + ".png",
                "png");

            if (path.Length != 0)
            {
                var pngData = texture.EncodeToPNG();
                if (pngData != null)
                    File.WriteAllBytes(path, pngData);
            }
        }
    }
}