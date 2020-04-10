using System;
using UnityEditor;
using UnityEngine;

namespace Gemserk.UICustomRulers.Editor
{
    [CustomEditor(typeof(UIRuler))]
    public class UIRulerCustomInspector : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var t = target as UIRuler;
            
            // if (!string.IsNullOrEmpty(t.label))
            // {
            //     Handles.Label(t.transform.position, t.label, new GUIStyle()
            //     {
            //         normal = new GUIStyleState
            //         {
            //             textColor = t.color
            //         }
            //     });
            // }
            //
        }
    }
}
