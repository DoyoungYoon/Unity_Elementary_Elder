using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVFake : MonoBehaviour {
    Pedometer PedometerCount;
    int MoveCount=0;
    float timeLimit = 0.6f;
    float timeCount = 0f;
    public float xSpeed = 0.2f;
    // Use this for initialization
    // Update is called once per frame

    void Update () {
        MoveCount = PedometerCount.eventCount;
        if (MoveCount >= 1)
        {
            timeCount += Time.deltaTime;
            transform.position -= new Vector3(Time.deltaTime * xSpeed, 0, 0);
            if (timeCount > timeLimit)
            {
                MoveCount--;
            }
        }

        if (transform.position.x <= -50)
        {
            transform.position = new Vector3(29, 0, 0);
        }
    }
}
