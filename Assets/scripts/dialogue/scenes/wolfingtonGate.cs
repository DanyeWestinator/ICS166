using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wolfingtonGate : MonoBehaviour
{
    public float speed = 1f;
    public static bool canOpen = false;

    private Text displayText = null;

    public bool moveX = true;
    private bool isOpening = false;
    private bool inBox = false;
    private bool isOpen = false;
    private bool isClosing;
    private Vector3 start;
    private Vector3 textStart;
    public Vector3 finalPos = new Vector3(-38.18f, -22.64f, -1.09f);
    public Vector2 finalOffset;
    private Vector2 initOffset;
    public BoxCollider2D boundaryBox;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        textStart = transform.GetChild(0).position;
        displayText = gameObject.GetComponentInChildren<Text>();
        displayText.gameObject.SetActive(false);
        initOffset = boundaryBox.offset;
        //canOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(gameManager.inputValues["interact"]) && inBox && (canOpen || dialogueVariables.Instance.tryGetValue("canOpenGate") > 0) && isOpening == false)
        {
            isOpening = true;
            boundaryBox.offset = new Vector2(0f, 0.3f);
        }
        if (moveX)
        {
            if (isOpening)
            {
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x - (Time.deltaTime * speed), pos.y, pos.z);
                transform.GetChild(0).position = textStart;
                if (transform.position.x < finalPos.x)
                {
                    boundaryBox.offset = finalOffset;
                    isOpening = false;
                    isOpen = true;
                }
            }
            if ((Input.GetKeyDown(gameManager.inputValues["interact"]) || isClosing) && isOpen)
            {
                isClosing = true;
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x + (Time.deltaTime * speed), pos.y, pos.z);
                transform.GetChild(0).position = textStart;
                if (transform.position.x > start.x)
                {
                    boundaryBox.offset = initOffset;
                    isClosing = false;
                    isOpen = false;
                }
            }
        }
        else
        {
            if (isOpening)
            {
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x, pos.y - (Time.deltaTime * speed), pos.z);
                transform.GetChild(0).position = textStart;
                if (transform.position.y < finalPos.y)
                {
                    boundaryBox.offset = finalOffset;
                    isOpening = false;
                    isOpen = true;
                }
            }
            if ((Input.GetKeyDown(gameManager.inputValues["interact"]) || isClosing) && isOpen)
            {
                isClosing = true;
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x, pos.y + (Time.deltaTime * speed), pos.z);
                transform.GetChild(0).position = textStart;
                if (transform.position.y > start.y)
                {
                    boundaryBox.offset = initOffset;
                    isClosing = false;
                    isOpen = false;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        displayText.gameObject.SetActive(true);
        if (canOpen)
        {
            displayText.text = "Press \"e\" to open";
        }
        if (isOpen)
        {
            displayText.text = "Press \"e\" to close";
        }
        inBox = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        displayText.gameObject.SetActive(false);
        inBox = false;
    }
}
