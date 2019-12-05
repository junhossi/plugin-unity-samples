using UnityEngine;

namespace PiXYZ.Samples
{
    public class Setup : MonoBehaviour
    {
        public static Setup Instance;

        public GameObject root;

        void Awake()
        {
            Instance = this;
        }
    }
}