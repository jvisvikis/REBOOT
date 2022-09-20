using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerState : Interactable
{
    public bool needsReboot;
    public bool broken;

    private GameObject screenPanel;
    private Text passcodeTXT;
    private TMP_InputField iField;
    private Walk player;
    private ComputerState computer;
    private string passcode;
    private bool rebooting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rebooting && Input.GetKeyDown(KeyCode.Return))
        {
            EndRebootSequence();
        }
    }

    public void StartRebootSequence()
    {
        screenPanel = GameObject.Find("InputPasscodePanel");
        computer = GetComponent<ComputerState>();
        Debug.Log(screenPanel);
        passcodeTXT = notepad.np.gameObject.GetComponent<Text>();
        iField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        player = FindObjectOfType<Walk>().GetComponent<Walk>();
        passcode = "11111111";
        passcodeTXT.text = passcode;
        screenPanel.SetActive(false);
        player.SetRebooting(true);
        Camera.main.GetComponent<FPC>().enabled = false;
        rebooting = true;
        screenPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndRebootSequence()
    {
        if(!iField.text.Equals(passcode))
        {
            return;
        }
        Camera.main.GetComponent<FPC>().enabled = true;
        player.SetRebooting(false);
        rebooting = false;
        screenPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void behaviour(){
        StartRebootSequence();
    }

}
