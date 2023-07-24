using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateFolderContextMenu
{
    #region Private Variables
    static string[] mFoldersNameArray = new string[]
    {
        "Materials",
        "Scenes",
        "Scripts",
        "Prefabs",
        "Shaders"
    };
    #endregion

    #region Functions
    [MenuItem("Assets/Utilities/Create Project Folders", false, 10)]
    static void CreateProjectFolders()
    {
        string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (!string.IsNullOrEmpty(selectedPath))
        {
            string newFolderPath = Path.Combine(Application.dataPath.Remove("/Assets"), selectedPath);
            for (int i = 0; i < mFoldersNameArray.Length; ++i)
            {
                string finalFolderPath = Path.Combine(newFolderPath, mFoldersNameArray[i]);
                Debug.Log(finalFolderPath);
                if (Directory.Exists(finalFolderPath))
                    continue;
                Directory.CreateDirectory(finalFolderPath);
            }
            AssetDatabase.Refresh();
        }
    }
    #endregion
}
