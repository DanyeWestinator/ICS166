using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crimeScene01 : MonoBehaviour
{
    [Header("Dialogues")]
    public List<TextAsset> detectiveDialogues = new List<TextAsset>();
    public static bool exists = false;
    public static string currentChar = "";
    public GameObject boss;
    private bool bossStarted = false;

    private void Awake()
    {
        exists = true;
    }
    // Start is called before the first frame update
    void Start()
    {

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "crimeScene01")
        {
            boss = GameObject.Find("boss");
            if (bossStarted == false && dialogueVariables.Instance.tryGetValue("startBoss") > 0)
            {
                bossStarted = true;
                boss.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueVariables.Instance.tryGetValue("hasKey") > 0)
        {
            wolfingtonGate.canOpen = true;
        }
        if (dialogueVariables.Instance.tryGetValue("changeScene") > 0 && dialogue.isOpen == false)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("FinalBoss");
        }
        
    }

    public static void SetDialogue(TextAsset dialogue = null)
    {

    }

    public static void OpenDialogue(TextAsset script = null)
    {
        if (script == null)
        {
            throw new UnityException("you forgot to get a script");
        }
        dialogue.Instance.openDialogue(script);
    }
}
