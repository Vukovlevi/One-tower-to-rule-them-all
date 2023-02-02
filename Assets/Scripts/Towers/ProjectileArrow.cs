using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    public Transform pfProjectileArrow;
    private float moveSpeed = 8f;
    private float destroyDistance = 1f;
    private Vector3 targetPositionLocale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (targetPositionLocale - transform.position).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float angle = GetAngleFromVectorFloat(moveDir);
        transform.eulerAngles = new Vector3(0, 0, angle);

        if (Vector3.Distance(targetPositionLocale, transform.position) < destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    public void Create(Vector3 spawnPosition, Vector3 targetPosition)
    {
        Instantiate(pfProjectileArrow, spawnPosition, Quaternion.identity);
        targetPositionLocale = targetPosition;
        Debug.Log(targetPosition);
        Debug.Log(targetPositionLocale);
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle += 360;
        }
        return angle;
    }
}
