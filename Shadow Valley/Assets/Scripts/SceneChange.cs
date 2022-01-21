using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public bool sceneAliveActive = true;
    public GameObject Scene1;
    public GameObject Scene2;
    public GameObject Bob;
    public GameObject ShadowBob;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            sceneAliveActive = !sceneAliveActive;
        }

        if (sceneAliveActive){
            Scene1.SetActive(true);
            Scene2.SetActive(false);
            Bob.SetActive(true);
            ShadowBob.SetActive(false);
        } else {
            Scene1.SetActive(false);
            Scene2.SetActive(true);
            Bob.SetActive(false);
            ShadowBob.SetActive(true);
        }
    }
}
