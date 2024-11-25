using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gamemovement : MonoBehaviour
{
    public float deg = 0f;
    public float angleInc = 0.5f;
    public float timer = 0f;
    public bool stoptregar = false;
    public bool slowlytregar = false;
    public GameObject[] lambslight;
    public float intensityInc = 3f;
    void Start()
    {
        foreach (GameObject lamb in lambslight)
        {
            lamb.GetComponent<Light>().intensity = 0f;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            deg = deg + angleInc;
            timer += Time.deltaTime;
            transform.localRotation = Quaternion.Euler(new Vector3(deg, 0, 0));
            if (!stoptregar)
            {
                if (timer >= 2f)
                {
                    foreach (GameObject lamb in lambslight)
                    {
                        lamb.GetComponent<Light>().intensity += intensityInc;

                    }
                    angleInc += 0.5f;
                    timer = 0;

                    if (angleInc >= 3.5)
                    {
                        stoptregar = true;

                    }

                }
                slowlytregar = true;
            }
        }
        else
        {

            if (slowlytregar)
            {
                deg = deg + angleInc;
                timer += Time.deltaTime;
                if (timer >= 2f)
                {
                    angleInc -= 0.25f;
                    foreach (GameObject lamb in lambslight)
                    {
                        if (lamb.GetComponent<Light>().intensity <= 13)
                        {
                            lamb.GetComponent<Light>().intensity--;
                        }
                        else
                        {
                            lamb.GetComponent<Light>().intensity -= intensityInc;
                        }

                    }
                    timer = 0;
                    if (angleInc <= 0.175f)
                    {
                        slowlytregar = false;
                        stoptregar = false;
                        transform.localRotation = Quaternion.Euler(new Vector3(deg, 0, 0));
                        foreach (GameObject lamb in lambslight)
                        {
                            lamb.GetComponent<Light>().intensity = 0f;
                        }
                        angleInc = 0.5f;
                    }

                }
                transform.localRotation = Quaternion.Euler(new Vector3(deg, 0, 0));
            }


        }


    }
}
