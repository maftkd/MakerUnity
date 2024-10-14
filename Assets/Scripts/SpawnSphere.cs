using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphere : MonoBehaviour
{
    public GameObject redSphere;
    public GameObject blueSphere;
    public GameObject greenSphere;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnRedSphere();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBlueSphere();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnGreenSphere();
        }
    }

    void SpawnRedSphere()
    {
        Vector3 positionOffset = new Vector3(1, 1, 1);
        Instantiate(redSphere, transform.position + positionOffset, Quaternion.identity);
    }

    void SpawnBlueSphere()
    {
        Vector3 positionOffset = new Vector3(1, 1, 1);
        Instantiate(blueSphere, transform.position + positionOffset, Quaternion.identity);
    }

    void SpawnGreenSphere()
    {
        Vector3 positionOffset = new Vector3(1, 1, 1);
        Instantiate(greenSphere, transform.position + positionOffset, Quaternion.identity);
    }
}
