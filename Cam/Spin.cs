using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float amount;
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(amount,amount,amount));	
	}
}
