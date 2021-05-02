using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;

public class dialogueVariables : MonoBehaviour
{
    private static dialogueVariables instance = null;

    private static Dictionary<string, int> variables = new Dictionary<string, int>();
    
    
    public static dialogueVariables Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public Dictionary<string, int> getVariables() { return variables; }

    // Start is called before the first frame update
    void Start()
    {
        //load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void printAll()
    {
        foreach (string s in variables.Keys)
        {
            print(s + " " + variables[s]);
        }
    }

    public int tryGetValue(string s)
    {
        if (variables.ContainsKey(s) == false)
        {
           
            variables.Add(s, 0);
            return 0;
        }
        return variables[s];
    }

    public void updateValue(string s, int toAdd)
    {
        if (variables.ContainsKey(s) == false)
        {
            variables.Add(s, toAdd);
        }
        else
        {
            variables[s] += toAdd;
        }
    }
    public static void Reset()
    {
        variables = new Dictionary<string, int>();
    }

    public bool contains(string s) { return variables.ContainsKey(s); }

}
