using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class Spawner : MonoBehaviour, IMixedRealityPointerHandler, IMixedRealityFocusHandler
{
    float spawnDistance = 30;
    int maxShots = 3;
    public GameObject shot;
    float shotSpeed = 3;
    Vector2 shotOffset = new Vector2(0.1f, 1f); 
    float shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        shotTimer = UnityEngine.Random.Range(shotOffset.x, shotOffset.y);
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer < 0.0f)
        {
            GameObject newObj = Instantiate(shot);
            newObj.transform.position = GetRandomPosFromCenter();

            shotTimer = UnityEngine.Random.Range(shotOffset.x, shotOffset.y);  
        }
    }

    Vector3 GetRandomPosFromCenter()
    {
        // x2 + y2 + z2 = c2
        // c2 = 30(2)
        float randX = UnityEngine.Random.Range(0f, spawnDistance);
        float randY = Math.Pow(spawnDistance, 2) - Math.Pow(randX, 2);

        return new Vector3(randX, randY, 0);
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        Debug.Log("FocusEnter");
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        Debug.Log("FocusExit");
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        Debug.Log("Click");
        Destroy(this.gameObject);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        Debug.Log("PointerDown");
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        Debug.Log("PointerDragged");
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        Debug.Log("PointerUp");
    }
}
