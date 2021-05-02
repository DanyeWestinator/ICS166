using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class office01 : MonoBehaviour
{
    public Animator anim;
    public GameObject dialogueCanvas01;
    private bool isClosed = false;
    private bool isOpen = false;
    public door door;
    public Transform detective;
    private bool conversationStarted = false;
    public List<Sprite> sprites = new List<Sprite>();
    public float NPCSpeed = 1f;
    public float refreshTime = 0.5f;
    private float currentTime = 0f;
    private int i = 0;
    public GameObject leaveButton;
    public string nextScene = "crimeScene01";
    private Dictionary<string, bool> buttonsPressed = new Dictionary<string, bool> { { "w", false }, { "a", false }, { "s", false }, { "d", false } };
    public Text tutorialText;
    public List<TextAsset> dialogues = new List<TextAsset>();

    // Start is called before the first frame update
    void Start()
    {
        PlayerMove.canMove = false;
        currentTime = refreshTime;
        //dialogue.Instance.setJSON(dialogues[0]);
        dialogue.Instance.openDialogue(dialogues[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //gets called once when the dialogue closes
        if (dialogue.isOpen == false && isClosed == false)
        {
            //so it only gets called once
            isClosed = true;
            //activates the game object holding the tutorial text
            tutorialText.transform.root.gameObject.SetActive(true);
            tutorial();
            //dialogue.Instance.setJSON(dialogues[1]);
            //dialogue.Instance.openDialogue(dialogues[1]);
            anim.SetBool("isOpen", false);
        }

        //sets the tutorial text whenever a button is pressed
        if ( isOpen == false && dialogue.isOpen == false && Input.anyKeyDown)
        {
            tutorial();
        }

        //calls once when the door opens
        if (door.getIsOpen() && isOpen == false)
        {
            tutorialText.transform.root.gameObject.SetActive(false);
            isOpen = true;
            //plays the closing animation
            anim.SetBool("isOpen", true);
            StartCoroutine(sleep());
            //dialogue.Instance.openDialogue(dialogues[1]);
        }
        if (dialogue.isOpen && dialogue.Instance.JSONSource == dialogues[1] && conversationStarted == false)
        {
            conversationStarted = true;
        }
        if (conversationStarted == true && dialogue.isOpen == false && detective != null && dialogue.Instance.JSONSource == dialogues[1])
        {
            moveNPC();
        }
        if (Input.GetKeyDown(KeyCode.E) && leaveButton.activeInHierarchy)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
    IEnumerator sleep()
    {
        //print("started");
        yield return new WaitForSeconds(1.2f);
        //print("ended");
        dialogue.Instance.openDialogue(dialogues[1]);
    }

    void tutorial()
    {
        foreach (char letter in "wasd")
        {
            buttonsPressed[letter.ToString()] = (buttonsPressed[letter.ToString()] || Input.GetKeyDown(letter.ToString()));
        }
        string baseString = "Walk over to the door";
        if (buttonsPressed["w"] == false)
        {
            baseString += "\nPress <b><color=red>W</color></b> to move up";
        }
        if (buttonsPressed["a"] == false)
        {
            baseString += "\nPress <b><color=red>A</color></b> to move left";
        }
        if (buttonsPressed["s"] == false)
        {
            baseString += "\nPress <b><color=red>S</color></b> to move down";
        }
        if (buttonsPressed["d"] == false)
        {
            baseString += "\nPress <b><color=red>D</color></b> to move right";
        }
        if (baseString == "Walk over to the door")
        {
            tutorialText.transform.root.gameObject.SetActive(false);
        }
        tutorialText.text = baseString;

    }

    void moveNPC()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= refreshTime)
        {
            if (i >= sprites.Count)
                i = 0;
            detective.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
            i++;
            currentTime = 0f;
            
        }
        detective.position = new Vector3(detective.position.x, detective.position.y + (NPCSpeed * Time.deltaTime), detective.position.z);
        if (detective.position.y > 14f)
        {
            Destroy(detective.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        leaveButton.SetActive(true);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        leaveButton.SetActive(false);
    }
}
