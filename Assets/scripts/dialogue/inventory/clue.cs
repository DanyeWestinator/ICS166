using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class clue : MonoBehaviour
{
    public string clueName;
    public string originLocation = "";
    public string flavorText = "";
    private inventoryManager inventoryManager;
    public Text prompt;
    private Canvas clueCanvas;
    public string spriteName = "";
    public List<string> variables = new List<string>();

    private bool inBox;

    public static Dictionary<string, bool> cluesCollected = new Dictionary<string, bool>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (cluesCollected.ContainsKey(clueName) == false)
        {
            cluesCollected.Add(clueName, false);
        }
        else
        {
            if (cluesCollected[clueName])
            {
                if (inventoryManager.Instance.containsClue(clueName) == false)
                {
                    inventoryManager.Instance.createButton(this.gameObject);
                }
                
                Destroy(this.gameObject);
            }
        }
        string path = "clues/" + spriteName;
        if (spriteName.StartsWith("clues") == false)
        {
            spriteName = path;
        }
        //print(path);
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
        if (inventoryManager == null)
        {
            inventoryManager = inventoryManager.Instance;
        }
        if (clueCanvas == null)
        {
            clueCanvas = inventoryManager.gameObject.transform.Find("singleItemCanvas").GetComponent<Canvas>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inBox && Input.GetAxis("Interact") != 0)
        {
            inBox = false;
            clueCanvas.gameObject.SetActive(true);
            clueCanvas.transform.Find("Location").gameObject.GetComponent<Text>().text = "Found in:\n\t" + originLocation;
            clueCanvas.transform.Find("Flavortext").gameObject.GetComponent<Text>().text = flavorText;
            clueCanvas.transform.Find("Name").gameObject.GetComponent<Text>().text = clueName;
            clueCanvas.transform.Find("Image").gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            inventoryManager.setButton(true);
            addToJournal();
        }
        
    }

    void addToJournal()
    {
        cluesCollected[clueName] = true;
        foreach (string item in variables)
        {
            int value = Int32.Parse(item.Split(' ')[1]);
            string name = item.Split(' ')[0];
            dialogueVariables.Instance.updateValue(name, value);
        }

        inventoryManager.createButton(this.gameObject);
        
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inBox = true;
        prompt.gameObject.SetActive(true);
        prompt.text = "Press E to inspect " + clueName;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inBox = false;
        prompt.gameObject.SetActive(false);
    }
}
