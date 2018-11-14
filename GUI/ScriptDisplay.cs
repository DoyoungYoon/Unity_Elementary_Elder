using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptDisplay : MonoBehaviour {

    public Text displayText;

	void Start () {
		


	}

	void Update () {
		

	}

    public void DisplayScript()
    {
        for(int i =0; i< displayText.text.Length; i++)
        {
            StartCoroutine("DelayDisplayScript");
        }
        
    }

    IEnumerator DelayDisplayScript()
    {

        yield return new WaitForSeconds(.1f);
    }
}
