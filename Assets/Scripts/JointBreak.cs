using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JointBreak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnJointBreak(){
        NavMeshObstacle nma = GetComponent<NavMeshObstacle>();
        if (nma != null){
            Destroy(nma);
            Destroy(this);
        }
    }
}
