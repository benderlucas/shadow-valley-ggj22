using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public bool sceneAliveActive = true;
    public GameObject[] AliveBob;
    public GameObject[] DeadBob;
    public GameObject PlayerGroup;
    public float lossLife;

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

        if (GetComponent<LifeSystem>().actualLife > 0 && !sceneAliveActive){
                GetComponent<LifeSystem>().actualLife = GetComponent<LifeSystem>().actualLife - lossLife * Time.deltaTime;
            }
    }

    void AliveBobActive(){
            PlayerGroup.GetComponent<Rigidbody>().isKinematic = false;
            PlayerGroup.GetComponent<Rigidbody>().useGravity = true;
            PlayerGroup.GetComponent<PlayerController>().jumpForce = 2.4f;
            foreach(GameObject obj in AliveBob) {
                obj.SetActive(true);
            }
            foreach(GameObject obj in DeadBob) {
                obj.SetActive(false);
            }
    }

    void DeadBobActive(){
        PlayerGroup.GetComponent<Rigidbody>().isKinematic = true;
        PlayerGroup.GetComponent<Rigidbody>().useGravity = false;
        PlayerGroup.GetComponent<PlayerController>().jumpForce = 0f;
        PlayerGroup.GetComponent<PlayerController>().isGrounded = false;
            foreach(GameObject obj in AliveBob) {
                obj.SetActive(false);
            }
            foreach(GameObject obj in DeadBob) {
                obj.SetActive(true);
            }
    }
}
