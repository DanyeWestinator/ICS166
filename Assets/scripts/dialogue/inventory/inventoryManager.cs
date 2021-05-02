using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct clueStruct
{
    /*
        newButton.GetComponent<clueButton>().clueName = clue.clueName;
        newButton.GetComponent<clueButton>().flavorText = clue.flavorText;
        newButton.GetComponentInChildren<Text>().text = clue.clueName;
        newButton.GetComponent<clueButton>().clueLocation = clue.originLocation;
        newButton.GetComponent<clueButton>().cluePath = clue.spriteName;
     */
    public clueStruct(string name, string flavor, string foundLocation, string spritePath)
    {
        clueName = name;
        flavorText = flavor;
        location = foundLocation;
        spriteName = spritePath;
    }
    public string clueName;
    public string flavorText;
    public string location;
    public string spriteName;
    

}


public class inventoryManager : MonoBehaviour
{
    public GameObject baseButton;
    public Transform clueListTransform;
    public GameObject notebookCanvas;
    public Sprite book;
    public Sprite x;
    public Image background;
    public GameObject singleItemCanvas;
    private GameObject currentClue;
    public Button notebookButton;

    private static List<GameObject> clues = new List<GameObject>();

    private static inventoryManager instance = null;

    public static inventoryManager Instance { get { return instance; } }



    private void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
    }

    public bool containsClue(string clueName)
    {
        foreach (Transform child in clueListTransform)
        {
            if (child.gameObject.name.StartsWith(clueName))
            {
                return true;
            }
        }
        return false;
    }

    public void createButton(GameObject go)
    {
        if (go.GetComponentInChildren<SpriteRenderer>() == null)
        {
            return;
        }
        currentClue = go;
        GameObject newButton = Instantiate(baseButton, clueListTransform);
        newButton.SetActive(true);
        newButton.GetComponent<Image>().sprite = go.GetComponentInChildren<SpriteRenderer>().sprite;
        clue clue = go.GetComponentInChildren<clue>();
        newButton.name = clue.clueName + "Clue";
        newButton.GetComponent<clueButton>().clueName = clue.clueName;
        newButton.GetComponent<clueButton>().flavorText = clue.flavorText;
        newButton.GetComponentInChildren<Text>().text = clue.clueName;
        newButton.GetComponent<clueButton>().clueLocation = clue.originLocation;
        newButton.GetComponent<clueButton>().cluePath = clue.spriteName;
        //newButton.GetComponentInChildren<Text>().text = 
    }
    private void createButtonFromStruct(clueStruct newClue)
    {
        //maybe will help with cleared inventories
        GameObject newButton = Instantiate(baseButton, clueListTransform);

    }

    void clear()
    {
        while (clueListTransform.childCount != 0)
        {
            GameObject go = clueListTransform.GetChild(0).gameObject;
            Destroy(go);
        }
    }

    public void setButton(bool isOpen)
    {
        if (isOpen == false)
        {
            notebookButton.image.sprite = book;
            notebookButton.gameObject.GetComponentInChildren<Text>().text = "Clues";
        }
        else
        {
            notebookButton.image.sprite = x;
            notebookButton.gameObject.GetComponentInChildren<Text>().text = "Close";
        }
    }
    
    public void toggleCanvas()
    {
        conversationHolder.Instance.setClosed();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "barScene")
        {
            map.SetClosed();
        }
        
        //print("single item: " + singleItemCanvas.activeInHierarchy);
        //print("whole notebook: " + notebookCanvas.activeInHierarchy);
        if (singleItemCanvas.activeInHierarchy == false && notebookCanvas.activeInHierarchy == false)
        {
            notebookCanvas.SetActive(true);
        }
        else
        {
            if (currentClue != null)
            {
                Destroy(currentClue);
            }
            singleItemCanvas.SetActive(false);
            notebookCanvas.SetActive(false);
        }
        setButton(singleItemCanvas.activeInHierarchy || notebookCanvas.activeInHierarchy);
        
    }

    public void setClosed()
    {
        try
        {
            if (singleItemCanvas.activeInHierarchy || notebookCanvas.activeInHierarchy)
            {
                setButton(false);
                singleItemCanvas.SetActive(false);
                notebookCanvas.SetActive(false);
            }
        }
        catch (MissingReferenceException e)
        {
            
        }
    }
    private void Update()
    {
        //maybe remove
        if (Input.GetKeyDown(KeyCode.Escape) && false)
        {
            setClosed();
        }
    }
}
