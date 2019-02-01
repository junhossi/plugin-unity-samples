using UnityEngine;

namespace PiXYZ.Plugin.Unity.Samples.AdvancedViewer {

    public class Autocenter : MonoBehaviour {

        private Bounds totalBounds;

        void Update() {

            Bounds? nbounds = transform.GetTreeBounds();

            if (nbounds == null)
                return;

            totalBounds = (Bounds)nbounds;

            Vector3 worldbounds = totalBounds.center;

            foreach (Transform grandChild in this.transform)
                grandChild.Translate(-worldbounds, this.transform);
        }
    }
}
