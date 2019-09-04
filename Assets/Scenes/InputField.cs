using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FRTScreen.ParticipantID = int.Parse(text.text);
            Debug.Log(text.text);
            Destroy(this.gameObject);
        }
        
    }
}
