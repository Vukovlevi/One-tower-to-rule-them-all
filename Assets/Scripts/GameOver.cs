using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public int clicks = 0;
    public int timeToClick = 30;
    public float timeSinceLastClick = 0;
    public Camera mainCamera;
    private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (timeSinceLastClick > 0)
        {
            timeSinceLastClick -= Time.deltaTime;
        } else
        {
            timeSinceLastClick = 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            gameOver();
        }
    }

    public void OnMouseDown()
    {
        if (timeSinceLastClick > 0)
        {
            clicks++;
            if (clicks == 15)
            {
                StartCoroutine(showSecret());
            }
        } else
        {
            clicks++;
            timeSinceLastClick = timeToClick;
        }
    }

    IEnumerator showSecret()
    {
        mainCamera.GetComponent<CameraController>().enableSecret();
        clicks = 0;
        Vector3 currentPosition = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(-37.85f, 18.26f, -10);
        yield return new WaitForSeconds(1);
        mainCamera.transform.position = currentPosition;
        mainCamera.GetComponent<CameraController>().disableSecret();
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
