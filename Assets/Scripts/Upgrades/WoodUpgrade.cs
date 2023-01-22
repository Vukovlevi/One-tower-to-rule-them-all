using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WoodUpgrade : MonoBehaviour
{
    public GameObject UI;
    private bool UIActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (!UIActive)
        {
            UI.SetActive(true);
            UIActive = true;
        }
        else
        {
            UI.SetActive(false);
            UIActive = false;
        }
    }
}
