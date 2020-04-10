using UnityEngine;

namespace Gemserk.UICustomRulers
{
    [ExecuteInEditMode]
    public class UIRuler : MonoBehaviour
    {
        private static readonly float size = 10000;
        private static readonly float selectionSize = 20;
        
        public enum Direction
        {
            Horizontal,
            Vertical
        }
        
        // TODO: preferences like show labels or not, or turn on/off this gizmo
        // TODO: automatically turn it off during runtime unless forced.
        // TODO: we could have an editor that shows rulers only if editor is open

        public string label;
        
        public RectTransform rectTransform;
        public Direction direction;
        public bool hide;
        public Color color = Color.magenta;

        private void LateUpdate()
        {
            if (direction == Direction.Horizontal)
            {
                rectTransform.sizeDelta = new Vector2(size, selectionSize);
            } else if (direction == Direction.Vertical)
            {
                rectTransform.sizeDelta = new Vector2(selectionSize, size);
            }
        }

        private void OnDrawGizmos()
        {
            if (hide)
                return;

            var position = rectTransform.position;
            Gizmos.color = color;

            if (direction == Direction.Horizontal)
            {
                position.x = 0;
                Gizmos.DrawLine(position - new Vector3(size, 0, 0), position + new Vector3(size, 0, 0));
            } else if (direction == Direction.Vertical)
            {
                position.y = 0;
                Gizmos.DrawLine(position - new Vector3(0, size, 0), position + new Vector3(0, size, 0));
            }
            
#if UNITY_EDITOR
            UnityEditor.Handles.BeginGUI();
            if (!string.IsNullOrEmpty(label))
            {
                var p = rectTransform.position.x;

                if (direction == Direction.Horizontal)
                {
                    p = rectTransform.position.y;
                } else if (direction == Direction.Vertical)
                {
                    p = rectTransform.position.x;
                }
                
                UnityEditor.Handles.Label(rectTransform.position, $"{label}: {p}", new GUIStyle()
                {
                    normal = new GUIStyleState
                    {
                        textColor = color
                    }
                });
            }
            UnityEditor.Handles.EndGUI();
#endif
        }
    }
}
