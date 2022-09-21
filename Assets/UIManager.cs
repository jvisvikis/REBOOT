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

    // Start is called before the first frame update
    void Awake()
    {
        manager = this;
        screenPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reboot()
    {
        Debug.Log("Reboot");
    }
}
