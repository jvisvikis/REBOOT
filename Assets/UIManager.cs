using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager manager;
    public GameObject screenPanel;
    public Text passcodeTXT;
    public TMP_InputField iField;

    private List<ComputerState> comps;

    public List<AudioClip> backgroundMusic;
    private int musicIdx;
    public GameObject use;
    public GameObject reticle;
    public GameObject gameOverPanel;
    public GameObject brokenPCPanel;
    public Text scoreTxt;

    public List<Image> lights;

    private float trackTimer;
    public float trackCD;
    private AudioSource backingTrack;

    private int brokenPCs;
    public int BrokenPCs
    {
        get
        {
            return brokenPCs;
        }
    }

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
    }
    

    // Start is called before the first frame update
    void Awake()
    {
        manager = this;
        screenPanel.SetActive(false);
        comps = new List<ComputerState>();
        backingTrack = GetComponent<AudioSource>();
       
    }

    void Start(){
        trackTimer = trackCD;
        backingTrack.clip = backgroundMusic[musicIdx];
        backingTrack.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer-=Time.deltaTime;
        MalfuncPublish();

        if(trackTimer < 0 && musicIdx != backgroundMusic.Count-1)
        {
            trackTimer = trackCD;
            musicIdx++;
            backingTrack.clip = backgroundMusic[musicIdx];
            backingTrack.Play();
        }
        trackTimer -= Time.deltaTime;

        if (brokenPCs>=3)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            FindObjectOfType<FPC>().GetComponent<FPC>().enabled = false;
            gameOverPanel.SetActive(true);
            scoreTxt.text = "Computers Rebooted: " + score;
        }
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

    public void ComputerBreak()
    {
        lights[brokenPCs].color = new Color32(255,0,0,255);
        brokenPCs++;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log(score);
    }

    public void Quit(){
        Application.Quit();
    } 
}
