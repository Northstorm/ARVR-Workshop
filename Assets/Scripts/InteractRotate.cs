using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRotate : InteractAction {

    [SerializeField]
    private int degreesPerSecond;

    [SerializeField]
    private float duration;

    public enum TurnDirection{
        Up,
        Down,
        Left,
        Right,
        Forward,
        Backward
    }
    public TurnDirection Direction = TurnDirection.Right; 

    public override void ExecuteInteraction()
    {
        Rotate();
        StartCoroutine( Callback() );
    }

    private void Rotate()
    {
        StartCoroutine( RotateOverTime() );
    }

    private IEnumerator RotateOverTime()
    {
        float eleapsedTime = 0;
        float ratio = 0f;

        Vector3 rotationDirection = new Vector3(0,0,0);

        switch( Direction )
        {
            case TurnDirection.Up:
                {
                    rotationDirection = Vector3.up;
                    break;
                }
            case TurnDirection.Down:
                {
                    rotationDirection = Vector3.down;
                    break;
                }
            case TurnDirection.Left:
                {
                    rotationDirection = Vector3.left;
                    break;
                }
            case TurnDirection.Right:
                {
                    rotationDirection = Vector3.right;
                    break;
                }
            case TurnDirection.Forward:
                {
                    rotationDirection = Vector3.forward;
                    break;
                }
            case TurnDirection.Backward:
                {
                    rotationDirection = Vector3.back;
                    break;
                }
        }

        while(ratio < 1f)
        {
            float newAngle = gameObject.transform.rotation.z + (Math.Abs(degreesPerSecond) * Time.deltaTime);
            gameObject.transform.Rotate( rotationDirection * newAngle);
            
            eleapsedTime += Time.deltaTime;
            ratio = eleapsedTime / duration;
            yield return null;
        }
    }
}
