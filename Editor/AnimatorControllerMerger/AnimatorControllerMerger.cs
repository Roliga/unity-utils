using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

namespace UnityUtils.AnimatorControllerMerger
{
    public class AnimatorControllerMerger : ScriptableObject
    {
        public List<AnimatorController> controllers = new List<AnimatorController>();
        public bool renameBaseLayers = false;
    }
}
