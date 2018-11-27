using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool interactable = true;
    [SerializeField]
    private bool runOnStart = false;

    public enum RepeateModes
    {
        Once,
        Repeat
    };    
    public RepeateModes repeateMode = RepeateModes.Once;

    public enum Actions
    {
        Move,
        ChangeVisibility,
        Rotate
    };
    public Actions Action = Actions.Move;

    public void Awake()
    {
        if( runOnStart ) { 
            InteractAction comp = GetComponent<InteractAction>();
            comp.ExecuteInteraction();
        }
    }

    public void ExecuteInteract()
    {
        InteractAction comp = GetComponent<InteractAction>();
        if( interactable )
        {
            comp.ExecuteInteraction();

            if( repeateMode == RepeateModes.Once )
            {
                interactable = false;
            }
        }
    }
}

