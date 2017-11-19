using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movestick : MonoBehaviour
{

    int posNum;
    float inputTime;
    public float[] timelines;

    public Vector3 pos0;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;

    // Use this for initialization
    void Start()
    {
        posNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputTime = Time.time;
            if (posNum == 0)
            {
                transform.position = pos0;
                posNum = 1;
            }
            else if (posNum == 1)
            {
                transform.position = pos1;
                posNum = 2;
            }
            else if (posNum == 2)
            {
                transform.position = pos2;
                posNum = 3;
            }
            else if (posNum == 3)
            {
                transform.position = pos3;
                posNum = 4;
            }
            else if (posNum == 4)
            {
                transform.position = pos4;
                posNum = 0;
            }


        }
    }

    void CheckTime()
    {
        for (int i = 0; i < timelines.Length; i++)
        {
            if (inputTime > 0) { }
        }
    }
}
