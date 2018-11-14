using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UV : MonoBehaviour {

    MeshRenderer rend;
    public float scrollSpeed = 1.0f;
    float offset;
    public float speed2 = 0.5f;


    Texture2D T;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        offset += Time.deltaTime * scrollSpeed * speed2;
        //Debug.Log(offset);
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
