using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reboot : Interactable 
{
    public GameObject screenPanel;
    private ComputerState computer;
    // Start is called before the first frame update
    void Start()
    {
        computer = GetComponent<ComputerState>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(computer.needsReboot && Input.GetKeyDown(KeyCode.E))
    //     {
    //         StartRebootSequence();
    //     }
    // }

    void StartRebootSequence()
    {
        screenPanel.SetActive(true);
    }

    public override void behaviour(){

    }

}
