using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator anim;
    private bool isOpen = false;
    public bool canOpen = false;
    private bool oldCanOpen;
    public float resetTime = 0.8f;
    public AudioClip doorOpeningSound;
    public AudioClip doorClosingSound;
    public GameObject background;
    public GameObject displayText;
    public GameObject detectiveConversation;
    private bool hasOpened = false;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            toggleOpen();
        }
            
    }

    void toggleOpen()
    {
        background.SetActive(isOpen);
        if (isOpen)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<AudioSource>().clip = doorClosingSound;
            anim.Play("closing", -1);
        }
        else
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().enabled = false;

            gameObject.GetComponent<AudioSource>().clip = doorOpeningSound;
            anim.Play("opening", -1);
        }
        isOpen = !isOpen;
        oldCanOpen = canOpen;
        canOpen = false;
        StartCoroutine(resetCanOpen());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpen = true;
            displayText.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpen = false;
            displayText.SetActive(false);
        }
        
    }

    IEnumerator resetCanOpen()
    {
        yield return new WaitForSeconds(resetTime);
        canOpen = oldCanOpen;
        if (hasOpened == false)
        {
            hasOpened = true;
            resetTime = 0.8f;
            dialogue.Instance.gameObject.SetActive(true);
            PlayerMove.canMove = false;
        }
    }
    public bool getIsOpen() { return isOpen; }
    
}
