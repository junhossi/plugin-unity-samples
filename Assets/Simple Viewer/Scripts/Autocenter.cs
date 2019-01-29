using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Autocenter : MonoBehaviour {
	
	private Bounds totalBounds;

	// Update is called once per frame
	void Update () {

        Bounds? nbounds = GetTreeBounds(transform);

        if (nbounds == null)
            return;

        totalBounds = (Bounds)nbounds;

        Vector3 worldbounds = totalBounds.center;

		foreach(Transform grandChild in this.transform)
			grandChild.Translate(-worldbounds.x, 0, -worldbounds.z, this.transform);
	}

    public static Bounds? GetTreeBounds(Transform transform) {

        bool first = true;
        Bounds bounds = new Bounds();

        Stack<Transform> tsms = new Stack<Transform>();
        tsms.Push(transform);

        Renderer renderer;

        while (tsms.Count != 0) {

            Transform current = tsms.Pop();
            renderer = current.GetComponent<Renderer>();

            if (renderer != null) {
                if (first) {
                    first = false;
                    bounds = renderer.bounds;
                }
                else {
                    bounds.Encapsulate(renderer.bounds);
                }
            }

            foreach (Transform child in current) {
                tsms.Push(child);
            }
        }

        if (first)
            return null;

        return bounds;
    }
}
