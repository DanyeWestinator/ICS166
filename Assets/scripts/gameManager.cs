using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    private Dictionary<string, int> variables;
    private static gameManager instance;
    private int frameI = 0;
    //Hardcoding values for input values
    public static Dictionary<string, string> inputValues = new Dictionary<string, string> {
        { "interact", "e"}
        };

    [Header("Audio things")]
    public Slider volumeSlider;
    public List<AudioClip> songs = new List<AudioClip>();
    private AudioSource source;

    [Header("Pause Menu Things")]
    public GameObject pauseCanvas;
    private bool isPaused = true;
    private List<GameObject> pausedCanvases = new List<GameObject>();


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public static gameManager Instance { get { return instance; } }

    public static void addTo(string name, string key)
    {
        if (inputValues.ContainsKey(name) == false)
        {
            inputValues.Add(name, key);
        }
        else
        {
        }
    }

    public void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("GameController"))
        {
            if (go != instance.gameObject)
            {
                Destroy(go);
            }
        }
    }
    private void Update()
    {
        if (frameI < 25)
        {
            frameI++;
        }
        else if (frameI == 5)
        {
            frameI = 26;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("GameController"))
            {
                if (go != this.gameObject)
                {
                    Destroy(go);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PlayPause(isPaused);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        clue.cluesCollected = new Dictionary<string, bool>();
        dialogueVariables.Reset();
        UnityEngine.SceneManagement.SceneManager.LoadScene("office01");
    }

    public void load()
    {
        variables = dialogueVariables.Instance.getVariables();
        List<string> savedData = Resources.Load<TextAsset>("savedText").text.Split('\n').ToList();
        foreach (string s in savedData)
        {
            if (s != '\n'.ToString() && s != "" && s.StartsWith("#") == false)
            {
                string[] KVpair = s.Split(' ');
                string varName = KVpair[0];
                int num = Int32.Parse(KVpair[1]);
                if (variables.ContainsKey(varName) == false)
                {
                    variables.Add(varName, num);
                }
                else
                {
                    variables[varName] = num;
                }
            }

        }

        Transform contentList = inventoryManager.Instance.gameObject.transform.Find("notebookCanvas/Scroll View/Viewport/Content");
        for (int i = 0; i < contentList.childCount; i++)
        {
            print(contentList.GetChild(i));
        }
    }

    public void save()
    {
        string path = "Assets/Resources/savedText.txt";

        File.WriteAllText(path, string.Empty);

        StreamWriter writer = new StreamWriter(path, true);

        foreach (string s in variables.Keys)
        {
            writer.Write(s + " " + variables[s] + '\n');
        }
        writer.Close();

    }

    public void setVolume()
    {
        float newVolume = volumeSlider.value;
        source.volume = newVolume;
    }
    public void setMusic(AudioClip clip = null)
    {
        if (clip == null)
        {
            clip = songs[UnityEngine.Random.Range(0, songs.Count - 1)];
        }
        source.clip = clip;
        source.Play();

    }
    void PlayPause(bool toPause = true)
    {
        //false to pause, true to play
        isPaused = toPause;
        if (isPaused == false)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("hasCanvas"))
            {
                pausedCanvases.Add(go);
                go.SetActive(toPause);

            }
        }
        else
        {
            foreach (GameObject go in pausedCanvases)
            {
                go.SetActive(true);
            }
            pausedCanvases = new List<GameObject>();
        }
        
        PlayerMove.canMove = toPause;
        pauseCanvas.SetActive(!toPause);
    }
}
