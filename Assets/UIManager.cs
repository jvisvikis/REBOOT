using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager manager;
    public GameObject screenPanel;
    public Text passcodeTXT;
    public TMP_InputField iField;

    private List<ComputerState> comps;

    public List<AudioClip> backgroundMusic;
    public GameObject use;
    public GameObject reticle;

    // Start is called before the first frame update
    void Awake()
    {
        manager = this;
        screenPanel.SetActive(false);
        comps = new List<ComputerState>();
    }

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer-=Time.deltaTime;

        MalfuncPublish();
    }

    void Reboot()
    {
        Debug.Log("Reboot");
    }

    public void MalfuncSubscribe(ComputerState c){
        comps.Add(c);
    }

    public float breakTime = 10;
    private float timer = 5;
    public float breakDivisor = 1.2f;
    private void MalfuncPublish(){
        if (timer <= 0){
            // break something
            breakTime /= breakDivisor;
            timer = breakTime;
            
            
            comps[(int)Random.Range(0, comps.Count)].Malfunc();          
        }        
    } 
}
