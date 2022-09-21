using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    private static string working = "";
    private static string sad = ":(";
    private static string angry = ">:|";

    private Vector3 homeLoc;
    public ComputerState computer;

    // mood is a value representing the npc status 
    // 0 is neural, 
    // 100 is happy
    // -100 is angry
    public int mood = 0;

    public TextMeshProUGUI text;
    public GameObject image;

    public NPCState state = NPCState.Focusing;

    private NavMeshAgent nma;

    public float timer = 0;
    public Vector3 dest;

    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
        homeLoc = transform.position;
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {

            case NPCState.Focusing:
                // state for NPC at desk working

                // if youre not at home, go home
                if ((homeLoc - transform.position).magnitude > 1) {
                    nma.SetDestination(homeLoc);
                    return;
                }

                // you must be at home, use the compouter
                if (computer.state == PCState.Malfunc) {
                    state = NPCState.Wandering;
                    dest = WorldBounds.bounds.getRand();
                    dest.Set(dest.x, transform.position.y, dest.z);
                    nma.SetDestination(dest);
                    timer = Random.Range(20, 40);
                } else if (computer.state == PCState.Broken) {
                    // if the computer breaks while the npc is using it
                    state = NPCState.Wandering;
                    nma.SetDestination(WorldBounds.bounds.getRand());
                    timer = Random.Range(20, 40);
                }

            break;

            case NPCState.Wandering:
                // state for NPC wandering
                // do some wandering?
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    
                    state = NPCState.Focusing;
                }

            break;
        }
    }

    void f(){
        switch (computer.state) {

            case PCState.Working:

            break;

            case PCState.Broken:
            
            break;

            case PCState.Malfunc:
            
            break;
        }
    }
}



public enum NPCState {
    Wandering,
    Focusing
}
