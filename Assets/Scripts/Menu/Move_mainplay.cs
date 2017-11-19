using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_mainplay : MonoBehaviour
{ 
    public void MoveScene()
    {
        SceneManager.LoadScene(2);
    }
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveScene();
        }
    }
}