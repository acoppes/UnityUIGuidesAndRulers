using UnityEngine;

namespace Gemserk.UIGuidesAndRulers
{
    [ExecuteInEditMode]
    public class UIGuide : MonoBehaviour
    {
        private static readonly float size = 10000;
        private static readonly float fillingAlpha = 0.1f;
        
        public enum Direction
        {
            Horizontal,
            Vertical
        }
        
        public string label;
        
        public RectTransform rectTransform;
        public Direction direction;
        public bool hide;
        public Color color = Color.magenta;

        public bool fill = true;

        public float width;

        private void LateUpdate()
        {
            if (direction == Direction.Horizontal)
            {
                rectTransform.sizeDelta = new Vector2(size, width);
            } else if (direction == Direction.Vertical)
            {
                rectTransform.sizeDelta = new Vector2(width, size);
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
                
                var adjustAnchor = rectTransform.pivot.y - 0.5f;
                position.y -= adjustAnchor * width;

                Gizmos.DrawWireCube(position, new Vector3(size, width, 0));

                if (fill)
                {
                    var c = color;
                    c.a = fillingAlpha;

                    Gizmos.color = c;
                    Gizmos.DrawCube(position, new Vector3(size, width, 0));
                }
            } else if (direction == Direction.Vertical)
            {
                position.y = 0;

                var adjustAnchor = rectTransform.pivot.x - 0.5f;
                position.x -= adjustAnchor * width;
                
                Gizmos.DrawWireCube(position, new Vector3(width, size, 0));

                if (fill)
                {
                    var c = color;
                    c.a = fillingAlpha;

                    Gizmos.color = c;
                    Gizmos.DrawCube(position, new Vector3(width, size, 0));
                }
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