using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class barSceneManager : MonoBehaviour
{
    public BoxCollider2D doorBox;
    public static bool exists = false;
    private static barSceneManager instance = null;

    private static bool spokenToDoorman = false;

    public GameObject doorman;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            instance.doorBox = this.doorBox;
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        exists = true;
    }
    public static barSceneManager Instance { get { return instance; } }
    


    //the bools...they come in strength


    // Start is called before the first frame update
    void Start()
    {
        doorman = GameObject.Find("small penis Brian");

        if (ShouldOpen())
        {
            spokenToDoorman = true;
            doorBox = GameObject.Find("clutter/desk01").GetComponent<BoxCollider2D>();
            doorBox.size = new Vector2(0.33f, doorBox.size.y);
            doorBox.offset = new Vector2(0.07229517f, doorBox.offset.y);
        }
    }

    private static bool ShouldOpen(string youRang = "")
    {
        if (youRang != "")
        {
            print("being called by:\t" + youRang);
        }
        
        if (SceneManager.GetActiveScene().name != "barScene")
        {
            return false;
        }
        else if ((spokenToDoorman || dialogueVariables.Instance.tryGetValue("spokenToDoorman") > 0))
        {
            return true;
        }
        return false;
    }

    private void Open()
    {
        if (SceneManager.GetActiveScene().name != "barScene")
        {
            return;
        }
        doorman = GameObject.Find("small penis Brian");
        spokenToDoorman = true;
        int loops = 0;
        while (loops < doorman.transform.childCount)
        {
            Destroy(doorman.transform.GetChild(loops).gameObject);
            if (loops >= doorman.transform.childCount) { return; }
            loops++;
        }
        doorBox = GameObject.Find("clutter/desk01").GetComponent<BoxCollider2D>();
        doorBox.size = new Vector2(0.33f, doorBox.size.y);
        doorBox.offset = new Vector2(0.07229517f, doorBox.offset.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (doorman == null)
        {
            if (spokenToDoorman && ShouldOpen())
            {
                Open();
            }
            doorman = GameObject.Find("small penis Brian");
        }
        
        if ((dialogue.isOpen && spokenToDoorman == false))
        {
            spokenToDoorman = true;
            Open();
        }
    }
}
