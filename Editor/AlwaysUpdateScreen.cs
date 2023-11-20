using UnityEditor;
using UnityEngine;

namespace UnityUtils
{
    [InitializeOnLoad]
    static class AlwaysUpdateScreen
    {
        const string MenuPath = "Tools/Unity Utils/Always Update Screen";
        static bool enabled;

        [MenuItem(MenuPath)]
        static void MenuEnable()
        {
            enabled = !enabled;

            if(enabled)
                EditorApplication.update += Update;
            else
                EditorApplication.update -= Update;
        }

        [MenuItem(MenuPath, true)]
        static bool MenuValidate()
        {
            Menu.SetChecked(MenuPath, enabled);
            return true;
        }

        static void Update()
        {
            EditorApplication.QueuePlayerLoopUpdate();
        }
    }
}