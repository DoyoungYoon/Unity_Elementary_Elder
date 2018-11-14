using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pedometer : MonoBehaviour
{
    public Color color = Color.white;
    float soTime = 0f;
    public int rotateInt = 0;
    public float speed = 1f;

    public int finishPedometer = 15;

    public GameObject GameClear = null;
    public int gameClearInt = 0;
    public GameObject SpWell = null;
    Vector3 vAfterAccel = Vector3.zero;
    Vector3 vBeforeAccel = Vector3.zero;



    public float fLimit = 1.0f;
    float fDis = 0.0f;
    float fTime = 0.0f;
    int eventActive = 0;

    public int eventCount = 0;

    public Text TDistance = null;
    public Text TEvent = null;

    public float fNonMoveTime = 0.5f;
    public Vector3 velocity = Vector3.zero;

    void Start()
    {
        Invoke("PedometerRepeat", 0.1f);
        Invoke("PedometerEvent", 0.1f);
        color.a=0;

    }

    void PedometerCheck()
    {

        fDis = Vector3.Distance(vAfterAccel, vBeforeAccel);
        
        if (fDis > fLimit)
        {
            eventActive++;
        }
        vBeforeAccel = vAfterAccel;
    }

    void PedometerRepeat()
    {
        // 만보기
        vAfterAccel = (vAfterAccel - Input.acceleration) * 0.5f;
        fTime += Time.deltaTime;
        if (fTime > 0.2f)
        {
            PedometerCheck();
            fTime = 0.0f;
        }
    }

    void PedometerEvent()
    {
        // 만보기 이벤트 활성화
        if (eventActive >= 1)
        {
             fNonMoveTime += Time.deltaTime;
            if (fNonMoveTime > 0.42f)
            {
                eventCount++;
                if (rotateInt<3)rotateInt++;
                TEvent.text = eventCount.ToString();
                eventActive = 0;
                fNonMoveTime = 0f;
                if (eventCount>= finishPedometer)
                {
                    GameClear.SetActive(true);
                }
            }
        }
    }
    public void SceneChange()
    {
        GameManager.convertMinute += 60;
        GameManager.achivement += 5;
        UnityEngine.SceneManagement.SceneManager.LoadScene("mainScene");
    }
    private void Update()
    {
        Invoke("PedometerRepeat", 0.1f);
        Invoke("PedometerEvent", 0.1f);
        soTime += Time.deltaTime;
        SpWell.transform.Rotate(0, 0, rotateInt );
        if (soTime >= 1.0f && rotateInt > 0)
        {
            rotateInt--;
            soTime = 0f;
        }

      
    }
}
