using UnityEngine;

public class Setup : MonoBehaviour {

    public static Setup Instance;

    public GameObject root;
    public ReflectionProbe probe;

    void Awake() {
        Instance = this;
    }

    private void Start() {
        refreshProbe();
    }

    public void refreshProbe() {
        probe?.RenderProbe();
    }
}
