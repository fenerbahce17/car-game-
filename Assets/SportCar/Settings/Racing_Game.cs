#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class Startup
{
    static Startup()    
    {
        EditorPrefs.SetInt("showCounts_sportcarrc3", EditorPrefs.GetInt("showCounts_sportcarrc3") + 1);

        if (EditorPrefs.GetInt("showCounts_sportcarrc3") == 1)       
        {
            Application.OpenURL("https://u3d.as/3z27");
            // System.IO.File.Delete("Assets/SportCar/Racing_Game.cs");
        }
    }     
}
#endif
