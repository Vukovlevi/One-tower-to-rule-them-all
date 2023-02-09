using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    public Transform pfProjectileArrow;
    private float moveSpeed = 8f;
    private float destroyDistance = 0.2f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Create(Vector3 spawnPosition, GameObject targetGet)
    {
        Instantiate(pfProjectileArrow, spawnPosition, Quaternion.identity);
        target = targetGet;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        Vector3 moveDir = (target.transform.position - transform.position).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float angle = GetAngleFromVectorFloat(moveDir);
        transform.eulerAngles = Vector3.forward * angle;

        if (Vector3.Distance(target.transform.position, transform.position) < destroyDistance)
        {
            Destroy(target);
            Destroy(gameObject);
        }
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        if (angle < 0)
        {
            angle += 360;
        }
        return angle;
    }
}
