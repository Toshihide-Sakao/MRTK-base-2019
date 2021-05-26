using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class EnemyCharacter : MonoBehaviour, IMixedRealityPointerHandler, IMixedRealityFocusHandler
{
    UnityEngine.Color ok = UnityEngine.Color.red;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        // Debug.Log("Click");
        var cubeRenderer = this.GetComponent<Renderer>();

        var bruh = transform.position;
        bruh.z += 1;
        transform.position = bruh;

        if (cubeRenderer.material.GetColor("_Color").r < 1.0f)
        {
            ok.r += 0.2f;
            Debug.Log(ok.r);
            cubeRenderer.material.SetColor("_Color", ok);
        }
        else
        {
            ok.r = 0f;
            Debug.Log(ok.r);
            cubeRenderer.material.SetColor("_Color", ok);
        }
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
