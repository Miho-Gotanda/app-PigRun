using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private float jumpForce = 300.0f;
    private Animator animator;
    private bool jump = true;
    private float walkForce = 25.0f;
    private float macSpeed = 5.3f;

   
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.rigid2D.velocity = Vector3.zero;
       
    }

    // Update is called once per frame
    void Update()
    {
         
        //ジャンプ
        if (Input.GetMouseButtonDown(0) && !jump)
        {
            jump = true;
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            this.animator.SetTrigger("JumpTrigger");
           
        }
         

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if (speedx < this.macSpeed)
        {
            this.rigid2D.AddForce(transform.right * this.walkForce);
        }


        if (this.transform.position.y < -3.2f)
        {
          
            this.animator.SetBool("StopBool", true);
            this.animator.SetBool("RunBool", false);
            jump = true;
        }
        

    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="BackGround")
        {
            jump = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadArea")
        {
            SceneManager.LoadScene("DeadScene");
           
        }
       
    }
   

    

   


}
