using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractChangeVisibility : InteractAction {

    [SerializeField]
    private bool startAsHidden = false;

    public override void ExecuteInteraction()
    {
        ChangeVisibility();
        StartCoroutine( Callback() );
    }

    public void Update()
    {
        if( startAsHidden && GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        }
    }

    private void ChangeVisibility()
    {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        startAsHidden = false;
    }
}
