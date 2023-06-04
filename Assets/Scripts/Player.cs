using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public float releaseTime=0.15f;
    public float maxDragDistance=2f;
    public GameObject nextBirdPrefab;
    private bool isPressed=false;
    public int playersleft=0;
    public bool lastPlayer=false;


    public Animator Anim;
    public AnimationClip AngryAnim;
    public AnimationClip DeadAnim; //landed anim

    private void Start()
    {
        lastPlayer=false;
    }
    


    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            Vector2 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position=hook.position+(mousePos-hook.position).normalized*maxDragDistance;
            }
            else{
                rb.position=mousePos;
            }
        }
        
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed=false;
        rb.isKinematic=false;
        StartCoroutine(Release());
        if(Anim != null)
        {
            Anim.Play(AngryAnim.name);
            
        }


    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);


        GetComponent<SpringJoint2D>().enabled=false;
        this.enabled=false;

        //ToDo nächsten Vogel anlegen
        yield return new WaitForSeconds(2.0f);
        if(nextBirdPrefab != null)
        {
            nextBirdPrefab.SetActive(true);
        }
        else
        {
            lastPlayer = true;

        }
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(RemoveBird());
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(Anim !=null)
        {
            Anim.Play(DeadAnim.name);
            StartCoroutine(RemoveBird());
        }
    }

    IEnumerator RemoveBird()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
        if(lastPlayer)
        {
            if(GameManager.GM==null)
            {
               // return;
            }
            else if(GameManager.GM.EndingScreen.activeSelf==true)
            {
                //nichts
            }
            else
            {
                GameManager.GM.GameOver=true;
            }
        }
    }
}
