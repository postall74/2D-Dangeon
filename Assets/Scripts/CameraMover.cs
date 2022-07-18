using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _freeHorizontalMovment = 0.15f;
    [SerializeField] private float _freeVerticalMovment = 0.05f;


    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        delta.x = GetDelta(_player.position.x, transform.position.x, _freeHorizontalMovment);
        delta.y = GetDelta(_player.position.y, transform.position.y, _freeVerticalMovment);

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

    private float GetDelta(float playerPositinAxis, float cameraPositionAxis, float size)
    {
        float deltaAxis = playerPositinAxis - cameraPositionAxis;

        if (deltaAxis > size || deltaAxis < -size)
        {
            if (cameraPositionAxis < playerPositinAxis)
                return deltaAxis - size;
            else
                return deltaAxis + size;
        }
        return deltaAxis;
    }
}
