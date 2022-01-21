using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public bool sceneAliveActive = true;
    public GameObject[] AliveBob;
    public GameObject[] DeadBob;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            sceneAliveActive = !sceneAliveActive;
            GetComponent<LifeSystem>().actualLife = GetComponent<LifeSystem>().actualLife - Random.Range(3,8);
        }

        if (sceneAliveActive){
            AliveBobActive();
        } else {
            DeadBobActive();
        }
    }

    void AliveBobActive(){
            foreach(GameObject obj in AliveBob) {
                obj.SetActive(true);
            }
            foreach(GameObject obj in DeadBob) {
                obj.SetActive(false);
            }
    }

    void DeadBobActive(){
            foreach(GameObject obj in AliveBob) {
                obj.SetActive(false);
            }
            foreach(GameObject obj in DeadBob) {
                obj.SetActive(true);
            }
    }
}
