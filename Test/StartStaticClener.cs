using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStaticClener : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        GameManager.achivement = 0;
        GameManager.convertMinute = 840;
        GameManager.day = 1;
        GameManager.isDoneTutorial = false;
    }
	
}
