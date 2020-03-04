using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    bool door1Open = false;
    Animator anim1;
    Animator anim2;

    void Start()
    {
        anim1 = door1.GetComponent<Animator>();
        anim2 = door2.GetComponent<Animator>();
    }

    public void Use()
    {

        if (door1Open == false)
        {
            anim1.Play("Door1Open");
            anim2.Play("Door2Close");
            door1Open = true;
        }
        else
        {
            anim1.Play("Door1Close");
            anim2.Play("Door2Open");
            door1Open = false;
        }
    }
}
