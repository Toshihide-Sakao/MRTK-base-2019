using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Text text;
    public Text text2;
    GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "got hit: " + spawner.GetComponent<Spawner>().hits + " times";
        text2.text = "destroyed " + spawner.GetComponent<Spawner>().destroyed + " ballons";
    }
}
