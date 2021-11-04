using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Linq;

namespace UnityUtils.AnimatorControllerMerger
{
    public class AnimatorControllerMergerProcessor : UnityEditor.AssetModificationProcessor
    {
        public static string[] OnWillSaveAssets(string[] paths)
        {
            List<AnimatorController> modifiedControllers = new List<AnimatorController>();
            foreach (string path in paths)
            {
                if (AssetDatabase.GetMainAssetTypeAtPath(path) == typeof(AnimatorController))
                {
                    modifiedControllers.Add(AssetDatabase.LoadAssetAtPath<AnimatorController>(path));
                }
            }

            foreach (string guid in AssetDatabase.FindAssets("t:AnimatorControllerMerger"))
            {
                string controllerPath = AssetDatabase.GUIDToAssetPath(guid);
                AnimatorControllerMerger controllerMerger = AssetDatabase.LoadAssetAtPath<AnimatorControllerMerger>(controllerPath);

                if (controllerMerger == null)
                    continue;

                if (!controllerMerger.controllers.Intersect(modifiedControllers).Any()
                    && !paths.Contains(controllerPath))
                    continue;

                AnimatorController controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(controllerPath);

                while (controller.parameters.Length > 0)
                    controller.RemoveParameter(0);

                List<AnimatorControllerLayer> newLayers = new List<AnimatorControllerLayer>();
                foreach (AnimatorController c in controllerMerger.controllers)
                {
                    if (c == null)
                        continue;

                    bool isBaseLayer = true;
                    foreach (var l in c.layers)
                    {
                        newLayers.Add(new AnimatorControllerLayer()
                        {
                            avatarMask = l.avatarMask,
                            blendingMode = l.blendingMode,
                            defaultWeight = isBaseLayer ? 1f : l.defaultWeight,
                            iKPass = l.iKPass,
                            name = controllerMerger.renameBaseLayers && isBaseLayer ? $"=== {c.name} ===" : l.name,
                            syncedLayerAffectsTiming = l.syncedLayerAffectsTiming,
                            stateMachine = l.stateMachine
                        });
                        isBaseLayer = false;
                    }

                    foreach (var p in c.parameters)
                    {
                        if (controller.parameters.Count(pp => pp.name == p.name) == 0)
                            controller.AddParameter(new AnimatorControllerParameter()
                            {
                                defaultBool = p.defaultBool,
                                defaultFloat = p.defaultFloat,
                                defaultInt = p.defaultInt,
                                name = p.name,
                                type = p.type
                            });
                    }
                }
                controller.layers = newLayers.ToArray();
            }
            return paths;
        }
    }
}
