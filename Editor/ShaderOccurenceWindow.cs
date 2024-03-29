﻿// Source: http://answers.unity.com/answers/1261573/view.html

 using UnityEngine;
 using UnityEditor;
 using System.Collections.Generic;
 using System.IO;

namespace UnityUtils
{
    public class ShaderOccurenceWindow : EditorWindow
    {
        [MenuItem("Tools/Unity Utils/Shader Occurence")]
        public static void Open()
        {
            GetWindow<ShaderOccurenceWindow>();
        }

        Shader shader;
        List<string> materials = new List<string>();
        Vector2 scroll;

        private void OnEnable()
        {
            titleContent = new GUIContent("Shader Occurence", EditorGUIUtility.FindTexture("d_SceneViewLighting"));
        }

        void OnGUI()
        {
            Shader prev = shader;
            shader = EditorGUILayout.ObjectField(shader, typeof(Shader), false) as Shader;
            if (shader != prev)
            {
                string shaderPath = AssetDatabase.GetAssetPath(shader);
                string[] allMaterials = AssetDatabase.FindAssets("t:Material");
                materials.Clear();
                for (int i = 0; i < allMaterials.Length; i++)
                {
                    allMaterials[i] = AssetDatabase.GUIDToAssetPath(allMaterials[i]);
                    string[] dep = AssetDatabase.GetDependencies(allMaterials[i]);
                    if (ArrayUtility.Contains(dep, shaderPath))
                        materials.Add(allMaterials[i]);
                }
            }

            scroll = GUILayout.BeginScrollView(scroll);
            {
                for (int i = 0; i < materials.Count; i++)
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label(Path.GetFileNameWithoutExtension(materials[i]));
                        GUILayout.FlexibleSpace();

                        if (GUILayout.Button("Select"))
                            Selection.activeObject = AssetDatabase.LoadAssetAtPath(materials[i], typeof(Material));
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndScrollView();
        }
    }
}