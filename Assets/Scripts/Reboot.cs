using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Reboot : Interactable 
{
    // public GameObject screenPanel;
    // public Text passcodeTXT;
    // public TMP_InputField iField;
    // public Walk player;
    // private ComputerState computer;
    // private string passcode;
    // private bool rebooting;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     computer = GetComponent<ComputerState>();
    //     passcode = "11111111";
    //     passcodeTXT.text = passcode;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(rebooting && Input.GetKeyDown(KeyCode.Return))
    //     {
    //         EndRebootSequence();
    //     }
    // }

    // public void StartRebootSequence()
    // {
    //     player.SetRebooting(true);
    //     Camera.main.GetComponent<FPC>().enabled = false;
    //     rebooting = true;
    //     screenPanel.SetActive(true);
    //     Cursor.lockState = CursorLockMode.None;
    //     Cursor.visible = true;
    // }

    // public void EndRebootSequence()
    // {
    //     if(!iField.text.Equals(passcode))
    //     {
    //         return;
    //     }
    //     Camera.main.GetComponent<FPC>().enabled = true;
    //     player.SetRebooting(false);
    //     rebooting = false;
    //     screenPanel.SetActive(false);
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }

    public override void behaviour(){
     //   StartRebootSequence();
    }

}
