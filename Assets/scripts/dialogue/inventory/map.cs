using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class map : MonoBehaviour
{
    private Canvas displayMap = null;
    private GameObject mapImage = null;
    private Button mapButton = null;
    private GameObject crosshair = null;

    private bool isOpen = true;
    private static map instance = null;

    public Sprite redX;
    private Sprite mapTube;

    private bool hasReset = false;

    public float xOffset = -100f;
    public float yOffset = -50f;
    public float ySlope = 1f;
    public float xSlope = 1f;

    public Vector2 scaleBounds = Vector2.zero;
    public float rotateSpeed = 1f;
    private int growOrShrink = 1;
    public float shrinkSpeed = 0.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (displayMap == null)
        {
            displayMap = this.gameObject.GetComponent<Canvas>();
        }
        mapImage = displayMap.transform.Find("mapImage").gameObject;
        crosshair = mapImage.transform.GetChild(0).gameObject;
        mapImage.SetActive(false);
        mapButton = displayMap.transform.Find("mapButton").gameObject.GetComponent<Button>();
        mapTube = mapButton.image.sprite;
        //gameManager.inputValues.Add("map", "m");
        gameManager.addTo("map", "m");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        { print(crosshair.transform.position);}
        if (Input.GetKeyDown(gameManager.inputValues["map"]))
        {
            OnClick();
        }
        if (isOpen == false && hasReset == false)
        {
            hasReset = true;
            moveCrosshair(PlayerMove.currentPos);
        }
        if (isOpen)
        {
            hasReset = false;
        }

        if (isOpen == false)
        {
            rotateCrosshair();
        }
    }


    void rotateCrosshair()
    {
        crosshair.transform.eulerAngles = crosshair.transform.eulerAngles + (Time.deltaTime * Vector3.forward * rotateSpeed);
        Vector3 scale = crosshair.transform.localScale;
        if (scale.x > scaleBounds.y || scale.x < scaleBounds.x)
        {
            growOrShrink *= -1;
        }
        crosshair.transform.localScale = scale + (growOrShrink * new Vector3(1f, 1f, 1f) * Time.deltaTime * shrinkSpeed);
    }

    public void OnClick()
    {
        //every time it's clicked, it closes everything then opens if necessary
        inventoryManager.Instance.setClosed();
        conversationHolder.Instance.setClosed();
        
        if (isOpen)
        {
            SetOpen();
        }
        if (isOpen == false)
        {
            SetClosed();
        }
        isOpen = !isOpen;
    }

    private void moveCrosshair(Vector3 playerPos)
    {

        //1653 x
        //953 y

        //player offset 
        //x: 84.5 right
        //y: 100 up
        //playerPos.y += 97.9f;
        
        //print(playerPos);
        Vector3 basePos = playerPos;
        basePos.x += xOffset;
        basePos.y += yOffset;
        basePos.x *= xSlope;
        basePos.y *= ySlope;
        
        crosshair.GetComponent<RectTransform>().anchoredPosition = basePos;

    }

    private void SetClosedPrivate()
    {
        PlayerMove.canMove = true;
        mapImage.SetActive(false);
        mapButton.image.sprite = mapTube;
        mapButton.GetComponentInChildren<Text>().text = "Map";
        mapButton.transform.GetChild(1).gameObject.SetActive(true);

    }
    public static void SetClosed()
    {
        if (instance == null)
        {
            instance = GameObject.Find("Conversations").GetComponent<map>();
        }
        else
        {
            instance.SetClosedPrivate();
        }
    }
    private void SetOpen()
    {
        PlayerMove.canMove = false;
        mapButton.image.sprite = redX;
        mapButton.GetComponentInChildren<Text>().text = "Close";
        mapButton.transform.GetChild(1).gameObject.SetActive(false);
        mapImage.SetActive(true);
        crosshair.transform.eulerAngles = Vector3.zero;
        crosshair.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        
    }
}
