using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine.UI;
using System;


public class Node
{
    string speaker;
    string text;
    string sourceTitle;
    bool children = false;

    private Dictionary<string, string> nextNodes = new Dictionary<string, string>();
    //functions are variable thresholds that have to be reached in order for a branch to be valid
    private List<string> functions = new List<string>();

    //toAdd vars change values in the dialogue variables master dictionary
    private List<string> toAdd = new List<string>();

    //clues get added to the conversations canvas
    private List<string> clues = new List<string>();

    public Node(string title, string speaker, string text)
    {
        this.sourceTitle = title;
        this.speaker = speaker;
        string pattern = @"\[\[[\w:.\|]*\]\]";
        string mid = @"[\w,.!';:@#${\[ \]%^&\*<>\\?]*";
        MatchCollection next = Regex.Matches(text, pattern);
        foreach (Match x in next)
        {
            
            string nextNode = x.ToString().Substring(x.ToString().IndexOf('|') + 1).Replace("]]", "");
            //Debug.Log(nextNode);
            if (nextNodes.ContainsKey(nextNode) == false)
            {
                nextNodes[nextNode] = "Placeholder";
                children = true;
            }
        }
        string pattern2 = @"<reqVar>" + mid + @"</reqVar>";
        next = Regex.Matches(text, pattern2);
        foreach (Match x in next)
        {
            string temp = x.Value;
            temp = temp.Replace("<reqVar>", "");
            temp = temp.Replace("</reqVar>", "");
            functions.Add(temp);
        }
        string pattern3 = @"<cngVar>" + mid + @"</cngVar>";
        next = Regex.Matches(text, pattern3);
        foreach (Match x in next)
        {
            string temp = x.Value;
            temp = temp.Replace("<cngVar>", "");
            temp = temp.Replace("</cngVar>", "");
            toAdd.Add(temp);
        }
        
        string pattern4 = @"<clue>" + mid + @"<\/clue>";
        next = Regex.Matches(text, pattern4);
        foreach (Match x in next)
        {
            string temp = x.Value;
            temp = temp.Replace("<clue>", "");
            temp = temp.Replace("</clue>", "");
            //Debug.Log(temp);
            clues.Add(temp);
        }
        this.text = Regex.Replace(text, pattern, "").Trim();
        this.text = Regex.Replace(this.text, pattern2, "");
        this.text = Regex.Replace(this.text, pattern3, "");
        this.text = Regex.Replace(this.text, pattern4, "");
    }

    public void updateDict(string next, string text)
    {
        if (nextNodes.ContainsKey(next) == true && next != this.sourceTitle)
        {
            nextNodes[next] = text;
        }
    }

    public override string ToString()
    {
        string toReturn = "";
        toReturn += speaker + ":\n\t" + text;
        if (children)
        {
            int i = 1;
            foreach (string response in getResponses())
            {
                toReturn += "\n\t\t" + i + ") " + response;
                i++;
            }
        }
        if (functions.Count > 0)
        {
            toReturn += "\nFunctions:";
            foreach (string s in functions)
            {
                toReturn += "\n\t" + s;
            }
        }

        return toReturn;
    }

    //getters and setters
    public string getSpeaker() { return speaker; }
    public string getText() { return text; }
    public string getTitle() { return sourceTitle; }
    public bool hasChildren() { return children; }
    public List<string> getFunctions() { return functions; }
    public List<string> getToAdd() { return toAdd; }
    public List<string> getResponseTitles() { return nextNodes.Keys.ToList(); }
    public List<string> getClues() { return clues; }

    public List<string> getResponses()
    {
        List<string> responses = new List<string>();
        foreach (KeyValuePair<string, string> response in nextNodes)
        {
            responses.Add(response.Value);
        }

        return responses;
    }
}


public class dialogue : MonoBehaviour
{
    public TextAsset JSONSource;
    public bool printList = false;

    //intenal things
    private List<Node> nodes = new List<Node>();
    private Node currentNode;
    private Node originalNode;
    public static bool isOpen = false;
    private List<GameObject> pausedCanvases = new List<GameObject>();

    //display things
    public List<Button> responseButtons = new List<Button> { null, null, null, null, null };
    public Text displayText;
    public Text speakerText;
    private Sprite speakerSprite;
    public Image speakerImage;

    private static dialogue instance = null;

    public static dialogue Instance { get{ return instance; }}
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(transform.root.gameObject);
            Destroy(this.gameObject);
        }
        instance = this.gameObject.GetComponent<dialogue>();
        DontDestroyOnLoad(transform.root.gameObject);
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<dialogue>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        nodes = new List<Node>();
        parseJSON();
        currentNode = nodes[0];
        if (printList)
        {
            print(currentNode.ToString());
        }
        

        updateDisplay();
        originalNode = currentNode;
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<dialogue>();
        }
    }

    private void Update()
    {
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<dialogue>();
        }
    }

    //sets a new json then resets everything
    public void setJSON(TextAsset newJSON)
    {
        JSONSource = newJSON;
        Start();
    }

    void updateDisplay()
    {
        foreach (var button in responseButtons)
        {
            button.gameObject.SetActive(false);
        }
        foreach (string clue in currentNode.getClues())
        {
            conversationHolder.Instance.createButton(currentNode.getSpeaker(), clue);
        }
        displayText.text = currentNode.getText();
        speakerText.text = "Speaking:\n<b>" + currentNode.getSpeaker() + "</b>";
        speakerSprite = Resources.Load<Sprite>(currentNode.getSpeaker());
        speakerImage.sprite = speakerSprite;
        
        List<string> responses = getValidResponses();
        if (responses.Count == 0)
        {
            responseButtons[4].gameObject.SetActive(true);
        }
        for (int i = 0; i < responses.Count; i++)
        {
            responseButtons[i].gameObject.SetActive(true);
            
            responseButtons[i].GetComponentInChildren<Text>().text = responses[i];
            if (responses.Count == 1)
            {
                responseButtons[i].GetComponentInChildren<Text>().text = "Continue";
            }

        }
    }

    private List<string> getValidResponses()
    {
        List<string> responses = new List<string>();
        foreach (string s in currentNode.getResponses())
        {
            bool isValid = true;
            Node next = getNextNode(s);
            foreach (string functions in next.getFunctions())
            {
                int value = Int32.Parse(functions.Split(' ')[1]);
                if (functions.Split(' ')[1].StartsWith('0'.ToString()))
                {
                    //print("got a negative!");
                    //makes it negative 10
                    value = -10;
                    //print(value);
                }
                string name = functions.Split(' ')[0];
                //print(value * 10);
                //print(dialogueVariables.Instance.tryGetValue(name));
                //dialogueVariables.Instance.printAll();
                if (value > dialogueVariables.Instance.tryGetValue(name))
                {
                    //dialogueVariables.Instance.printAll();
                    isValid = false;
                }
                
            }
            //print("" + isValid + s);
            if (isValid)
                responses.Add(s);
        }
        
        return responses;
    }
    

    private Node getNextNode(string s)
    {
        return nodes.Find(next => next.getText() == s);
    }

    public void getButtonPressed(int i)
    {
        if (printList) { print(currentNode.ToString()); }

        string nextTitle = currentNode.getResponseTitles()[i];
        currentNode = nodes.Find(next => next.getTitle() == nextTitle);
        foreach (string s in currentNode.getToAdd())
        {
            string[] vars = s.Split(' ');
            dialogueVariables.Instance.updateValue(vars[0], Int32.Parse(vars[1]));
        }
        if (currentNode.getTitle().StartsWith("Player") && currentNode.getResponseTitles().Count > 0)
        {
            //nextTitle = currentNode.getResponseTitles()[0];
            //currentNode = nodes.Find(next => next.getTitle() == nextTitle);
        }
        updateDisplay();
    }

    public void closeDialogue()
    {
        foreach (GameObject go in pausedCanvases)
        {
            go.SetActive(true);
        }
        pausedCanvases = new List<GameObject>();
        isOpen = false;
        responseButtons[0].gameObject.transform.root.GetChild(0).gameObject.SetActive(false);
        PlayerMove.canMove = true;
        currentNode = originalNode;
        updateDisplay();
    }
    public void openDialogue(TextAsset jsonSource = null)
    {
        if (instance != null)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("hasCanvas"))
            {
                if (go != instance.gameObject && (conversationHolder.Instance != null && go != conversationHolder.Instance.gameObject))
                {
                    pausedCanvases.Add(go);
                    go.SetActive(false);
                }
            

            }
        }

        
        isOpen = true;
        responseButtons[0].gameObject.transform.root.GetChild(0).gameObject.SetActive(true);
        PlayerMove.canMove = false;
        if (jsonSource != null)
        {
            setJSON(jsonSource);
        }
    }
    

    void parseJSON()
    {
        string JSONtext = JSONSource.text;
        //cleans up the text for unity rich text
        JSONtext = JSONtext.Replace("[i]", "<i>");
        JSONtext = JSONtext.Replace("[/i]", "</i>");
        //gets the data in a readable data type
        JSONNode data = JSON.Parse(JSONtext);

        //makes a new dialogue node from each json item
        foreach (JSONNode record in data)
        {
            Node currentNode = new Node(record["title"], record["tags"], record["body"]);
            nodes.Add(currentNode);
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            foreach (string currentTitle in nodes[i].getResponseTitles())
            {
                
                try
                {
                    nodes[i].updateDict(currentTitle, nodes.Find(node => node.getTitle() == currentTitle).getText());
                }
                catch(NullReferenceException e)
                {
                    print(nodes[i]);
                    print(currentTitle);
                    print(nodes.Find(node => node.getTitle() == currentTitle).getText());
                    throw e;

                }
                
            }
        }
        if (printList) { foreach (Node x in nodes) { print(x.ToString()); } }
    }
}
