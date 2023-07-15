using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;

    Rigidbody blade_rb;

    private void Awake()
    {
        blade_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }

    }

    void UpdateCut()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        blade_rb.position = temp + new Vector3(0f, 0f, 10f);
    }

    private void StartCutting()
    {
        isCutting = true;
    }

    private void StopCutting()
    {
        isCutting = false;
    }
}
