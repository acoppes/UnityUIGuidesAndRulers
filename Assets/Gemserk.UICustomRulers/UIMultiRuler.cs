using UnityEngine;

namespace Gemserk.UICustomRulers
{
    [ExecuteInEditMode]
    public class UIMultiRuler : MonoBehaviour
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

        public float width;

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

            var halfWidth = new Vector3(width * 0.5f, 0, 0);
            var halfHeight = new Vector3(0, width * 0.5f, 0);

            if (direction == Direction.Horizontal)
            {
                position.x = 0;
                Gizmos.DrawLine(position - new Vector3(size, 0, 0) + halfHeight, position + new Vector3(size, 0, 0) + halfHeight);
                Gizmos.DrawLine(position - new Vector3(size, 0, 0) - halfHeight, position + new Vector3(size, 0, 0) - halfHeight);

            } else if (direction == Direction.Vertical)
            {
                position.y = 0;
                Gizmos.DrawLine(position - new Vector3(0, size, 0) + halfWidth, position + new Vector3(0, size, 0) + halfWidth);
                Gizmos.DrawLine(position - new Vector3(size, 0, 0) - halfWidth, position + new Vector3(size, 0, 0) - halfWidth);

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
                
                UnityEditor.Handles.Label(rectTransform.position, $"{label}: pos:{p:0.0}, size:{width:0.0}", new GUIStyle()
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