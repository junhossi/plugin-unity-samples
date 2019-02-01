using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleTwoTones : MonoBehaviour
{
    private Toggle toggle;

    void Start() {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        OnToggleValueChanged(toggle.isOn);
    }

    private void OnToggleValueChanged(bool isOn) {
        ColorBlock cb = toggle.colors;
        if (!isOn) {
            cb.normalColor = Color.gray;
            cb.highlightedColor = Color.gray;
        } else {
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
        }
        toggle.colors = cb;
    }
}
