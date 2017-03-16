using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{

    // Use this for initialization
    private Animation anim;
    public GameObject player;
    public int speed = 5;
    public int speedRotation = 3;
    public int jumpSpeed = 50;
    private Quaternion rotate = Quaternion.Euler(0, 0, 0);
    void Start()
    {
        anim = GetComponent<Animation>();
        player = (GameObject)this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += player.transform.forward * speed * Time.deltaTime;
            anim.CrossFade("loop_walk_funny");
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position -= player.transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(Vector3.down * speedRotation);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(Vector3.up * speedRotation);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.CrossFade("jump");
            //WaitForAnimation(anim);
            //player.transform.rotation = Quaternion.identity;
            StartCoroutine(WaitThenDoThings(anim["jump"].length));
        }
        if (!anim.isPlaying) {
            anim.CrossFade("loop_idle");
        }
        //{
        //    player.transform.rotation = Quaternion.identity;
        //}
        //WaitForAnimation(anim);

    }
    IEnumerator WaitThenDoThings(float time)
    {
        yield return new WaitForSeconds(time - 0.5f);

        // Now do some stuff...
        //animation.CrossFade("anotherAnim", 0.5f);

        //player.transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        player.transform.rotation = new Quaternion(0f, player.transform.eulerAngles.y, 0f, 0f);
        //Debug.Log("Stand method");
    }
}
