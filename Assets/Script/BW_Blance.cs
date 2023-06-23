using UnityEngine;
using UnityEngine.UI;

namespace BW_BA
{
    public class BW_Blance : MonoBehaviour
    {
        [HideInInspector]
        public AnimationCurve BW_Balace = AnimationCurve.Linear(-1, -1, 1, 1);

        public Texture2D image;
        public Texture2D image_B;

        private Color[] ACT;

        private SpriteRenderer SR;
        private bool SRSerch()
        {
            SR = GetComponent<SpriteRenderer>();
            return SR != null ? true : false;
        }

        public void BW_Blance_def()
        {
            if (!EnableCheck()) { return; }

            float H;
            float S;
            float V;

            ACT = new Color[image.width * image.height];

            ACT = image.GetPixels();

            for (int i = 0; i < ACT.Length; i ++)
            {
                Color.RGBToHSV(ACT[i], out H, out S, out V);

                V = System.MathF.Round(V, 3);
                V = ((V * 2) - 1);
                V = BW_Balace.Evaluate(V);
                V = (V + 1) / 2;
                if (V < 0) { V = 0; }
                else if (V > 1) { V = 1; }
                ACT[i] = Color.HSVToRGB(H, S, V);
            }

            image_B = new Texture2D(image.width, image.height, TextureFormat.RGBA32, true) {alphaIsTransparency = true };
            image_B.Apply();

            image_B.SetPixels(ACT);
            image_B.Apply();

            SetImmage(image_B);

        }

        private bool EnableCheck()
        {
            if (image != null)
            {
                Debug.Log($"run image: {image} SR: {SR}");
                return true;
            }
            else
            {
                Debug.Log("exit");
                return false;
            }
        }

        public void SetImmage( Texture2D image)
        {
            if(image == null)
            {
                SR.sprite = null;
                return;
            }

            if (SRSerch())
            {
                SR.sprite = Sprite.Create(image,rect: new Rect(position:Vector2.zero,new Vector2(image.width,image.height)),Vector2.zero);
            }
        }
    }
}
