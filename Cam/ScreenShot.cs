using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
    public Camera camera;       //보여지는 카메라.

    public Text Timer = null;

    int BlockDown = 0;
    int BlockUp = 0;
     public int clearStack = 0;

    private int resWidth;
    private int resHeight;

    public GameObject InputTextPop = null;
    public InputField InputText = null;
    public GameObject TextPop = null;

    public List<RectTransform> HoldPosition = new List<RectTransform> () ;
    public List<Image> ImageList= new List<Image> () ;
    public List<Text> TextList = new List<Text>();
    public List<GameObject> GameObjectList = new List<GameObject>();
    public List<GameObject> BlockObjectList = new List<GameObject>();

    public GameObject GameClear = null;
    public GameObject GameOver = null;

    public int GameStartT = 0;

    public float limitTime = 0f;

    int ranInt = 0;


    public Image capture0 = null;
    public Image capture1 = null;
    public Image capture2 = null;
    public Image capture3 = null;
    public Image capture4 = null;
    public Image capture5 = null;


    public GameObject CameraCube = null;
    public GameObject startButten = null;
    public GameObject Table = null;


    public int captureCount = 0;

    public int offCount = 0;

    // Use this for initialization
    void Start()
    { 

        HoldPosition[0].localPosition = new Vector3(-1000, 320, 0);
        HoldPosition[1].localPosition = new Vector3(-500, 320, 0);
        HoldPosition[2].localPosition = new Vector3(0, 320, 0);
        HoldPosition[3].localPosition = new Vector3(500, 320, 0);
        HoldPosition[4].localPosition = new Vector3(1000, 320, 0);
        HoldPosition[5].localPosition = new Vector3(-1000, -320, 0);
        HoldPosition[6].localPosition = new Vector3(-500, -320, 0);
        HoldPosition[7].localPosition = new Vector3(0, -320, 0);
        HoldPosition[8].localPosition = new Vector3(500, -320, 0);
        HoldPosition[9].localPosition = new Vector3(1000, -320, 0);
        HoldPosition[10].localPosition = new Vector3(940, 260, 0);
        HoldPosition[11].localPosition = new Vector3(970, 290, 0);
        HoldPosition[12].localPosition = new Vector3(1000, 320, 0);
        HoldPosition[13].localPosition = new Vector3(1030, 350, 0);
        HoldPosition[14].localPosition = new Vector3(1060, 380, 0);



        ImageList[0].rectTransform.localPosition = HoldPosition[10].localPosition;
        ImageList[1].rectTransform.localPosition = HoldPosition[11].localPosition;
        ImageList[2].rectTransform.localPosition = HoldPosition[12].localPosition;
        ImageList[3].rectTransform.localPosition = HoldPosition[13].localPosition;
        ImageList[4].rectTransform.localPosition = HoldPosition[14].localPosition;

        for (int i = 0; i < 10; i++)
        {
            BlockObjectList[i].SetActive(false);
        }

        resWidth = Screen.width;
        resHeight = Screen.height;
        
    }
    public void ClickScreenShot()
    {
        if (InputTextPop.activeSelf == true || TextPop.activeSelf == true|| captureCount >= 5)
        {
            return;
        }
        RenderTexture originTargetTexture = camera.targetTexture;
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;

        Texture2D screenShot = new Texture2D(resWidth - 700, resHeight-360, TextureFormat.RGB24, false);

        camera.Render();

        RenderTexture.active = rt;

        screenShot.ReadPixels(new Rect(80, 180, resWidth , resHeight ), 0, 0);
        screenShot.Apply();

        Sprite captureSprite = Sprite.Create(screenShot, new Rect(0.0f, 0.0f, screenShot.width, screenShot.height), new Vector2(0.5f, 0.5f));

       

        camera.targetTexture = originTargetTexture;
        InputTextPop.SetActive(true);
        capture1.sprite = captureSprite;

    }
    public void CaptureText()
    {
        if (InputText.text == capture2.name || InputText.text == capture3.name || InputText.text == capture4.name || InputText.text == capture5.name)
        {
            TextPop.SetActive(true);
            InputTextPop.SetActive(false);

        }
        else
        {
            captureCount++;
            capture1.name = InputText.text;
            InputText.text = null;
            InputTextPop.SetActive(false);
            SwapImage();
            if (captureCount >= 5) StartCoroutine("CardGame");



        }
    }
    IEnumerator CardGame()
    {
        startButten.SetActive(false);
        CameraCube.SetActive(false);
        Table.SetActive(true);
        TextList[0].text = ImageList[0].name;
        TextList[1].text = ImageList[1].name;
        TextList[2].text = ImageList[2].name;
        TextList[3].text = ImageList[3].name;
        TextList[4].text = ImageList[4].name;

        TextList[0].gameObject.SetActive(true);
        TextList[1].gameObject.SetActive(true);
        TextList[2].gameObject.SetActive(true);
        TextList[3].gameObject.SetActive(true);
        TextList[4].gameObject.SetActive(true);
        SwapImage();
        for(int i=0;i<20;i++)
        {

            int rand2 = Random.Range(0, 10);
            int rand1 = Random.Range(0, 10);
            RectTransform corona = HoldPosition[rand2];
            HoldPosition[rand2] = HoldPosition[rand1];
            HoldPosition[rand1] = corona;
        }


        ImageList[0].rectTransform.position = HoldPosition[0].position;
        ImageList[1].rectTransform.position = HoldPosition[1].position;
        ImageList[2].rectTransform.position = HoldPosition[2].position;
        ImageList[3].rectTransform.position = HoldPosition[3].position;
        ImageList[4].rectTransform.position = HoldPosition[4].position;
        TextList[0].rectTransform.position = HoldPosition[5].position;
        TextList[1].rectTransform.position = HoldPosition[6].position;
        TextList[2].rectTransform.position = HoldPosition[7].position;
        TextList[3].rectTransform.position = HoldPosition[8].position;
        TextList[4].rectTransform.position = HoldPosition[9].position;

        yield return new WaitForSeconds(3.2f);
        BlockDown += 1;
        GameStartT++;
        
        for (int i = 0; i < 10; i++)
        {
            BlockObjectList[i].SetActive(true);
        }
    }
    public void OK()
    {
        TextPop.SetActive(false);
        InputTextPop.SetActive(true);
    }
    void SwapImage()
    {
        capture0.sprite = capture1.sprite;
        capture0.name = capture1.name;
        capture1.sprite = capture2.sprite;
        capture1.name = capture2.name;
        capture2.sprite = capture3.sprite;
        capture2.name = capture3.name;
        capture3.sprite = capture4.sprite;
        capture3.name = capture4.name;
        capture4.sprite = capture5.sprite;
        capture4.name = capture5.name;
        capture5.sprite = capture0.sprite;
        capture5.name = capture0.name;       
    }
    
    public IEnumerator failCard()
    {
        yield return new WaitForSeconds(0.6f);
        for (int i = 0; i < 10; i++)
        {
            BlockObjectList[i].SetActive(true);
        }
        offCount = 0;

    }

    public void Capture1Off()
    {
        ImageList[0].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 6)
            {
                ImageList[0].gameObject.SetActive(false);
                TextList[0].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 6)
            {
                //  GameObjectList[offCount].GetComponentInChildren<Button>().gameObject.SetActive(true);
                //  ImageList[0].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 1;
    }
    public void Capture2Off()
    {
        ImageList[1].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 7)
            {
                ImageList[1].gameObject.SetActive(false);
                TextList[1].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 7)
            {
                //  GameObjectList[offCount ].GetComponentInChildren<Button>().gameObject.SetActive(true);
                //  ImageList[1].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 2;
    }
    public void Capture3Off()
    {
        ImageList[2].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 8)
            {
                ImageList[2].gameObject.SetActive(false);
                TextList[2].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 8)
            {
                //  GameObjectList[offCount ].GetComponentInChildren<Button>().gameObject.SetActive(true);
                //  ImageList[2].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 3;
    }
    public void Capture4Off()
    {
        ImageList[3].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 9)
            {
                ImageList[3].gameObject.SetActive(false);
                TextList[3].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 9)
            {
                // GameObjectList[offCount ].GetComponentInChildren<Button>().gameObject.SetActive(true);
                // ImageList[3].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 4;
    }
    public void Capture5Off()
    {
        ImageList[4].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 10)
            {
                ImageList[4].gameObject.SetActive(false);
                TextList[4].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 10)
            {
                //  GameObjectList[offCount].GetComponentInChildren<Button>().gameObject.SetActive(true);
                //ImageList[4].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 5;
    }
    public void CaptureText1Off()
    {
        TextList[0].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 1)
            {
                ImageList[0].gameObject.SetActive(false);
                TextList[0].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 1)
            {
                // GameObjectList[offCount].GetComponentInChildren<Button>().gameObject.SetActive(true);
                // TextList[0].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 6;
    }
    public void CaptureText2Off()
    {
        TextList[1].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 2)
            {
                ImageList[1].gameObject.SetActive(false);
                TextList[1].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount !=2)
            {
                // GameObjectList[offCount ].GetComponentInChildren<Button>().gameObject.SetActive(true);
                //TextList[1].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 7;
    }
    public void CaptureText3Off()
    {
        TextList[2].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount ==3)
            {
                ImageList[2].gameObject.SetActive(false);
                TextList[2].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 3)
            {
                //GameObjectList[offCount ].GetComponentInChildren<Button>().gameObject.SetActive(true);
                // TextList[2].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 8;
    }
    public void CaptureText4Off()
    {
        TextList[3].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 4)
            {
                ImageList[3].gameObject.SetActive(false);
                TextList[3].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 4)
            {
                //GameObjectList[offCount].GetComponentInChildren<Button>().gameObject.SetActive(true);
                //TextList[3].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");

            }

        }
        else offCount = 9;
    }
    public void CaptureText5Off()
    {
        TextList[4].GetComponentInChildren<Button>().gameObject.SetActive(false);
        if (offCount != 0)
        {
            if (offCount == 5)
            {
                ImageList[4].gameObject.SetActive(false);
                TextList[4].gameObject.SetActive(false);
                offCount = 0;
                clearStack++;

            }
            else if (offCount != 5)
            {
                // GameObjectList[offCount ].GetComponentInChildren<Button>().gameObject.SetActive(true);
                // TextList[4].GetComponentInChildren<Button>().gameObject.SetActive(true);
                StartCoroutine("failCard");
            }

        }
        else offCount = 10;
    }

    public void GameOverBut()
    {
        
        if(GameManager.achivement>0) GameManager.achivement -= 10;
        GameManager.convertMinute += 30;

        UnityEngine.SceneManagement.SceneManager.LoadScene("mainScene");
    }

    public void GameClearBut()
    {
        GameManager.achivement += 5;
        GameManager.convertMinute += 30;

        UnityEngine.SceneManagement.SceneManager.LoadScene("mainScene");
    }

    private void Update()
    {
     
        if (GameStartT > 0)
        {
            limitTime += Time.deltaTime;
            Timer.text = limitTime.ToString();
            if (limitTime > 20f)
            {
                GameOver.SetActive(true);
            }
        }
        if (clearStack >= 5 && GameOver.activeSelf != true)
        {
            Debug.Log("FF");
            GameClear.SetActive(true);
        }
        if (BlockDown > 0)
        {
            transform.Rotate(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - Time.deltaTime, transform.rotation.eulerAngles.z);
        }
        if (transform.rotation.eulerAngles.y - Time.deltaTime <= 0) BlockDown = 0;

        if (BlockUp > 0)
        {
            transform.Rotate(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Time.deltaTime, transform.rotation.eulerAngles.z);
        }
        if (transform.rotation.eulerAngles.y - Time.deltaTime >= 90) BlockUp = 0;
    }
}
