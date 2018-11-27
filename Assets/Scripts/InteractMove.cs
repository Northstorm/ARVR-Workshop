using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMove : InteractAction{

    //Fields for the "Move" action
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    private bool _inOriginalPosition = true;
    
    [SerializeField]
    private GameObject _targetPositionObject;
    private Vector3 _targetPosition;
    private Quaternion _targetRotation;
    public float Duration;


    public override void ExecuteInteraction()
    {
        Move();
        StartCoroutine( Callback() );
    }

    public void Awake()
    {
        _originalPosition = gameObject.transform.position;
        _originalRotation = gameObject.transform.rotation;
        _targetPosition = _targetPositionObject.transform.position;
        _targetRotation = _targetPositionObject.transform.rotation;
    }

    private void Move()
    {
        StopCoroutine("_TranslateOverTime");
        if( _inOriginalPosition )
        {
            _inOriginalPosition = false;
            StartCoroutine( TranslateOverTime( _targetPosition, _targetRotation, Duration ) );
        }
        else
        {
            _inOriginalPosition = true;
            StartCoroutine( TranslateOverTime( _originalPosition, _originalRotation, Duration ) );
        }
    }

    private IEnumerator TranslateOverTime(Vector3 targetPosition, Quaternion targetRotation, float duration )
    {
        Vector3 currentPosition = gameObject.transform.position;
        Quaternion currentRotation = gameObject.transform.rotation;
        float elapsedTime = 0;
        float ratio = elapsedTime / duration;

        while( ratio < 1f )
        {
            transform.position = Vector3.Lerp( currentPosition, targetPosition, ratio );
            transform.rotation = Quaternion.Slerp( currentRotation, targetRotation, elapsedTime / duration );

            elapsedTime += Time.deltaTime;
            ratio = elapsedTime / duration;

            yield return null;
        }
    }
}
