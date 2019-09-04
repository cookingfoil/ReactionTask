using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class ReactionTask : MonoBehaviour
{
    public GameObject text1;
    //public GameObject text2;
    //public GameObject text3;
    //public GameObject text4;
    public GameObject startmessage;
    public GameObject taskcounter;
    public GameObject keyB;

    string path = @"C:\Users\IMLAB\Desktop\data_reaction\" + FRTScreen.ParticipantID + "_" + "data.txt";
    //string path = Path.Combine(Application.persistentDataPath, "data.txt");

    //bool ClickSuccess;

    float taskTime;
    float timer;
    float intervalTime;
    int currentBox;
    int taskcount;

    //public void FirstTaskSet()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        NextTaskSet();
    //    }
    //}


    public void NextTaskSet()
    {
        text1.gameObject.SetActive(false);
        //text2.gameObject.SetActive(false);
        //text3.gameObject.SetActive(false);
        //text4.gameObject.SetActive(false);

        timer = 0;

        //currentBox = UnityEngine.Random.Range(1, 1);
        currentBox = 1;
        intervalTime = UnityEngine.Random.Range(2.0f, 5.0f); //change the interval time range here

        Debug.Log("currentBox: " + currentBox);
        Debug.Log("intervalTime: " + intervalTime);
    }

    public void DataLogging()
    {
        if (currentBox == 1 && timer > intervalTime && Input.GetKeyDown("b"))
            //currentBox == 2 && timer > intervalTime && Input.GetKeyDown("c") ||
            //currentBox == 3 && timer > intervalTime && Input.GetKeyDown("b") ||
            //currentBox == 2 && timer > intervalTime && Input.GetKeyDown("n"))
        {
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    string createText =
            //        currentBox + "_" +
            //        intervalTime + "_" +
            //        timer + "_" +
            //        "Success" + "_" +
            //        Environment.NewLine;
            //    File.WriteAllText(path, createText);
            //}

            string appendText =
                    currentBox + "_" +
                    intervalTime + "_" +
                    timer + "_" +
                    "Success" + "_" +
                    Environment.NewLine;
            File.AppendAllText(path, appendText);
            taskcount += 1;
        }

        else if (Input.GetKeyDown("space"))
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText =
                    currentBox + "_" +
                    intervalTime + "_" +
                    timer + "_" +
                    "Task is Started" + "_" +
                    Environment.NewLine;
                File.WriteAllText(path, createText);
                taskcount += 1;
            }

        }
        else
        {
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    string createText =
            //        currentBox + "_" +
            //        intervalTime + "_" +
            //        timer + "_" +
            //        "Fail" + "_" +
            //        Environment.NewLine;
            //    File.WriteAllText(path, createText);
            //}

            string appendText =
                    currentBox + "_" +
                    intervalTime + "_" +
                    timer + "_" +
                    "Fail" + "_" +
                    Environment.NewLine;
            File.AppendAllText(path, appendText);
            taskcount += 1;
        }
    }

    //void MyAction()
    //{
    //    Debug.Log("Press Key");

    //}
    // Start is called before the first frame update
    void Start()
    {
        text1.gameObject.SetActive(false);
        //text2.gameObject.SetActive(false);
        //text3.gameObject.SetActive(false);
        //text4.gameObject.SetActive(false);
        timer = 0;
        taskcount = 0;

        Debug.Log(Application.persistentDataPath);

        //FirstTaskSet();

        //Add a listener to the new Event. Calls MyAction method when invoked
        //m_MyEvent.AddListener(MyAction);

    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("timer: " + timer);
        taskTime = Time.realtimeSinceStartup;
        Debug.Log("globaltime: " + taskTime);
        startmessage.GetComponent<Text>().text = "Press space to start ";
        taskcounter.GetComponent<Text>().text = "Task: " + taskcount;

        if (Input.GetKeyDown("space"))
        {
            startmessage.gameObject.SetActive(false);
            keyB.gameObject.SetActive(false);
            NextTaskSet();
            taskcount = 0;
        }


        if (currentBox == 1 && timer > intervalTime)
        {
            text1.gameObject.SetActive(true);
        }
        //else if (currentBox == 2 && timer > intervalTime)
        //{
        //    text2.gameObject.SetActive(true);
        //}
        //else if (currentBox == 3 && timer > intervalTime)
        //{
        //    text3.gameObject.SetActive(true);
        //}
        //else if (currentBox == 4 && timer > intervalTime)
        //{
        //    text4.gameObject.SetActive(true);
        //}


        if (Input.anyKeyDown)
        {
            Debug.Log("KeyPressed!!!!!!!!!");
            DataLogging();
            NextTaskSet();
        }

        if (taskcount == 31)
        {
            SceneManager.LoadScene("MainScreen");
        }
    }
}
