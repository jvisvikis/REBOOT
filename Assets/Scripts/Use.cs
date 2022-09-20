using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
        
            Vector3 dir = Camera.main.transform.forward;
            int layers = Physics.DefaultRaycastLayers - 64;
            if (Physics.Raycast(Camera.main.transform.position, dir,  out hit, 2, layers))
            {
                Interactable inter = hit.collider.gameObject.GetComponent<Interactable>();
                if (inter != null) {
                    Debug.Log("get an interactable");
                }
            }
        }
        
    }
}
