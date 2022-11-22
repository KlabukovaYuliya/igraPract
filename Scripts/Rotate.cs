using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(new Vector3(30, 35, 40) * Time.deltaTime);
    }
}
