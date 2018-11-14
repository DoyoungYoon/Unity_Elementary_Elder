using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player_Char : MonoBehaviour
{
    int index = 0;
    int tutorialIndex = 0;
    bool isEatingTime;
    string[] sonScripts =
    {
        "What do you need??",       //10
        "Dad, let’s go walk! please?",
        "What do you want?",         //20
        "Dad, let’s go walk together?",
        "What do you need??",       //30
        "Uncle, let’s go walk.",
        "What do you want?",        //40
        "Let’s go walk together uncle.",
        "What do you need, mom?",       //50
        "My son, Shall we go for a walk together?",
        "What do you want, mom?",        //60
        "Let’s go walk around together my son."
    };
    int[] sonScriptsID = { 0,3,0,3,0,3,0,3,0,3,0,3 };
    int[] splitSonScriptsID = {0,2,4,6,8,10 };

    string[] responseAnswerSon =
    {
        "Okay, wait a minute please.",
        "Mom, before go out side, you should take a shower first."
    };

    string[] daughterTalkingScripts =
    {
        " Mom, what are you doing? If you have nothing to do, let's play! ",        //10
        "No I can’t, You haven't finished your work today. I'll play with you if you're done with it. ",
        "Okay..You promise with me!",
        "Mom, what are you doing?",                         //20
        "I was washing the dishes right now.",
        "Let me help you?",
        "No it’s okay, Did you finished your work today?",
        "My work..? Do I have work to do?",
        "Check it again~",
        "Aunt, What are you doing?",             //30
        "I'm doing homework, do you need something?",
        "No, I just want to know what are you doing..",
        "If you need something talk to me please.",
        "What are you doing, aunt?",            //40
        "I’m cleaning kitchen, do you need something?",
        "How long you gonna do only homework?, let’s chat together.",
        "You didn’t finished your work yet. let’s chat together later. Now, we have one’s own work to do.",
        "Don’t miss the promise?",
        "What are you doing daughter-in-law?",       //50
        "Oh, you call me ‘daughter-in-law’ again? it’s good to see your memory are curing.",
        "Than what should I call my daughter-in-law?",
        "Nothing.. If you need something, talk it please.",
        "What are you doing grandson’s mom?",       //60
        "Oh you can now recognize grandson? It’s a very good news.. Do you have anything you want eat?",
        "Today you show of cooking skills? I’m expecting about that.",
        "I’ll cook everything you want to eat so tell me please~"
    };
    int[] daughterTalkingScriptsID = { 3, 1, 3, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 3, 1, 3, 1 , 3, 1, 3, 1 };
    int[] splitDaughterTalkingScriptsID = {0,3,9,13,18,22 };

    string[] daughterEatingScripts =
    {
        "Give a meat a lot!",       //10
        "Don’t eat only meat, eat variety.",
        "Mom, give me a meal please.",       //20
        "Wait a second, i’ll give you quickly.",
        "Give me a meal, aunt.",                //30
        "Are you hungry? I’ll set it soon, wait a minute.",
        "Aunt, give me a meal please.",      //40
        "You must been hungry, I’ll set it right now." ,
        "When the meal setting done, daughter-in-law?",     //50
        "Almost done~",
        "We have to eat meal grandson’s mom.",              //60
        "I will prepare foods that you like."
    };
    int[] daughterEatingScriptsID = { 3,1,3,1,3,1,3,1,3,1 };
    int[] splitDaughterEatingScriptsID = {0,2,4,6,8,10};

    string[] tutorialScripts =
    {
        "Congratulations on your leave hospital. This is living room, My father and I are usually here.",
        "This is kitchen, My mom usually here.",
        "If you hungry, talk to mother and eat meal on table.",
        "You have to eat meal on 09:00, 13:00, 18:00 (+- 30 minutes). You can eat meal by daughter-in-law.",
        "This is bedroom and you will sleep at here. after dinner you should go to sleep before 22:00.",
        "This is toilet and you can retry pedometer game after take a shower. ",
        "If you want to retry pedometer game, you must have to do shower.",
        "If you want to go walk, talk to my father.",
        "If you want to play matching game, talk to me.",
    };
    int[] tutorialScriptsID = { 2, 2, 2, 2, 2, 2, 2, 2, 2 };

    string[] grandSonScripts =
    {
        "Hey friend! let’s play matching game!" ,
        "Yes! Let’s play game together! Can you win?",
        "Hey friend! let’s play matching game!" ,
        "Yes! Let’s play game together! Can you win?",
        "Let’s play together nephew?",
        "Yes! Let’s play game together! Can you win?",
        "Let’s play game together my son?",
        "Yes! Let’s play game together! Can you win?",
        "Let’s play game together my son?",
        "Yes! Let’s play game together! Can you win?",
        "My grandson, shall we play games together?",
        "Yes! Let’s play game together! Can you win?"
    };
    int[] grandSonScriptsID = { 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2 };
    int[] splitGrandSonScriptsID = { 0, 2, 4, 6, 8, 10 };




    public int[] countScripts = { 0, 0, 0, 0 };
    public Image textBackground;
    public int age;
    public Text displayText;
    public Camera mainCamera;
    public float moveSpeed;
    private Touch tempTouchs;
    private Vector3 touchedPosition;
    private bool isTouchOn;
    public bool isNearNPC;
    public bool isNearMeal;
    public bool isNearBed;
    public bool isNearShower;
    public GameObject meal;
    public GameManager gameManager;
    public bool isMovable;
    public bool isCanOutDoor;
    public bool isTakeShower;
    public int getID;
    public GameObject button;
    public Sprite[] GUIImages;
    bool isAnswerSon;
    private Vector3 screenPosition;
    Animator animator;
    SpriteRenderer renderer;

    void setScripts() {
        switch (age)
        {
            case 1:
                index = 0;
                break;
            case 2:
                index = 1;
                break;
            case 3:
                index = 2;

                break;
            case 4:
                index = 3;

                break;
            case 5:
                index = 4;
                break;
            case 6:
                index = 5;
                break;
        }

        countScripts[0] = splitSonScriptsID[index];
        countScripts[2] = splitGrandSonScriptsID[index];
        if (gameManager.mealTimes[0] <= GameManager.convertMinute && GameManager.convertMinute <= gameManager.mealTimes[0] + gameManager.relaxedTimer ||
            gameManager.mealTimes[1] <= GameManager.convertMinute && GameManager.convertMinute <= gameManager.mealTimes[1] + gameManager.relaxedTimer ||
            gameManager.mealTimes[2] <= GameManager.convertMinute && GameManager.convertMinute <= gameManager.mealTimes[2] + gameManager.relaxedTimer)
        {
            countScripts[1] = splitDaughterEatingScriptsID[index];
            isEatingTime = true;
        }
        else
        {
            countScripts[1] = splitDaughterTalkingScriptsID[index];
            isEatingTime = false;
        }

    }
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        isTakeShower = false;
        button = GameObject.Find("Bt_Interactive");
        setScripts();
        if (!GameManager.isDoneTutorial)
        {
            DisplayText();
        }
        isMovable = true;


    }

    void Update()
    {
        Event();
        //print(isNearNPC);
    }

    void FixedUpdate()
    {

        TouchScreen();
        TestTouchScreen();
        if (isMovable)
        {
            CharacterMove();
        }
        

    }

    void TouchScreen()
    {
        isTouchOn = false;

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouchs = Input.GetTouch(i);
                if (tempTouchs.phase == TouchPhase.Began)
                {
                    touchedPosition = Camera.main.ScreenToWorldPoint(tempTouchs.position);

                    isTouchOn = true;

                    Vector2 wp = touchedPosition;
                    Ray2D ray = new Ray2D(wp, Vector2.zero);
                    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                    
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "MainCamera")
                        {
                            isMovable = false;
                        }
                        else
                        {
                            isMovable = true;
                        }
                        //Debug.Log("Complete" + hit.collider.name);
                        //Destroy(hit.collider.gameObject);
                    }
                    else
                        isMovable = true;

                    break;
                }
            }
        }

        //print(isTouchOn);
    }

    void TestTouchScreen()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.farClipPlane;
            screenPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            screenPosition -= this.transform.position;
            //print(screenPosition);
        }
        else
            screenPosition = Vector3.zero;
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "MainCamera")
                {
                    isMovable = false;
                }
                else
                {
                    isMovable = true;
                }
                //Debug.Log("Complete" + hit.collider.name);
                //Destroy(hit.collider.gameObject);
            }
            else
                isMovable = true;
        }
        */

    }


    void CharacterMove()
    {
        Vector3 moveVelocity = Vector3.zero;


        if (screenPosition.x < -3 && screenPosition.y < 1.5 && screenPosition.y > -1.5)
        {
            moveVelocity = Vector3.left;
            renderer.flipX = false;
            animator.SetBool("isWalking",true);
            //print("left");
        }
        else if (screenPosition.x > 3 && screenPosition.y < 1.5 && screenPosition.y > -1.5)
        {
            moveVelocity = Vector3.right;
            renderer.flipX = true;
            animator.SetBool("isWalking", true);
            //print("right");
        }
        else if (screenPosition.y < -1.5   && screenPosition.x < 3 && screenPosition.x > -3)
        {
            moveVelocity = Vector3.down;
            animator.SetBool("isWalking", true);
            //print("down");
        }
        else if (screenPosition.y > 1.5 && screenPosition.x < 3 && screenPosition.x > -3)
        {
            moveVelocity = Vector3.up;
            animator.SetBool("isWalking", true);

            //print("up");
        }

        if(moveVelocity == Vector3.zero)
        {
            animator.SetBool("isWalking", false);
        }


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            moveVelocity = Vector3.down;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            moveVelocity = Vector3.up;
        }
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    public void EatMeal()
    {
        if(meal != null)
        {
            gameManager.GetAchivementMealPoint();
            gameManager.isSuccessEatMeal = true;
            Destroy(meal);
        }
    }

    public void Timer()
    {

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "NPC")
        {
            getID = col.gameObject.GetComponent<NPC>().id;
            isNearNPC = true;

        }

        if (col.gameObject.tag == "Meal")
        {
            isNearMeal = true;
            meal = col.gameObject;
        }

        if(col.gameObject.tag == "Bed")
        {
            isNearBed = true;
        }

        if (col.gameObject.tag == "Shower")
        {
            isNearShower = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Meal")
        {
            isNearMeal = false;
            meal = null;
        }

        if (col.gameObject.tag == "NPC")
        {
            getID = col.gameObject.GetComponent<NPC>().id;
            isNearNPC = false;
        }

        if (col.gameObject.tag == "Bed")
        {
            isNearBed = false;
        }

        if (col.gameObject.tag == "Shower")
        {
            isNearShower = false ;
        }


    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Door")
        {
            isCanOutDoor = true;
        }
        else
        {
            isCanOutDoor = false;
        }
    }

    public void DisplayText()
    {
        isMovable = false;
        if (GameManager.isDoneTutorial)
        {
            button.GetComponent<Image>().sprite = button.GetComponent<InteractiveButton>().buttonImgs[1];
            button.GetComponent<Image>().SetNativeSize();

            //print(countScripts[0]);
            //print(countScripts[1]);
            //print(countScripts[2]);
            //print(countScripts[3]);

            switch (getID)
            {
                case 0:
                    if (countScripts[0] < splitSonScriptsID[index + 1])
                    {
                        //textBackground.gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(true);
                        GameObject.Find("TextGUIChar").GetComponent<Image>().sprite = GUIImages[sonScriptsID[countScripts[0]]];
                        
                        displayText.text = sonScripts[countScripts[0]];
                        countScripts[0]++;
                    }
                    else if (!isAnswerSon)
                    {
                        if (isTakeShower)
                        {
                            GameObject.Find("TextGUIChar").GetComponent<Image>().sprite = GUIImages[0];

                            displayText.text = responseAnswerSon[0];
                            Invoke("FadeIn", 1f);
                            Invoke("LoadWalkingScene", 2f);
                            isTakeShower = false;
                            isAnswerSon = true;
                        }
                        else
                        {
                            GameObject.Find("TextGUIChar").GetComponent<Image>().sprite = GUIImages[0];

                            displayText.text = responseAnswerSon[1];
                            isAnswerSon = true;

                        }
                    }
                    else
                    {
                        countScripts[0] = splitSonScriptsID[index + 1] - 2;
                        //textBackground.gameObject.SetActive(false)
                        GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(false);
                        displayText.text = "";
                        button.GetComponent<Image>().sprite = button.GetComponent<InteractiveButton>().buttonImgs[0];
                        button.GetComponent<Image>().SetNativeSize();
                    }
                    break;
                case 1:
                    if (isEatingTime)
                    {
                        if (countScripts[1] < splitDaughterEatingScriptsID[index + 1])
                        {
                            //textBackground.gameObject.SetActive(true);
                            GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(true);
                            GameObject.Find("TextGUIChar").GetComponent<Image>().sprite = GUIImages[daughterEatingScriptsID[countScripts[1]]];
                            displayText.text = daughterEatingScripts[countScripts[1]];
                            countScripts[1]++;
                        }
                        else
                        {
                            countScripts[1] = splitDaughterEatingScriptsID[index + 1] - 1;
                            //textBackground.gameObject.SetActive(false)
                            GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(false);
                            displayText.text = "";
                            button.GetComponent<Image>().sprite = button.GetComponent<InteractiveButton>().buttonImgs[0];
                            button.GetComponent<Image>().SetNativeSize();

                        }
                    }
                    else
                    {
                        if (countScripts[1] < splitDaughterTalkingScriptsID[index + 1])
                        {
                            //textBackground.gameObject.SetActive(true);
                            GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(true);
                            GameObject.Find("TextGUIChar").GetComponent<Image>().sprite = GUIImages[daughterTalkingScriptsID[countScripts[1]]];
                            displayText.text = daughterTalkingScripts[countScripts[1]];
                            countScripts[1]++;
                        }
                        else
                        {
                            countScripts[1] = splitDaughterTalkingScriptsID[index + 1] - 1;
                            //textBackground.gameObject.SetActive(false)
                            GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(false);
                            displayText.text = "";
                            button.GetComponent<Image>().sprite = button.GetComponent<InteractiveButton>().buttonImgs[0];
                            button.GetComponent<Image>().SetNativeSize();
                        }
                    }
                    break;
                case 2:

                    if (countScripts[2] < splitGrandSonScriptsID[index + 1])
                    {
                        //textBackground.gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(true);
                        displayText.text = grandSonScripts[countScripts[2]];
                        GameObject.Find("TextGUIChar").GetComponent<Image>().sprite = GUIImages[grandSonScriptsID[countScripts[2]]];
                        countScripts[2]++;
                    }
                    else
                    {
                        GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(false);
                        countScripts[2] = splitGrandSonScriptsID[index + 1] - 2;
                        //textBackground.gameObject.SetActive(false)
                        displayText.text = "";
                        button.GetComponent<Image>().sprite = button.GetComponent<InteractiveButton>().buttonImgs[0];
                        button.GetComponent<Image>().SetNativeSize();
                        Invoke("FadeIn", 1f);
                        Invoke("LoadCardGameScene", 2f);
                    }
                    break;
            }
        }
        else
        {
            if (tutorialIndex < tutorialScripts.Length)
            {
                //textBackground.gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(true);
                GameObject.Find("TextGUIChar").GetComponent<Image>().sprite = GUIImages[2];
                displayText.text = tutorialScripts[tutorialIndex];
                tutorialIndex++;
            }
            else
            {
                GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(false);
                //textBackground.gameObject.SetActive(false)
                displayText.text = "";
                button.GetComponent<Image>().sprite = button.GetComponent<InteractiveButton>().buttonImgs[0];
                button.GetComponent<Image>().SetNativeSize();
                GameManager.isDoneTutorial = true;
            }

        }
        isMovable = true;
    }

    public void Event()
    {
        if(countScripts[0] == 3)
        {
            //Invoke("LoadWalkingScene",2f);
        }
        if(countScripts[2] == 8)
        {
            //Invoke("LoadCardGameScene", 2f);
        }

    }

    public void GoToBed()
    {
        gameManager.CheckAchivement();
    }

    public void TakeShower()
    {
        gameManager.CheckTakeShower();
        isAnswerSon = false;
    }


    public void LoadWalkingScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NextScene");
    }
    
    public void LoadCardGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CameraScene");
    }

    void FadeIn()
    {
        gameManager.FadeIn();

    }

}

