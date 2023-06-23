using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BW_Balace;
using UnityEditor.Timeline;
using UnityEngine.Playables;

//[CustomEditor(typeof(Image_Reader))]
public class Editor_test : Editor
{
    string P = "Password";

    private void Awake()
    {
    }

    public override void OnInspectorGUI()
    { 
        Image_Reader IR = (Image_Reader)target;

        DrawDefaultInspector();
        GUILayout.Button("ciao");
        P = GUILayout.PasswordField(P, '°');
        Debug.Log(P);
        EditorGUILayout.CurveField("curve", IR.curve,color: Color.white,ranges: new Rect(-1,0,2,2),GUILayout.Height(400));

        SerializedProperty @object = (new SerializedObject(CreateInstance<MyTestClass>())).FindProperty("curve");

        EditorGUILayout.CurveField(property:@object, color: Color.white, ranges: new Rect(-1, -1, 2, 2));
         
    }

    public class MyTestClass : ScriptableObject
    {
        public AnimationCurve curve { get; set; } = AnimationCurve.Linear(-1, -1, 1, 1);
    }

}