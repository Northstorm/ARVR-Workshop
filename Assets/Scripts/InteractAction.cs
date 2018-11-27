using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractAction : MonoBehaviour {
    public bool HasCallback = false;
    
    [HideInInspector]
    public InteractAction CallbackObject;
    [HideInInspector]
    public float CallbackDelay;

    public abstract void ExecuteInteraction();

    protected IEnumerator Callback()
    {
        if( HasCallback )
        {
            float elapsedTime = 0f;
            while( elapsedTime < CallbackDelay )
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Interactable objectinteract = CallbackObject.gameObject.GetComponent<Interactable>();

            objectinteract.ExecuteInteract();
        }
    }
}
