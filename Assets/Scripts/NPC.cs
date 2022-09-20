using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{

    private static string working = "";
    private static string sad = ":(";
    private static string angry = ">:|";

    // mood is a value representing the npc status 
    // 0 is neural, 
    // 100 is happy
    // -100 is angry
    public int mood = 0;

    public TextMeshProUGUI text;
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
