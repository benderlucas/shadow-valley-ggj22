using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    Vector3 jump;
    public float jumpForce;
    public bool isGrounded;
    public bool hasStairs;
    public GameObject stairsTrigger;
    public GameObject stairs;
    Rigidbody rb;
    public Animator anim;
    public GameObject Controller;
    public GameObject ItemsPanel;
    public float TimeToDie;

    void Start(){
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, jumpForce, 0);
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Coin"){
            Controller.GetComponent<MoneySystem>().actualMoney = Controller.GetComponent<MoneySystem>().actualMoney + col.GetComponent<CoinValue>().value;
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Collectable"){
            GameObject NewIcon = new GameObject();
            Image NewImage = NewIcon.AddComponent<Image>();
            NewImage.sprite = col.GetComponent<Image>().sprite;
            NewIcon.GetComponent<RectTransform>().SetParent(ItemsPanel.transform);
            NewIcon.name = col.name;
            NewIcon.SetActive(true); 
            Destroy(col.gameObject);
            if(col.gameObject.name == "Escada"){
                hasStairs = true;
            }
        }
    }

    private void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Trigger"){
            col.transform.Find("HelpText").gameObject.SetActive(false);
        }
    }

    void OnTriggerStay(Collider col){
        if(col.gameObject.tag == "Trigger"){
            col.transform.Find("HelpText").gameObject.SetActive(true);
            }
            
            if(col.gameObject.name == "TriggerStairs" && hasStairs){
                col.transform.Find("HelpText").gameObject.GetComponent<TMPro.TextMeshPro>().text = "Press 'E' to put the stairs";
                if(Input.GetKey(KeyCode.E)){
                    stairs.SetActive(true);
                    if(stairs.active = true){
                        col.gameObject.SetActive(false);
                    }
                }
            }
    }
    

    void OnCollisionStay(Collision col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = true;
        }
        
    }

    void OnCollisionExit(Collision col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Jump();
        }

        if(Controller.GetComponent<SceneChange>().sceneAliveActive){
            if(!isGrounded){
                Controller.GetComponent<GameStates>().Invoke("GameOver", TimeToDie);
            } else {
            Controller.GetComponent<GameStates>().CancelInvoke("GameOver");
        } 
        }
    }

    void FixedUpdate()
    {

        anim = GetComponentInChildren<Animator>();

        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, 0);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }

        if(horizontalInput == 0){
            anim.SetBool("isWalking",false);
        } else {
            anim.SetBool("isWalking",true);
        }
    }

    void Jump(){
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        anim.SetTrigger("isJumping");
    }
}
