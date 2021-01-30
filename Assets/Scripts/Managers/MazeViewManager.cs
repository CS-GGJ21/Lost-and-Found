using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeViewManager : MonoBehaviour
{
    [Range(0, 1)]
    public float idleOpacity;
    [Range(0, 1)]
    public float nearbyOpacity;
    [Range(0, 1)]
    public float directSightOpacity;
    [SerializeField]
    private GameObject targetPlayer;
    private Transform[] environment;

    // Set up references
    void Awake()
    {
        GameObject[] environmentObjects = GameObject.FindGameObjectsWithTag("Environment");
        environment = new Transform[environmentObjects.Length];
        for (int i = 0; i < environmentObjects.Length; i++)
        {
            environment[i] = environmentObjects[i].transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // LateUpdate is called right before the render engine
    void LateUpdate()
    {
        // apply idle oppacity
        if (idleOpacity > 0)
        {
            foreach (Transform obj in environment)
            {
                if (obj.GetComponent<MeshRenderer>())
                {
                    if (!obj.GetComponent<MeshRenderer>().enabled)
                    {
                        obj.GetComponent<MeshRenderer>().enabled = true;
                    }
                    Color c = obj.GetComponent<MeshRenderer>().material.color;
                    c.a = idleOpacity;
                    obj.GetComponent<MeshRenderer>().material.color = c;
                }
            }
        }
        else
        {
            foreach (Transform obj in environment)
            {
                if (obj.GetComponent<MeshRenderer>() && obj.GetComponent<MeshRenderer>().enabled)
                {
                    obj.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }

        // apply nearby oppacity
        if (nearbyOpacity > 0)
        {
            foreach (Transform obj in targetPlayer.GetComponent<FieldOfView>().GetNearbyObstacles(false))
            {
                if (obj.GetComponent<MeshRenderer>())
                {
                    if (!obj.GetComponent<MeshRenderer>().enabled)
                    {
                        obj.GetComponent<MeshRenderer>().enabled = true;
                    }
                    Color c = obj.GetComponent<MeshRenderer>().material.color;
                    c.a = nearbyOpacity;
                    obj.GetComponent<MeshRenderer>().material.color = c;
                }
            }
        }
        else
        {
            foreach (Transform obj in targetPlayer.GetComponent<FieldOfView>().GetNearbyObstacles(false))
            {
                if (obj.GetComponent<MeshRenderer>() && obj.GetComponent<MeshRenderer>().enabled)
                {
                    obj.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }

        // apply direct sight oppacity
        if (directSightOpacity > 0)
        {
            foreach (Transform obj in targetPlayer.GetComponent<FieldOfView>().GetNearbyObstacles(true))
            {
                if (obj.GetComponent<MeshRenderer>())
                {
                    if (!obj.GetComponent<MeshRenderer>().enabled)
                    {
                        obj.GetComponent<MeshRenderer>().enabled = true;
                    }
                    Color c = obj.GetComponent<MeshRenderer>().material.color;
                    c.a = directSightOpacity;
                    obj.GetComponent<MeshRenderer>().material.color = c;
                }
            }
        }
        else
        {
            foreach (Transform obj in targetPlayer.GetComponent<FieldOfView>().GetNearbyObstacles(true))
            {
                if (obj.GetComponent<MeshRenderer>() && obj.GetComponent<MeshRenderer>().enabled)
                {
                    obj.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }
}
