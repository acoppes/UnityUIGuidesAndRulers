using UnityEditor;

namespace Gemserk.UIGuidesAndRulers.Editor
{
    [CustomEditor(typeof(UISimpleGuide))]
    public class UIRulerCustomInspector : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var t = target as UISimpleGuide;
            
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
