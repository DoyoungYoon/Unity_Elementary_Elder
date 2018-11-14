using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButton : MonoBehaviour {

    public GameObject TypeWriterEffect;
    //public Player_Char player;
    public Sprite[] buttonImgs;
    public bool isClickedButton;
    public Transform[] buttonPositions;
	// Use this for initialization
	void Start () {
        isClickedButton = false;
        OnClick();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    
    public void OnClick()
    {
        //player.GetComponent<Player_Char>().isMovable = false;
        //print(player.GetComponent<Player_Char>().isNearNPC);

        isClickedButton = true;



        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().isNearNPC)
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().DisplayText();

        }
        

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().isNearBed)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().GoToBed();
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().isNearMeal)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().EatMeal();
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().isCanOutDoor)
        {
            //print("나가기");
            //야외 씬으로 로딩
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().isNearShower)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().TakeShower();
        }

        /*
    if (player.GetComponent<Player_Char>().isNearBed)
    {

        player.GetComponent<Player_Char>().GoToBed();
    }
    if (player.GetComponent<Player_Char>().isNearMeal)
    {
        player.GetComponent<Player_Char>().EatMeal();
    }
    if (player.GetComponent<Player_Char>().isCanOutDoor)
    {
        print("나가기");
        //야외 씬으로 로딩
    }*/
    }
}
