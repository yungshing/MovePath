using UnityEngine;
using System.Collections;

public class PathEditorTools
{
    public static Vector3 PointLabelPos = new Vector3(0,0.5f,0);
    public static IconManager.Icon PointIcon = IconManager.Icon.DiamondGreen;
    private static GUIStyle guiStyle = null;
    public static GUIStyle GUIStyle
    {
        get
        {
            if (guiStyle == null)
            {
                guiStyle = new GUIStyle();
                guiStyle.normal.textColor = Color.red;
                guiStyle.fontSize = 15;
            }
            return guiStyle;
        }
    }
    
}
