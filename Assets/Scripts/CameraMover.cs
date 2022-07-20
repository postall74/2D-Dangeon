using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _freeHorizontalMovment = 0.5f;
    [SerializeField] private float _freeVerticalMovment = 0.3f;


    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = _player.position.x - transform.position.x;

        if (deltaX > _freeHorizontalMovment || deltaX < -_freeHorizontalMovment)
        {
            if (transform.position.x < _player.position.x)
                delta.x = deltaX - _freeHorizontalMovment;
            else
                delta.x = deltaX + _freeHorizontalMovment;
        }

        float deltaY = _player.position.y - transform.position.y;

        if (deltaY > _freeVerticalMovment || deltaY < -_freeVerticalMovment)
        {
            if (transform.position.y < _player.position.y)
                delta.y = deltaY - _freeVerticalMovment;
            else
                delta.y = deltaY + _freeVerticalMovment;
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

    /*
    private float GetDelta(float playerPositinAxis, float cameraPositionAxis, float sizeFreeMovment)
    {
        float deltaAxis = playerPositinAxis - cameraPositionAxis;

        if (deltaAxis > sizeFreeMovment || deltaAxis < -sizeFreeMovment)
        {
            if (cameraPositionAxis < playerPositinAxis)
                return deltaAxis - sizeFreeMovment;
            else
                return deltaAxis + sizeFreeMovment;
        }
        return deltaAxis;
    }
    */
}
