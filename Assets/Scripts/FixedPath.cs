using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPath : MonoBehaviour
{
    #region Variables
    public bool moveLerp = true;
    [Header("Moving with Coroutine")]
    public bool moving = true;
    public float myStep = 0.2f;
    public float distance = 10.0f;
    public float waitTime = 0.3f;
    [Header("Moving with Lerp")]
    public Transform side1;
    public Transform side2;
    public float speed = 1.0f;
    public float journeyLength = 3.0f;
    private float side = -1.0f;
    private float targetDistance;
    private float startTime;
    #endregion

    #region Func

    void Start()
    {
        startTime = Time.time;
        targetDistance = transform.position.x + (side * distance);
        if (!moveLerp) {
            StartCoroutine(MovePlatform());
        }
    }

    private void Update()
    {
        if (moveLerp) {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            // https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
            transform.position = Vector3.Lerp(side1.position, side2.position, fractionOfJourney);
            if (fractionOfJourney >= 1.0f) {
                // Qui metto il codice per cambiare destinazione e fare ping pong
            }
        }
    }

    IEnumerator MovePlatform()
    {
        while (moving) { // moving == true
            yield return new WaitForSeconds(waitTime);
            Vector3 pos = transform.position;
            pos.x += myStep * side;
            transform.position = pos;

            if ((transform.position.x <= targetDistance) && (side == -1.0f)) {
                targetDistance *= -1.0f;
                side *= -1.0f;
            }

            if ((transform.position.x >= targetDistance) && (side == 1.0f)) {
                targetDistance *= -1.0f;
                side *= -1.0f;
            }
        }
    }
    #endregion
}
