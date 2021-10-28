using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{

    [Header("Stats")]
    public int curHP;
    public int massHP;
    public int scoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset; 

    private List<Vector3> path;
    private Weapon weapon;
    private GameObject target; 

    // Start is called before the first frame update
    void Start()
    {
        //Gather the Components
        weapon = GetComponents<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    void UpdatePath ()
    {
        //Calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        //Save path as a list 
        path = navMesh.corners.ToList();
    }


    void ChaseTarget()
    {
        if(path.Count == 0)
            return;
        //move towards the closest pat
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moeSpeed * Time.deltaTime);
        
        if(transform.postion == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
