using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class ShotScript : MonoBehaviour, IMixedRealityPointerHandler, IMixedRealityFocusHandler
{
    UnityEngine.Color ok = UnityEngine.Color.red;
    GameObject cam;
    GameObject spawner;
    public float shotSpeed = 1f;
    Vector3 targetPos;
    public bool Hit;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        spawner = GameObject.Find("Spawner");
        targetPos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TowardPlayer();
        CheckHit();
    }

    void TowardPlayer()
    {
        if (this.transform.position == targetPos)
        {
            Destroy(this.gameObject);
        }

        float step = shotSpeed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, step);
    }

    void CheckHit()
    {
        float hitboxSize = 0.1f;
        bool xSame = this.transform.position.x + hitboxSize >= cam.transform.position.x && this.transform.position.x - hitboxSize <= cam.transform.position.x;
        bool zSame = this.transform.position.z + hitboxSize >= cam.transform.position.z && this.transform.position.z - hitboxSize <= cam.transform.position.z;
        bool ySame = this.transform.position.y + hitboxSize >= cam.transform.position.y && this.transform.position.y - hitboxSize <= cam.transform.position.y;

        if (xSame && ySame && zSame)
        {
            spawner.GetComponent<Spawner>().hits++;
            Hit = true;
            Debug.Log("gameover");
            Destroy(this.gameObject);
        }
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        // Debug.Log("FocusEnter");
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        // Debug.Log("FocusExit");
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        spawner.GetComponent<Spawner>().destroyed++;
        Debug.Log("destroyed");
        Destroy(this.gameObject);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        // Debug.Log("PointerDown");
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        // Debug.Log("PointerDragged");
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        // Debug.Log("PointerUp");
    }
}
