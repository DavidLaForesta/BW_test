using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace mywindow
{
    public class Window : VisualElement
    {
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<Window> { }

        public const string USS_resurce = "TestUITK_USS";
        protected string[] USS_Class_all = new string[] { "Wind_Bord" };
        protected string[] USS_Class_Visual = new string[] { "wind_Window" };

        public Window()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(USS_resurce));

            ClassUSS(USS_Class_all);
            
            VisualElement Wind = new VisualElement();

            ClassUSS(USS_Class_Visual, Wind);
        }

        private void ClassUSS(string[] USS_Class ,VisualElement VE = null )
        {
            if (VE==null)
            {
                foreach (string classUSS in USS_Class)
                {
                    AddToClassList(classUSS);
                }
            }
            else
            {
                foreach (string classUSS in USS_Class)
                {
                    VE.AddToClassList(classUSS);
                }
                hierarchy.Add(VE);
            }
        }
    }
}