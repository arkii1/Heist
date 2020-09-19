using System.Collections;
using System.Collections.Generic;
using SP;
using UnityEngine;


public class DoorObject : MonoBehaviour, IInteractable
{
    public float speed = 5;

    public bool reverseDir = false;

    float degreesRotated = 0;

    bool isRotating = false;

    public void Interact(StateManager state)
    {
        bool rotateClockwise = false;

        float dot = Vector3.Dot(transform.forward, state.mTransform.position - transform.position);

        rotateClockwise = dot > 0 ? false : true;

        if (reverseDir)
            rotateClockwise = !rotateClockwise;


        if (isRotating)
        {
            StopAllCoroutines();
            StartCoroutine(RotateDoor(rotateClockwise));
        }
        else
        {
            StartCoroutine(RotateDoor(rotateClockwise));
        }
    }

    IEnumerator RotateDoor(bool isRotatingClockwise)
    {
        float s = isRotatingClockwise ? speed : -speed;

        if(degreesRotated > 89.5f && isRotatingClockwise || degreesRotated < -89.5f && !isRotatingClockwise)
        {
            Debug.Log("Not rotating. Trying to rotate clockwise? :" + isRotatingClockwise);

            yield return null;
        }
        else
        {
            float amountToRot = 90;
            //90 is how much we want door to rotate in degrees

            if(isRotating) // already rotating
                amountToRot = 90 - Mathf.Abs(degreesRotated);

            float startDegreeRot = degreesRotated;

            isRotating = true;
            while (Mathf.Abs(degreesRotated - startDegreeRot) < amountToRot)
            {
                degreesRotated += s * Time.deltaTime;

                transform.Rotate(transform.up, s * Time.deltaTime);

                yield return null;
            }
            isRotating = false;
        }
    }
}
