using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour {
    public GameObject BlindWall = null;

    public float limitTime = 0f;
    
	// Use this for initialization
	void Start () {
		
	}
	

    public void ChangeScreen()
    {
        Debug.Log("dho");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
	// Update is called once per frame
	void Update () {
        limitTime += Time.deltaTime;
        if (limitTime>4)
        {
            BlindWall.SetActive(false);

        }
    }
}
