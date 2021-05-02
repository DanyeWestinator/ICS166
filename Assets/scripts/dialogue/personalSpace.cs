 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class personalSpace : MonoBehaviour
{
    //speech bubble is the canvas
    public GameObject speechBubble;


    private Image picture;
    private Text speechText;
    public TextAsset lines;

    private List<string> linesList;
    private bool fadeIn = false;

    public float fadeTime = 1f;
    public bool OnInteract = false;
    private bool inBox = false;
    // Start is called before the first frame update
    void Start()
    {
        if (speechBubble.GetComponent<Canvas>().worldCamera == null)
        {
            speechBubble.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
        
        linesList = lines.text.Split('\n').ToList();
        picture = speechBubble.GetComponentInChildren<Image>();
        speechText = speechBubble.GetComponentInChildren<Text>();
        picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 0f);
        speechBubble.GetComponentInChildren<Text>().text = getLine();
    }

    string getLine()
    {
        int i = UnityEngine.Random.Range(0, linesList.Count);
        return linesList[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (inBox && Input.GetKeyDown(gameManager.inputValues["interact"]))
        {
            speechBubble.SetActive(true);
            fadeIn = true;
            if (picture.color.a <= 0)
            {
                speechBubble.GetComponentInChildren<Text>().text = getLine();
            }
            fadeIn = true;
        }
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && OnInteract == false)
        {
            speechBubble.SetActive(true);
            fadeIn = true;
            if (picture.color.a <= 0)
            {
                speechBubble.GetComponentInChildren<Text>().text = getLine();
            }
        }
        if (collision.tag == "Player" && OnInteract)
        {
            inBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inBox = false;
            fadeIn = false;
        }
    }
    
}
