using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class Spawner : MonoBehaviour, IMixedRealityPointerHandler, IMixedRealityFocusHandler
{
    float spawnDistance = 10;
    int maxShots = 3;
    public GameObject shot;
    Vector2 shotOffset = new Vector2(0.1f, 1f);
    float shotTimer;
    List<GameObject> shots = new List<GameObject>();
    public int hits = 0;
    public int destroyed;

    // Start is called before the first frame update
    void Start()
    {
        shotTimer = UnityEngine.Random.Range(shotOffset.x, shotOffset.y);
        hits = 0;
        destroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer < 0.0f)
        {
            GameObject newObj = Instantiate(shot);
            newObj.transform.position = GetRandomPosFromCenter();
            shots.Add(newObj);

            shotTimer = UnityEngine.Random.Range(shotOffset.x, shotOffset.y);
        }
    }

    Vector3 GetRandomPosFromCenter()
    {
        // x2 + y2 + z2 = c2
        // c2 = 30(2)
        float randX = UnityEngine.Random.Range(0f, spawnDistance);
        float randZ = (float)Math.Pow(Math.Pow(spawnDistance, 2) - Math.Pow(randX, 2), 0.5f);

        return new Vector3(randX, 0, randZ);
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
