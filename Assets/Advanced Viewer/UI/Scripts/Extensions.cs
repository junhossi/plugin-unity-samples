using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PiXYZ.Plugin.Unity.Samples.AdvancedViewer {

    public static class Extensions {

        public static void SetCursor(Texture2D texture) {
            if (texture) {
                Cursor.SetCursor(texture, new Vector2(0.5f * texture.width, 0.5f * texture.height), CursorMode.Auto);
            } else {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }

        public static Sides2D GetSideUnderMouse(this RectTransform rectTransform, int margin) {

            float width = rectTransform.sizeDelta.x;
            float height = rectTransform.sizeDelta.y;
            Vector2 mousePosRelative = GetMousePosRelative(rectTransform);

            if (mousePosRelative.y > height
                || mousePosRelative.y < 0
                || mousePosRelative.x > width
                || mousePosRelative.x < 0) {
                return Sides2D.Out;
            }

            if (mousePosRelative.x < margin) {
                if (mousePosRelative.y < margin) {
                    return Sides2D.BottomLeft;
                } else if (mousePosRelative.y > height - margin) {
                    return Sides2D.TopLeft;
                } else {
                    return Sides2D.Left;
                }
            } else if (mousePosRelative.x > width - margin) {
                if (mousePosRelative.y < margin) {
                    return Sides2D.BottomRight;
                } else if (mousePosRelative.y > height - margin) {
                    return Sides2D.TopRight;
                } else {
                    return Sides2D.Right;
                }
            } else {
                if (mousePosRelative.y < margin) {
                    return Sides2D.Bottom;
                } else if (mousePosRelative.y > height - margin) {
                    return Sides2D.Top;
                } else {
                    return Sides2D.In;
                }
            }
        }

        public static Vector2 GetMousePosRelative(this RectTransform rectTransform) {
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);
            float width = corners[2].x - corners[0].x;
            float height = corners[2].y - corners[0].y;
            return new Vector2(Input.mousePosition.x - corners[0].x, Input.mousePosition.y - corners[0].y);
        }

        public static bool IsMouseDirectlyOver(this RectTransform rectTransform) {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            if  (results.Count > 0 && results[0].gameObject == rectTransform.gameObject) {
                return true;
            }
            return false;
        }
    }
}