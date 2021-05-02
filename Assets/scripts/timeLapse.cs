using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeLapse : MonoBehaviour
{
    public SpriteRenderer sr;
    public float timeBetweenFrames = 0.1f;
    private int max = 2842;
    private int current = 584;
    private float currentTime = 0f;
    private bool toStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toStart = true;
        }
        if (toStart)
        {
            currentTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.R))
            {
                current = 584;
            }
            if (currentTime >= timeBetweenFrames && current < max)
            {
                current++;
                string path = "Pictures/DSC0";
                if (current < 1000)
                {
                    path += '0'.ToString();
                }
                path += current.ToString();
                sr.sprite = Resources.Load<Sprite>(path);
                currentTime = 0f;
            }
        }
    }
}
