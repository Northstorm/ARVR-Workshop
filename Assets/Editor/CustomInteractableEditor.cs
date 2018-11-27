using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( Interactable ) )]
public class CustomInteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Interactable interactable = target as Interactable;
        
        switch ( interactable.Action )
        {
            case Interactable.Actions.Move:
                {
                    if( interactable.gameObject.GetComponent<InteractMove>() == null )
                    {
                        interactable.gameObject.AddComponent( typeof( InteractMove ) );
                    }

                    RemoveExistingComponants<InteractMove>( interactable );
                    break;
                }

            case Interactable.Actions.ChangeVisibility:
                {
                    if( interactable.gameObject.GetComponent<InteractChangeVisibility>() == null )
                    {
                        interactable.gameObject.AddComponent( typeof( InteractChangeVisibility ) );
                    }
                    
                    RemoveExistingComponants<InteractChangeVisibility>( interactable );
                    break;
                }

            case Interactable.Actions.Rotate:
                {
                    if( interactable.gameObject.GetComponent<InteractRotate>() == null )
                    {
                        interactable.gameObject.AddComponent( typeof( InteractRotate ) );
                    }

                    RemoveExistingComponants<InteractRotate>( interactable );
                    break;
                }
        }
    }

    private void RemoveExistingComponants<T>(Interactable interactable)
    {
        InteractAction[] comps = interactable.gameObject.GetComponents<InteractAction>();

        foreach( InteractAction action in comps )
        {
            if( !( action is T ) )
            {
                DestroyImmediate( interactable.gameObject.GetComponent<InteractAction>() );
                EditorGUIUtility.ExitGUI();
            }
        }

    }
}

