using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinValue : MonoBehaviour
{
    public int value;
    public float rotateSpeed = 10;

    void Update(){
        transform.Rotate (new Vector3 (0, 1, 0) * Time.deltaTime * rotateSpeed);
    }

}
