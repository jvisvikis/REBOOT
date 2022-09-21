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
    public Transform head;

    // mood is a value representing the npc status 
    // 0 is neural, 
    // 100 is happy
    // -100 is angry
    public int mood = 0;

    public TextMeshProUGUI text;
    public GameObject emoteCanvas;

    public NPCState state = NPCState.Focusing;

    private NavMeshAgent nma;

    public float timer = 0;
    public Vector3 dest;

    //Sound
    private AudioSource walkingSFX;


    // Start is called before the first frame update
    void Start()
    {
        emoteCanvas.SetActive(false);
        homeLoc = transform.position;
        nma = GetComponent<NavMeshAgent>();
        walkingSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {

            case NPCState.Focusing:
                // state for NPC at desk working
                emoteCanvas.SetActive(false);
                if(walkingSFX.isPlaying)
                {
                    walkingSFX.Stop();
                }
                
                // if youre not at home, go home
                if ((homeLoc - transform.position).magnitude > 1) {
                    nma.SetDestination(homeLoc);
                    return;
                }

                // you must be at home, use the compouter
                if (computer.state == PCState.Malfunc || computer.state == PCState.Broken) {
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
                emoteCanvas.SetActive(true);
                // state for NPC wandering
                // do some wandering?
                if(!walkingSFX.isPlaying)
                {
                    walkingSFX.Play();
                }
                walkingSFX.Play();
                ThrowObject();
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    
                    state = NPCState.Focusing;
                }

            break;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(head.position, throwRadius);
    }

    public float throwRadius = 3;
    public float maxThrowForce = 0.1f;
    private float throwTimer = 0;
    List<Rigidbody> rbs = new List<Rigidbody>();
    void ThrowObject(){

        if (throwTimer > 0){
            throwTimer -= Time.deltaTime;
            return;
        }
        throwTimer = 10;


        rbs.Clear();
        Collider[] col = Physics.OverlapSphere(head.position, throwRadius);
        foreach (Collider c in col){
            Rigidbody rb = c.GetComponentInParent<Rigidbody>();
            if (rb != null) {
                rbs.Add(rb);
            }

        }
        if (rbs.Count == 0)
            return;
        Vector3 f = Random.onUnitSphere*20;
        rbs[(int)Random.Range(0, rbs.Count)].AddForce(
            //Random.onUnitSphere*Random.Range(0, maxThrowForce), ForceMode.Impulse);
            f, ForceMode.Impulse);
    }
}



public enum NPCState {
    Wandering,
    Focusing
}
