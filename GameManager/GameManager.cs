using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static bool isDoneTutorial;
    public GameObject clock;
    public GameObject dayText;
    public GameObject achivementPoint;
    public GameObject player;
    public SceneLoader fade;
    public Transform getUpPosition;
    Meal newMeal;
    public static int achivement=0;
    public static int day=1;
    public Meal meal;
    public int[] mealTimes;
    public Transform mealPosition;
    public int relaxedTimer;

    public bool isSuccessEatMeal;
    public bool isMealStart;
    bool isTimerStart;

    public int mealPoint;

    int hour;
    int minute;
    public static int convertMinute = 840;
    float time;
    int timerTime;
    string amOrPM;
    string strHour;
    string strMinute;
    string strClock;

    void Start () {
        time = 0;
        timerTime = 0;
        UpdateInform();

    }

    void Update () {
        DisplayClock();
        if (CompareTime())
        {
            timerTime = convertMinute;
            isTimerStart = true;
        }
        if (isTimerStart)
        {
            
            Timer(relaxedTimer, isSuccessEatMeal);
        }
    }

    void DisplayClock()
    {
        time += Time.deltaTime;
        if (time > 5f)
        {
            achivementPoint.GetComponent<Text>().text = achivement.ToString();

            convertMinute += 10;
            CheckAndSpawnMeal();
            CheckSleepTime();
            time = 0;
            hour = convertMinute / 60;
            minute = convertMinute % 60;
            if (hour / 12 == 0)
            {
                amOrPM = "AM";
            }
            else if (hour / 12 == 1)
            {
                amOrPM = "PM";
            }
            else if(hour/12 == 2)
            {
                day++;
                dayText.GetComponent<Text>().text = "Day " + day.ToString();
                convertMinute = 0 ;
                amOrPM = "AM"; 
            }
            if (hour < 10)
            {
                strHour = "0" + hour.ToString();
            }
            else
            {
                strHour = hour.ToString();
            }
            if (minute < 10)
            {
                strMinute = "0" + minute.ToString();
            }
            else
            {
                strMinute = minute.ToString();
            }
            strClock = amOrPM + " " + strHour + " : " + strMinute;

            clock.GetComponent<Text>().text = strClock;
        }
    }

    void CheckAndSpawnMeal()
    {
        for(int i = 0; i< mealTimes.Length; i++)
        {
            if (mealTimes[i] == convertMinute)
            {
                newMeal = Instantiate(meal, mealPosition) as Meal;
            }
        }
    }

    void CheckSleepTime()
    {
        if (convertMinute > 1320)
        {
            GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(true);
            GameObject.Find("ScriptText").GetComponent<Text>().text = "Whoaaaaaaam..";
            CheckAchivement();
            if(achivement>=10)
            {
                achivement -= 10;
            }
        }
    }

    public void GetAchivementMealPoint()
    {
        
        print(achivement);
        achivement += mealPoint;
        print(achivement);
        achivementPoint.GetComponent<Text>().text = achivement.ToString();
        
    }

    public bool Timer(float setTime, bool successFlag)
    {
        bool isSuccess;

        if (successFlag)
        {
            timerTime = 0;
            isSuccess = true;
            isTimerStart = false;
            return isSuccess;
        }

        if (convertMinute - timerTime > setTime )
        {
            timerTime = 0;
            isTimerStart = false;
            isSuccess = false;
            TimesUp();
            return isSuccess;
        }
        else
        {
            isSuccess = false;
            return isSuccess;
        }
                
    }

    public void TimesUp()
    {
        if (isMealStart)
        {
            isMealStart = false;
            if(achivement >= 10)
            {
                achivement -= 2;
            }
            achivementPoint.GetComponent<Text>().text = achivement.ToString();
            GameObject.Destroy(newMeal.gameObject);
        }

    }

    public bool CompareTime()
    {
        for(int i=0; i< mealTimes.Length; i++)
        {
            if (mealTimes[i] == convertMinute)
            {
                isMealStart = true;
                return true;
            }
        }
        return false;

    }
    
    public void CheckAchivement()
    {
        if(convertMinute > 600)
        {
            fade.StartFadeInWithoutLoadScene();
            Invoke("WaitCheckAchivement", 3f);

        }
    }
    public void WaitCheckAchivement()
    {
        if (achivement <= 10)
        {

            GameObject.Find("player").transform.Find("Player1").gameObject.SetActive(true);
            GameObject.Find("player").transform.Find("Player2").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player3").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player4").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player5").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player6").gameObject.SetActive(false);
            GameObject.Find("MainCamera").GetComponent<mainCamera>().target = GameObject.Find("Player1").gameObject.transform;

        }
        else if (achivement <= 20)
        {
            GameObject.Find("player").transform.Find("Player1").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player2").gameObject.SetActive(true);
            GameObject.Find("player").transform.Find("Player3").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player4").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player5").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player6").gameObject.SetActive(false);
            GameObject.Find("MainCamera").GetComponent<mainCamera>().target = GameObject.Find("Player2").gameObject.transform;
        }
        else if (achivement <= 40)
        {
            GameObject.Find("player").transform.Find("Player1").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player2").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player3").gameObject.SetActive(true);
            GameObject.Find("player").transform.Find("Player4").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player5").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player6").gameObject.SetActive(false);
            GameObject.Find("MainCamera").GetComponent<mainCamera>().target = GameObject.Find("Player3").gameObject.transform;
        }
        else if (achivement <= 60)
        {


            GameObject.Find("player").transform.Find("Player1").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player2").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player3").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player4").gameObject.SetActive(true);
            GameObject.Find("player").transform.Find("Player5").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player6").gameObject.SetActive(false);
            GameObject.Find("MainCamera").GetComponent<mainCamera>().target = GameObject.Find("Player4").gameObject.transform;


        }
        else if (achivement <= 80)
        {
            GameObject.Find("player").transform.Find("Player1").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player2").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player3").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player4").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player5").gameObject.SetActive(true);
            GameObject.Find("player").transform.Find("Player6").gameObject.SetActive(false);
            GameObject.Find("MainCamera").GetComponent<mainCamera>().target = GameObject.Find("Player5").gameObject.transform;

        }
        else if(achivement < 100)
        {
            GameObject.Find("player").transform.Find("Player1").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player2").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player3").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player4").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player5").gameObject.SetActive(false);
            GameObject.Find("player").transform.Find("Player6").gameObject.SetActive(true);
            GameObject.Find("MainCamera").GetComponent<mainCamera>().target = GameObject.Find("Player6").gameObject.transform;
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Ending");
        }
        GameObject.FindGameObjectWithTag("Player").transform.position = getUpPosition.position;
        day++;
        convertMinute = 420;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().isTakeShower = false;

        UpdateInform();
        GameObject.Find("Canvas").transform.Find("TextGUI").gameObject.SetActive(false);
        Invoke("FadeOut", 2f);
        
    }

    public void UpdateInform()
    {
        achivementPoint.GetComponent<Text>().text = achivement.ToString();
        dayText.GetComponent<Text>().text = "Day " + day.ToString();

        hour = convertMinute / 60;
        minute = convertMinute % 60;
        if (hour / 12 == 0)
        {
            amOrPM = "AM";
        }
        else if (hour / 12 == 1)
        {
            amOrPM = "PM";
        }
        else if (hour / 12 == 2)
        {
            day++;
            dayText.GetComponent<Text>().text = "Day " + day.ToString();
            convertMinute = 0;
            amOrPM = "AM";
        }
        if (hour < 10)
        {
            strHour = "0" + hour.ToString();
        }
        else
        {
            strHour = hour.ToString();
        }
        if (minute < 10)
        {
            strMinute = "0" + minute.ToString();
        }
        else
        {
            strMinute = minute.ToString();
        }
        strClock = amOrPM + " " + strHour + " : " + strMinute;

        clock.GetComponent<Text>().text = strClock;
    }



    
    public void CheckTakeShower()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().isTakeShower)
        {
            convertMinute += 30;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Char>().isTakeShower = true;
            fade.StartFadeInWithoutLoadScene();
            Invoke("ShowShowerImg", 2f);
        }
    }
    
    void ShowShowerImg()
    {
        GameObject.Find("Canvas").transform.Find("ShowerImg").gameObject.SetActive(true);
        Invoke("FadeOut", 3f);
    }

    void FadeOut()
    {
        fade.StartFadeOut();
        GameObject.Find("Canvas").transform.Find("ShowerImg").gameObject.SetActive(false);
    }
    public void FadeIn()
    {
        fade.StartFadeInWithoutLoadScene();
    }
}
