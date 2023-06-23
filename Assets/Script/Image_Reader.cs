using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace BW_Balace
{

    public class Image_Reader : MonoBehaviour
    {
        public Image image;

        //public IEquatable<AnimationCurve> = IEquatable<AnimationCurve>;
        [SerializeReference]
        public AnimationCurve curve = AnimationCurve.Linear(-1, -1, 1, 1);

        //
        // Riepilogo:
        //     Set the curve describing the width of the line at various points along its length.
        public AnimationCurve C { get; private set; } = AnimationCurve.Linear(-1, -1, 1, 1);

        public Gradient gradient;

        public AnimationCurve Ac = new AnimationCurve();

        private void Awake()
        {
            C = curve;
        }

        private void Start()
        {
        }
    }
}
