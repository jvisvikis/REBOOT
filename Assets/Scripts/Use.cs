using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    
    public float useDist = 3;
    // Update is called once per frame
    void Update()
    {
        UIManager.manager.use.SetActive(false);
        Vector3 dir = Camera.main.transform.forward;
        int layers = Physics.DefaultRaycastLayers - 64;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, dir,  out hit, useDist, layers))
        {
            Interactable inter = hit.collider.gameObject.GetComponent<Interactable>();
            if (inter != null) {
                UIManager.manager.use.SetActive(true);
                if (Input.GetButtonDown("Fire1")) {
                    inter.behaviour();
                }
                
            }
        }
        
        
    }
}
