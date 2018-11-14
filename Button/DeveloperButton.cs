using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClicked()
    {
        GameManager.achivement += 10;
        if (GameManager.achivement > 100)
        {
            GameManager.achivement = 100;
        }

        GameObject.Find("GameManager").GetComponent<GameManager>().UpdateInform();
    }
}
