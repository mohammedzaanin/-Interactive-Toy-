using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 10;
        string name = "Mohammed Alzaanin";
        Debug.Log(x+10);
        Debug.Log(name);
        Debug.LogWarning("My name is: " + name);
        Debug.LogError("10 + 10 = 5 not true the correct answer = " +(x+10));
    }

}
