using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {

    public GameObject displayScript;
    public int id;
    public string[] fulltext;
    public int dialog_cnt;

    public Transform[] Paths;
    public Transform[] RunAwayPaths;
    private NavMeshAgent _nav;
    public float acceptDistance;
    private int targetPathID;
    public bool isRunAway;
    /*
    public NavMeshAgent nav
    {
        get { return _nav; }
        //set { _nav = value; } 
    }

    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        targetPathID = 0;
        if (Paths[targetPathID] != null)
        {
            _nav.SetDestination(Paths[targetPathID].position);
        }
        StartCoroutine("GoToPoint");
    }

    private void OnEnable()
    {
        _nav = GetComponent<NavMeshAgent>();
        targetPathID = 0;
        if (Paths[targetPathID] != null)
        {
            _nav.SetDestination(Paths[targetPathID].position);
        }
        StartCoroutine("GoToPoint");
    }

    IEnumerator GoToPoint()
    {
        while (true)
        {
            if (Paths[targetPathID] != null)
            {
                if (Vector3.Distance(transform.position, _nav.destination) < acceptDistance)
                {
                    targetPathID++;
                    //print (targetPathID); 
                    if (targetPathID >= Paths.Length)
                    {
                        targetPathID = 0;
                    }

                    _nav.SetDestination(Paths[targetPathID].position);
                    if (isRunAway)
                    {
                        if (Vector3.Distance(transform.position, RunAwayPaths[RunAwayPaths.Length - 1].transform.position) <= acceptDistance)
                        {
                            Destroy(this.gameObject);
                        }
                        Destroy(this.gameObject, 30f);
                    }
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void SetRunAwayPaths()
    {
        for (int i = 0; i < RunAwayPaths.Length; i++)
        {
            Paths[i] = RunAwayPaths[i];
            isRunAway = true;
        }

    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            /*
            displayScript.GetComponent<TypeWriterEffect>().fulltext = fulltext;
            displayScript.GetComponent<TypeWriterEffect>().dialog_cnt = fulltext.Length;
            */
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        /*
        if (col.gameObject.tag == "Player")
        {
            if (displayScript.GetComponent<TypeWriterEffect>().text_start && !displayScript.GetComponent<TypeWriterEffect>().isTextTyping)
            {
                displayScript.GetComponent<TypeWriterEffect>().Get_Typing(dialog_cnt, fulltext);
                print("시작!");
            }

        }
        */

    }





}
