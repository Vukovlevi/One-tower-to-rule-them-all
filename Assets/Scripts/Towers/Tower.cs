using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Vector3 projectileShootFrom;
    public GameObject projectileArrow;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            projectileArrow.GetComponent<ProjectileArrow>().Create(projectileShootFrom, target.transform.position);
        }
    }

    private void Awake()
    {
        projectileShootFrom = transform.Find("ProjectileShootFrom").position;
    }
}
