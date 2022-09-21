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
    private bool rebooting;

    // Start is called before the first frame update
    void Start()
    {
        iField = UIManager.manager.iField;
        passcodeTXT = UIManager.manager.passcodeTXT;
        passcode = "";
        for(int i = 0; i<8; i++)
        {
           passcode += Random.Range(0,10);
        } 
       
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
        UIManager.manager.screenPanel.SetActive(true);
        player = FindObjectOfType<Walk>().GetComponent<Walk>();
        passcodeTXT.text = passcode;
        player.SetRebooting(true);
        FindObjectOfType<FPC>().GetComponent<FPC>().enabled = false;
        rebooting = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndRebootSequence()
    {
        if(!iField.text.Equals(passcode))
        {
            return;
        }
        FindObjectOfType<FPC>().GetComponent<FPC>().enabled = true;
        player.SetRebooting(false);
        rebooting = false;
        state = PCState.Working;
        UIManager.manager.screenPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void behaviour(){
        if(state == PCState.Malfunc)
        {
            StartRebootSequence();
        }
        
    }

}

public enum PCState{
        Working,
        Malfunc,
        Broken
}
