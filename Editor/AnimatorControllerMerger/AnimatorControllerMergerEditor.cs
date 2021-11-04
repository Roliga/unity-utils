using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using ReorderableList = UnityEditorInternal.ReorderableList;

namespace UnityUtils.AnimatorControllerMerger
{
    [CustomEditor(typeof(AnimatorController))]
    public class AnimatorControllerMergerEditor : Editor
    {
        private AnimatorControllerMerger controllerExtra;
        private string controllerPath;
        private AnimatorController controller;
        private ReorderableList controllerList;

        private void OnEnable()
        {
            controller = (AnimatorController)target;
            controllerPath = AssetDatabase.GetAssetPath(controller);
            controllerExtra = AssetDatabase.LoadAssetAtPath<AnimatorControllerMerger>(controllerPath);
        }

        private void DrawList()
        {
            if (controllerList == null)
                controllerList = new ReorderableList(controllerExtra.controllers, typeof(UnityEngine.Object), true, true, true, true)
                {
                    drawHeaderCallback = (rect) =>
                    {
                        EditorGUI.LabelField(rect, "Controllers");
                    },
                    drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
                    {
                        List<AnimatorController> controllers = controllerExtra.controllers;
                        AnimatorController controllerPrev = controllers[index];

                        controllers[index] = (AnimatorController)EditorGUI.ObjectField(
                            rect, controllers[index], typeof(AnimatorController), false);

                        if (controllers[index] != controllerPrev)
                            Save();
                    },
                    onChangedCallback = (list) =>
                    {
                        Save();
                    },
                    onAddCallback = (a) =>
                    {
                        controllerExtra.controllers.Add(null);
                    }
                };

            controllerList.DoLayoutList();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.BeginVertical(EditorStyles.inspectorFullWidthMargins);

            // Enable/Disable button
            if (controllerExtra == null)
            {
                if (GUILayout.Button("Enable Controller Merger"))
                {
                    if (EditorUtility.DisplayDialog("Enable Controller Merger",
                        "This will remove any layers already on this controller. Are you sure?", "Yes", "Cancel"))
                    {
                        // Enable
                        controllerExtra = CreateInstance<AnimatorControllerMerger>();
                        controllerExtra.name = "Animator Controller Merger";

                        AssetDatabase.AddObjectToAsset(controllerExtra, controllerPath);
                        Save();
                        Save();
                    }
                }
            }
            else
            {
                if (GUILayout.Button("Disable Controller Merger"))
                {
                    // Disable
                    foreach (Object o in AssetDatabase.LoadAllAssetsAtPath(controllerPath))
                        if (o.GetType() == typeof(AnimatorControllerMerger))
                            AssetDatabase.RemoveObjectFromAsset(o);

                    controllerExtra = null;
                    controllerList = null;

                    Save();
                }
            }

            if (controllerExtra != null)
            {
                // Rename base layers button
                bool renameBaseLayersPrev = controllerExtra.renameBaseLayers;
                controllerExtra.renameBaseLayers = EditorGUILayout.Toggle("Rename Base Layers", controllerExtra.renameBaseLayers);
                if (controllerExtra.renameBaseLayers != renameBaseLayersPrev)
                    Save();

                // Layer list
                DrawList();
            }

            EditorGUILayout.EndVertical();
        }

        private void Save()
        {
            EditorUtility.SetDirty(controller);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
