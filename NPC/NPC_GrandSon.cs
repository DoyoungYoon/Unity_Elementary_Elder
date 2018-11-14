using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_GrandSon : MonoBehaviour {

    public GameObject displayScript;
    public string[] fulltext =
        { "퇴원 축하드려요, 여기는 거실이고 평소에 저와 아버지가 이곳에 있어요.",
        "이쪽은 부엌이고, 어머니가 평소에 이곳에 계세요.",
        "배가 고프시면 어머니께 말씀을 드리고 식탁에서 식사를 하시면 돼요.",
        "이쪽은 안방이고 할머니께서 주무실 방이에요. 저녁 식사 후 22:00시 전에 주무시면 되세요.",
        "여기는 화장실이고 만보기 게임 이후에 샤워를 하셔야 재도전이 가능해요.",
        "산책이 나가고 싶으시면, 아버지께 말씀을 드리면 돼요.",
            "사진 찍고 카드 뒤집기를 하고 싶으시면 저한테 말씀을 드리면 돼요."
    };

    public int dialog_cnt;

    // Use this for initialization
    void Start () {
        //displayScript.GetComponent<TypeWriterEffect>().Get_Typing(dialog_cnt, fulltext);

    }

    // Update is called once per frame
    void Update () {
		
	}
    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            displayScript.GetComponent<TypeWriterEffect>().fulltext = fulltext;
            displayScript.GetComponent<TypeWriterEffect>().dialog_cnt = fulltext.Length;

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (displayScript.GetComponent<TypeWriterEffect>().text_start && !displayScript.GetComponent<TypeWriterEffect>().isTextTyping)
        {
            displayScript.GetComponent<TypeWriterEffect>().Get_Typing(dialog_cnt, fulltext);
            print("시작!");
        }

    }
    */
}
