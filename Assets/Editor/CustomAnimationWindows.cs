using UnityEngine;
using UnityEditor;
using System.Collections;

class CustomAnimationWindows : EditorWindow {
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    int TargetValueSlider = 0;
    int toIntValueSlider;
    int fromeIntValueSlider;
    int StartFrameAnimation = 0,
        FinishFrameAnimation = 10;

    [MenuItem("Window/Custom animation")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CustomAnimationWindows));
    }

    void OnGUI()
    {
        if (GUILayout.Button("Create New Animation"))
        {
            if (!groupEnabled)
            {
                groupEnabled = true;
            }
            else
            {
                groupEnabled = false;
            }
        }


        if (GUILayout.Button("Load Animation"))
        {

        }

        //Количество кадров которое нам нужно
        groupEnabled = EditorGUILayout.BeginToggleGroup("New Animation", groupEnabled);
        toIntValueSlider = EditorGUILayout.IntField("Start frame Animation", StartFrameAnimation);
        StartFrameAnimation = toIntValueSlider;
        fromeIntValueSlider = EditorGUILayout.IntField("Start frame Animation", FinishFrameAnimation);
        FinishFrameAnimation = fromeIntValueSlider;

        TargetValueSlider = EditorGUILayout.IntSlider("Slider", TargetValueSlider, toIntValueSlider, fromeIntValueSlider);
        EditorGUILayout.EndToggleGroup();


    }
}




        /*GUILayout.Label("Name New Animation", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);*/

            /*groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
            myBool = EditorGUILayout.Toggle("Toggle", myBool);
            myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
            EditorGUILayout.EndToggleGroup();*/