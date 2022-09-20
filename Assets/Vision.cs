using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Vision : MonoBehaviour
{
    
    public Transform visionOrigin;
    public float raycastDist = 20;
    public NavMeshAgent nma;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(Camera.main.transform.position);
    }

    void OnTriggerStay(Collider c) {
        // Debug.Log("can see player"); RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        RaycastHit hit;
        Vector3 dir = (Camera.main.transform.position - visionOrigin.position).normalized;
        int layers = Physics.DefaultRaycastLayers - 64;
        if (Physics.Raycast(visionOrigin.position, dir,  out hit, raycastDist, layers))
        {
            Debug.DrawRay(visionOrigin.position, dir * raycastDist, Color.yellow);
            Debug.Log("hit " + hit.collider.gameObject.name);
        }
    }
}
