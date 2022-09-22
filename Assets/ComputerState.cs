using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerState : Interactable
{
    
    public PCState state = PCState.Working;
    private TMP_InputField iField;
    private Text passcodeTXT;
    private Walk player;
    private ComputerState computer;
    private string passcode;

    //Particle effects
    public ParticleSystem fire;

    //sfx variables
    private AudioSource malFuncSFX;

    //flashing effect variables
    public float timerCD;
    private float timer;
    private bool canvasState;
    public Canvas Indicator;

    //Time Till Breakdown
    private float breakdownTimer;
    public float breakdownTimerCD;

    //Grace Timer
    private float graceTimer;
    public float graceCD;

    // Start is called before the first frame update
    void Start()
    {
        iField = UIManager.manager.iField;
        passcodeTXT = UIManager.manager.passcodeTXT;
        passcode = "";
        malFuncSFX = GetComponent<AudioSource>();

        breakdownTimer = breakdownTimerCD;

        for(int i = 0; i<5; i++)
        {
           passcode += Random.Range(0,10).ToString();
        }
        // Debug.Log($"/{passcode}/");
        UIManager.manager.MalfuncSubscribe(this);
       
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case PCState.Rebooting:
                Indicator.gameObject.SetActive(false);
                UIManager.manager.reticle.SetActive(false);
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    EndRebootSequence();
                }

                if(Input.GetKeyDown(KeyCode.X))
                {
                    iField.text = "";
                    FindObjectOfType<FPC>().GetComponent<FPC>().enabled = true;
                    player.SetRebooting(false);
                    UIManager.manager.screenPanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    malFuncSFX.Stop();
                    UIManager.manager.reticle.SetActive(true);
                    state = PCState.Malfunc;
                }
            break;

            case PCState.Malfunc:
                
                if(!fire.isPlaying)
                {
                    fire.Play();
                }

                if(!malFuncSFX.isPlaying)
                {
                    malFuncSFX.Play();
                }

                if(timer <= 0)
                {
                    canvasState = !canvasState;
                    timer = timerCD;
                }

                if(breakdownTimer <= 0)
                {
                    state = PCState.Broken;
                    UIManager.manager.ComputerBreak();
                }

                breakdownTimer -= Time.deltaTime;
                timer -= Time.deltaTime;
                Indicator.gameObject.SetActive(canvasState);

            break;

            case PCState.Working:
            graceTimer -= Time.deltaTime;
                if(fire.isPlaying)
                    {
                        fire.Stop();
                    }
                Indicator.gameObject.SetActive(false);               
                    
            break;
        }
        
    }

    public void StartRebootSequence()
    {
        UIManager.manager.screenPanel.SetActive(true);
        player = FindObjectOfType<Walk>().GetComponent<Walk>();
        passcodeTXT.text = passcode;
        player.SetRebooting(true);
        FindObjectOfType<FPC>().GetComponent<FPC>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        state = PCState.Rebooting;
        Cursor.visible = true;
        iField.Select();
        iField.ActivateInputField();
    }

    public void EndRebootSequence()
    {
        if(!iField.text.Contains(passcode))
        {
            iField.Select();
            iField.ActivateInputField();
            return;
        }
        breakdownTimer = breakdownTimerCD;
        iField.text = "";
        FindObjectOfType<FPC>().GetComponent<FPC>().enabled = true;
        player.SetRebooting(false);
        state = PCState.Working;
        UIManager.manager.screenPanel.SetActive(false);
        UIManager.manager.IncrementScore();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        malFuncSFX.Stop();
        UIManager.manager.reticle.SetActive(true);
        graceTimer = graceCD;
    }

    public override void behaviour(){
        if(state == PCState.Malfunc)
        {
            StartRebootSequence();
        }        
    }

    public void Malfunc(){
        if(state == PCState.Working && graceTimer<=0)
        {
            state = PCState.Malfunc;
        }
        
    }

    public override bool isActive()
    {
        return state == PCState.Malfunc;
    }

}

public enum PCState{
        Working,
        Malfunc,

        Rebooting,
        Broken
}
