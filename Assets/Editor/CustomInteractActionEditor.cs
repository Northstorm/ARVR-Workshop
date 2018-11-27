using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( InteractAction ), true )]
public class CustomInteractActionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        InteractAction interactAction = target as InteractAction;
        

        if( interactAction.HasCallback )
        {
            interactAction.CallbackObject = EditorGUILayout.ObjectField("Callback Object: ", interactAction.CallbackObject, typeof(InteractAction), true) as InteractAction;
            interactAction.CallbackDelay = EditorGUILayout.FloatField("Callback Delay: ", interactAction.CallbackDelay );
        }
    }
}
