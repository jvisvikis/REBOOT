using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WorldBounds : MonoBehaviour
{

    public static WorldBounds bounds = null;
    public Vector3 size = new Vector3(10, 10, 10);
    // Start is called before the first frame update
    void Start()
    {
        bounds = this;
    }

    // Update is called once per frame
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, size);
    }

    public Vector3 getRand() {
        return new Vector3(
            Random.Range(transform.position.x - size.x/2, transform.position.x + size.x/2),
            Random.Range(transform.position.y - size.y/2, transform.position.y + size.y/2),
            Random.Range(transform.position.x - size.z/2, transform.position.z + size.z/2)
        );
    }
}
