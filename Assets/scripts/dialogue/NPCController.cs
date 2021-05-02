using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;


public class NPCController : MonoBehaviour
{
    public float rotateTime = 2f;
    private float currentTime = 0f;
    public float conversationBuffer = 5f;


    public GameObject displayCanvas;
    private bool inBox = false;
    public bool canRotate = false;

    [Header("left, down, right, up")]
    public List<int> forbiddenDirections = new List<int>();
    public string charName = "";
    public List<Sprite> upSprites = new List<Sprite>();
    public List<Sprite> downSprites = new List<Sprite>();
    public List<Sprite> leftSprites = new List<Sprite>();
    public List<Sprite> rightSprites = new List<Sprite>();
    private List<List<Sprite>> sprites = new List<List<Sprite>>();
    public bool onlyFromUpSprites = false;

    [Header("Dialogues")]
    public List<TextAsset> dialogues = new List<TextAsset>();
    public bool stayAtTop = false;
    private int i = -1;
    public bool canSpeak = true;
    public bool containsPrivateSpace;

    //private space copy pasted code
    public GameObject speechBubble = null;
    public float fadeTime = 1f;
    private List<string> currentLines = new List<string>();
    private Image picture;
    private Text speechText;
    private bool fadeIn = false;

    //to prevent things breaking
    private static GameObject placeholderSpeechBubble;
    private static NPCController goodBoy = null;
    private static List<GameObject> badAndNaughtyObjects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

        sprites.Add(leftSprites);
        sprites.Add(downSprites);
        sprites.Add(rightSprites);
        sprites.Add(upSprites);
        List<int> validDirections = new List<int>();
        foreach (int i in forbiddenDirections)
        {
            if (new List<int> { 0, 1, 2, 3 }.Contains(i) == true)
            {
                validDirections.Add(i);
            }
        }
        forbiddenDirections = validDirections;
        if (canRotate)
        {
            rotate();
        }
        /*
        
        if (speechBubble != null && speechBubble.transform.root.gameObject == transform.root.gameObject)
        {
            placeholderSpeechBubble = speechBubble;
            goodBoy = this;
            foreach (GameObject go in badAndNaughtyObjects)
            {
                if (go != null)
                {
                    go.GetComponent<NPCController>().speechBubble = this.speechBubble;
                    go.GetComponent<NPCController>().Start();
                }
            }
            badAndNaughtyObjects = new List<GameObject>();
        }
        else if (speechBubble == null)
        {
            speechBubble = placeholderSpeechBubble;
            badAndNaughtyObjects.Add(this.gameObject);
            if (goodBoy != null) { goodBoy.Start();}
            else { return;}
            
        }
        if (speechBubble.transform.root == transform.root || speechBubble.GetComponent<Canvas>().worldCamera == null)
        {
            speechBubble.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            picture = speechBubble.GetComponentInChildren<Image>();
            speechText = speechBubble.GetComponentInChildren<Text>();
            picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 0f);
        }
       
        
        

        sprites.Add(leftSprites);
        sprites.Add(downSprites);
        sprites.Add(rightSprites);
        sprites.Add(upSprites);
        List<int> validDirections = new List<int>();
        foreach (int i in forbiddenDirections)
        {
            if (new List<int>{ 0, 1, 2, 3 }.Contains(i) == true)
            {
                validDirections.Add(i);
            }
        }
        forbiddenDirections = validDirections;
        if (canRotate)
        {
            rotate();
        }
           */
        
    }

    private TextAsset getNextAsset()
    {
        i++;
        if (i >= dialogues.Count)
        {
            if (stayAtTop)
            {
                i = dialogues.Count - 1;
            }
            else
            {
                i = 0;
            }
        }

        return dialogues[i];
    }

    private string getLine(TextAsset nextLine)
    {
        string s = "";
        if (nextLine.text.Contains('{'.ToString()) == false)
        {
            List<string> lines = nextLine.text.Split('\n').ToList();
            string line = lines[UnityEngine.Random.Range(0, lines.Count)];
            s = line;
        }
        return s;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        //only rotates if the player is not in the box
        if (canRotate && currentTime >= rotateTime && (inBox == false || canSpeak))
        {
            currentTime = 0f;
            currentTime += UnityEngine.Random.Range(-0.2f, 0.2f);
            rotate();
        }
        //gameManager.Instance.Start();
        if (inBox == true && Input.GetKeyDown(gameManager.inputValues["interact"]) && canSpeak)
        {
            TextAsset nextText = getNextAsset();
            if ((crimeScene01.exists || barSceneManager.exists) && nextText.text.Contains('{'.ToString()))
            {
                crimeScene01.OpenDialogue(nextText);
            }
            
            else if (picture != null && nextText.text.Contains('{'.ToString()) == false && speechBubble.transform.root == transform.root)
            {
                speechBubble.SetActive(true);
                fadeIn = true;
                if (picture.color.a <= 0)
                {
                    speechBubble.GetComponentInChildren<Text>().text = getLine(nextText);
                }
                fadeIn = true;
            }
           
            else
            {
                dialogue.Instance.openDialogue();
            }
            
            
        }
        /*
        if (speechBubble != null && speechBubble.transform.root == transform.root)
        {
            try
            {
                if (fadeIn == false)
                    {
                        picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, picture.color.a - Time.deltaTime / fadeTime);
                        speechText.color = new Color(0f, 0f, 0f, speechText.color.a - Time.deltaTime / fadeTime);
                    }
                    if (fadeIn == true)
                    {
                        picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 1f);
                        speechText.color = new Color(0f, 0f, 0f, 1f);
                    }
                    if (picture.color.a < 0)
                    {
                        picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 0f);
                    }
            }
            catch (NullReferenceException e) { }
           
        }*/


    }
    void rotate()
    {
        int i = 0;
               while (true)
        {
            i = UnityEngine.Random.Range(0, 4);
            if (onlyFromUpSprites)
            {
                i = UnityEngine.Random.Range(0, upSprites.Count);
            }
            if (forbiddenDirections.Contains(i) == false || forbiddenDirections.Count >= 4)
            {
                break;
            }
            
        }

        Vector3 oldAngle = gameObject.transform.eulerAngles;
        Sprite oldSprite = gameObject.transform.root.gameObject.GetComponent<SpriteRenderer>().sprite;
        try
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, i * 90);
            if (sprites.Count > i)
            {
                gameObject.transform.root.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i][0];
            }
            if (onlyFromUpSprites)
            {
                gameObject.transform.root.gameObject.GetComponent<SpriteRenderer>().sprite = upSprites[i];
            }
        }
        catch (ArgumentOutOfRangeException e)
        {
            gameObject.transform.eulerAngles = oldAngle;
            gameObject.transform.root.gameObject.GetComponent<SpriteRenderer>().sprite = oldSprite;
            throw e;
        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        displayCanvas.SetActive(true);
        inBox = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        fadeIn = false;
        displayCanvas.SetActive(false);
        inBox = false;
    }

}
