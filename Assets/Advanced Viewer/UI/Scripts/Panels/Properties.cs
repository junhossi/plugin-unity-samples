using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using PiXYZ.Import;

namespace PiXYZ.Plugin.Unity.Samples.AdvancedViewer {

    [RequireComponent(typeof(Text))]
    public class Properties : MonoBehaviour {

        private RectTransform rectTransform;
        private Text text;

        void Awake() {
            Selection.SelectionChanged += Selection_SelectionChanged;

            text = GetComponent<Text>();
            rectTransform = GetComponent<RectTransform>();
            text.supportRichText = true;
        }

        private void Selection_SelectionChanged() {
            refresh();
        }

        public void refresh() {

            StringBuilder strbldr = new StringBuilder();
                
            if (Selection.Selected) {
                Metadata metadata = Selection.Selected.GetComponent<Metadata>();
                if (metadata) {
                    foreach (KeyValuePair<string, string> pair in metadata.getProperties()) {
                        strbldr.Append(pair.Key + " = " + pair.Value + "\n");
                    }
                }
            }

            text.text = strbldr.ToString();
            //rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, lines * text.fontSize * text.lineSpacing);
        }
    }
}