using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab01 : MonoBehaviour
{
    public GameObject golfHat;
    public GameObject stethescope;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueVariables.Instance.tryGetValue("talkingAboutBody") > 0)
        {
            golfHat.SetActive(false);
            stethescope.SetActive(true);
        }
        else
        {
            golfHat.SetActive(true);
            stethescope.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            print("here");
            dialogueVariables.Instance.printAll();
        }
    }
}
