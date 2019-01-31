using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PiXYZ.Plugin.Unity.Samples.AdvancedViewer {

    [RequireComponent(typeof(Text))]
    public class Hierarchy : MonoBehaviour {
        public GameObject root;

        private RectTransform rectTransform;
        private Text text;
        private int lines;
        private HashSet<int> selected = new HashSet<int>();

        void Awake() {
            text = GetComponent<Text>();
            rectTransform = GetComponent<RectTransform>();
            text.supportRichText = true;
            refresh();
        }

        private void Update() {
            //if (Input.GetMouseButtonDown(0) && rectTransform.IsMouseDirectlyOver()) {
            //    int s = (int)((rectTransform.sizeDelta.y - rectTransform.GetMousePosRelative().y) / (text.fontSize * text.lineSpacing));
            //    if (selected.Contains(s))
            //        selected.Remove(s);
            //    else
            //        selected.Add(s);
            //    refresh();
            //}
        }

        public void refresh() {
            if (root) {
                lines = 0;
                StringBuilder strbldr = new StringBuilder();
                addNode(root.transform, strbldr, 0);
                text.text = strbldr.ToString();
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, lines * text.fontSize * text.lineSpacing);
            }
        }

        private void addNode(Transform transform, StringBuilder strbldr, int level) {
            lines++;
            foreach (Transform child in transform.transform) {
                if (selected.Contains(lines)) {
                    strbldr.Append("<color=yellow>");
                }
                if (child.GetComponent<Renderer>()) {
                    strbldr.Append(new string('\t', level) + "<i>" + child.name + "</i>\n");
                } else {
                    strbldr.Append(new string('\t', level) + child.name + '\n');
                }
                if (selected.Contains(lines)) {
                    strbldr.Append("</color>");
                }
                addNode(child, strbldr, level + 1);
            }
        }
    }
}