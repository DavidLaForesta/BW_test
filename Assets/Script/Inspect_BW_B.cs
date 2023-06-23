using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using BW_BA;
using BW_BA.VisualElementUI;
using UnityEngine;

[CustomEditor(typeof(BW_Blance))]
public class Inspect_BW_B : Editor
{

    public VisualTreeAsset m_UXML;

    public BW_Blance bW;

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        //m_UXML.CloneTree(root);
        ObjectField sub = new ObjectField("Image") { objectType = typeof(Texture2D), bindingPath = "image" };

        root.Add(sub);
        if (bW.image!=null)
        {
            CurveField curve = new CurveField() { bindingPath = "BW_Balace", ranges = new Rect(-1, -1, 2, 2), };
            root.Add(curve);
        }

        var foldout = new Foldout();
        InspectorElement.FillDefaultInspector(foldout, serializedObject, this);
        root.Add(foldout);
        return root;
    }

#if false
    private bool one;
    private static string LastName;

    public bool Open;



    public override void OnInspectorGUI()
    {

        BW_Blance bW = (BW_Blance)target;

        bW.image = (Texture2D)EditorGUILayout.ObjectField(label:"Image",obj: bW.image,objType: typeof(Texture2D),allowSceneObjects: true);
        if (bW.image != null)
        {
            if (bW.image.name != LastName)
            {
                LastName = bW.image.name;
                bW.BW_Balace = AnimationCurve.Linear(-1, -1, 1, 1);
                bW.SetImmage(bW.image);
            }

            if (one)
            {
                one = false;
                bW.image.Apply();
            }
        }
        else
        {
            bW.SetImmage(bW.image);
            one = true;
            return;
        }

        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Curve");
        EditorGUILayout.CurveField(bW.BW_Balace, color: Color.white, ranges: new Rect(-1, -1, 2, 2), GUILayout.Height(400));
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("bilace") && bW.image != null)
        {
            Debug.Log("action");
            bW.BW_Blance_def();
        }
        if (GUILayout.Button("Reset Line") && bW.image != null)
        {
            Debug.Log("Reset Line");
            bW.BW_Balace = AnimationCurve.Linear(-1, -1, 1, 1);
            bW.BW_Blance_def();
        }
        EditorGUILayout.EndHorizontal();

        //EditorGUILayout.BeginFadeGroup(1);
        //DrawDefaultInspector();
        //EditorGUILayout.EndFadeGroup();

        //var root = new VisualElement();

        //var foldout = new Foldout() { viewDataKey = "FullInspector", text = "Full inspector" };
        //InspectorElement.FillDefaultInspector(foldout, serializedObject, this);
        //root.Add(foldout);
        DrawDefaultInspector();
    }
#endif
}