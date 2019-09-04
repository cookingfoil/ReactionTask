using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    //public GameObject ReactionTask;
    //public GameObject twoChoiceReactionTask;
    //public GameObject fourChoiceReactionTask;

    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("ReactionTask");
    }

    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("2ChoiceReactionTask");
    }

    public void ChangeThirdeScene()
    {
        SceneManager.LoadScene("4ChoiceReactionTask");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    SceneManager.LoadScene("ReactionTask");
        //}
        
    }
}
