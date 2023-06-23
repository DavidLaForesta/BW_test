using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace BW_BA.VisualElementUI
{

    public class Inspect_BW : BindableElement
    {
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<Inspect_BW> { }
        public new class UxmlTraits : BindableElement.UxmlTraits
        {
            UxmlBoolAttributeDescription m_active_Curve = new UxmlBoolAttributeDescription { name = "active Curve", defaultValue = true};

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var INS_BW = ve as Inspect_BW;
                INS_BW.active_Curve = m_active_Curve.GetValueFromBag(bag, cc);
            }
        }

        public bool active_Curve { 
            get => m_active_Curve; 
            set => m_active_Curve = value; 
        }

        public bool m_active_Curve = true;

        public Inspect_BW()
        {

            VisualElement Main = new VisualElement();
            ObjectField sub = new ObjectField("Image") { objectType = typeof(Texture2D), bindingPath = "image" };
            Main.Add(sub);

            if (m_active_Curve)
            {
                CurveField curve = new CurveField() { bindingPath = "BW_Balace", ranges = new Rect(-1, -1, 2, 2), };
                Main.Add(curve);
            }


            hierarchy.Add(Main);
        }
    }

}