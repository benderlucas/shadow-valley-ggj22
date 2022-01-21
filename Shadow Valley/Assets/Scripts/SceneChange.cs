using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public bool sceneAliveActive = true;
    public GameObject[] AliveBob;
    public GameObject[] DeadBob;
    public GameObject Life;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            sceneAliveActive = !sceneAliveActive;
            Life.GetComponent<LifeSystem>().actualLife = Life.GetComponent<LifeSystem>().actualLife - 5;
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
