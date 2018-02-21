using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Folder_Creator : MonoBehaviour {
    
    [MenuItem("Tools/Michael/Make Folder")]
    public static void Create_Folder()
    {
        AssetDatabase.CreateFolder("Assets", "Michael_Is_Fucking_Useless");
    }
}
