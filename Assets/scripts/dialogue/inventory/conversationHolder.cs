using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class conversationHolder : MonoBehaviour
{
    [Header("Button Variables")]
    public string openText = "Conversations";
    public string closedText = "Close";
    public Sprite tapeRecorder;
    public Sprite redX;
    private Text buttonText;
    private bool isOpen = false;
    private Image buttonImage;
    private Vector3 openPos = new Vector3(244.5f, 300.5f, 0.0f);
    private Vector3 closedPos = new Vector3(157.4f, 354.7f, 0.0f);



    private GameObject background;
    private Text conversationText;
    private Dictionary<string, string> conversations = new Dictionary<string, string>();
    [Header("Background Variables")]
    [SerializeField]
    private GameObject baseButton = null;
    [SerializeField]
    private Transform content = null;
    public GameObject button;


    private static conversationHolder instance;
    public static conversationHolder Instance {
        get {
            if (instance == null && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "office01")
            { GameObject.Find("Conversations").GetComponent<conversationHolder>().Awake();}
            return instance;
            }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //throws an exception if the baseButton has not been assigned
        if (baseButton == null) { throw new UnityException("base button has not been assigned"); }

        //assigns some local variables by finding them in the transform
        buttonText = transform.Find("button").GetComponentInChildren<Text>();
        buttonImage = transform.Find("button").GetComponent<Image>();
        background = transform.Find("background").gameObject;
        conversationText = transform.Find("background").Find("textScroll").gameObject.GetComponentInChildren<Text>();
        conversationText.text = "";

        //starts it by closing everything
        setClosed();
        isOpen = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (dialogue.isOpen)
            {
                button.SetActive(false);
            }
            else
            {
                button.SetActive(true);
            }
        }
        catch (UnassignedReferenceException e)
        {
            button = instance.gameObject.transform.Find("button").gameObject;
        }
        
    }
    public void setClosed()
    {
        //sets all variables to their closed states
        buttonImage.sprite = tapeRecorder;
        buttonText.text = openText;
        buttonText.gameObject.transform.position = openPos;
        background.SetActive(false);
    }
    private void setOpen()
    {
        //sets all variables to their open states
        buttonImage.sprite = redX;
        buttonText.text = closedText;
        buttonText.gameObject.transform.position = closedPos;
        background.SetActive(true);
    }
    Vector2 getHeight(int lines)
    {
        //dynamically creates a vector2 to set the height of the text rectangle, based on the number of lines
        RectTransform text = conversationText.gameObject.GetComponent<RectTransform>();
        float width = text.rect.width;
        if (lines <= 8)
        {
            return new Vector2(width, 320f);
        }
        return new Vector2(width, lines * 26f);
        
    }

    public void setText()
    {
        //gets the last button clicked from the unity event system
        GameObject currentButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.gameObject;

        //gets the current conversation from the dictionary, then sets the display text to that
        string currentConversation = conversations[currentButton.GetComponentInChildren<Text>().text];
        conversationText.text = currentConversation;

        //sets the height of the display box to be proportionate to the number of lines
        int numLines = currentConversation.Length - currentConversation.Replace('\n'.ToString(), "").Length + 1;
        RectTransform text = conversationText.gameObject.GetComponent<RectTransform>();
        text.sizeDelta = getHeight(numLines);
        text.gameObject.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = getHeight(numLines);
    }

    public void createButton(string name, string text = "")
    {
        //instantiates a new button and places it in the canvas
        
        if (conversations.ContainsKey(name))
        {
            conversations[name] += "\n\n\n" + text;
        }
        else
        {
            try
            {
                GameObject newButton = Instantiate(baseButton, content);
                newButton.SetActive(true);
                newButton.GetComponentInChildren<Text>().text = name;
                conversations.Add(name, text);
            }
            catch(MissingReferenceException e)
            {
                print(baseButton);
                print(content);
               
            }
        }
    }

    public void toggleScreen()
    {
        inventoryManager.Instance.setClosed();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "crimeScene01")
        {
            map.SetClosed();
        }
        //flips the value of isOpen
        isOpen = !isOpen;
        if (isOpen)
        {
            setOpen();
        }
        else
        {
            setClosed();
        }
        
        
    }
    public static void turnOff()
    {

    }
}
