using UnityEditor;
using UnityEngine;
using System.IO;

namespace UnityUtils.PresetsPerFolder
{
    [InitializeOnLoad]
    static class MenuEntry
    {
        const string MenuPath = "Tools/Unity Utils/Enable Pesets Per Folder";
        const string ImportPath = "Assets/Editor/PresetsPerFolder.cs";
        const string SourcePath = "Packages/ga.roli.unity-utils/Editor/PresetsPerFolder/NoImport~/PresetsPerFolder.cs";

        [MenuItem(MenuPath)]
        static void MenuEnable()
        {
            if(IsImported())
            {
                AssetDatabase.DeleteAsset(ImportPath);
            }
            else
            {
                if(!AssetDatabase.IsValidFolder("Assets/Editor"))
                    AssetDatabase.CreateFolder("Assets", "Editor");

                FileUtil.CopyFileOrDirectory(SourcePath, ImportPath);
                AssetDatabase.ImportAsset(ImportPath);
            }
        }

        [MenuItem(MenuPath, true)]
        static bool MenuValidate()
        {
            Menu.SetChecked(MenuPath, IsImported());
            return true;
        }

        static bool IsImported()
        {
            string path = Path.Combine(Application.dataPath, "../", ImportPath);
            return File.Exists(path);
        }
    }
}