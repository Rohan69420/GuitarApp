using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    //slider bool
    bool held = false;

    //string array
    string[] ParentStrings = new string[6];

    //add audiosources
    public AudioSource[] _audioSource = new AudioSource[6];

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return;

        UnityEngine.Debug.Log(rayHit.collider.gameObject.name);
        //UnityEngine.Debug.Log(transform.parent.rayHit.collider.gameObject);

        GameObject obj;

        obj = rayHit.collider.gameObject;

        var ParentGameObj = obj.transform.parent.gameObject;

        string ParentName = ParentGameObj.name;

        UnityEngine.Debug.Log(ParentName);


        //using a if else tree for comparison of string, maybe should use an array and a loop
        for (int i = 0; i < 6; i++) {
            if (ParentName.Equals(ParentStrings[i]))
            {
                //checking the object name to vary the pitch accordingly
                string objectName = obj.name;
                float pitch = 1;

                if (objectName.Equals("F")) pitch = 1 + 1 * 0.07f;
                else if (objectName.Equals("F#/Gb")) pitch = 1 + 2 * 0.07f;
                else if (objectName.Equals("G")) pitch = 1 + 3 * 0.07f;
                else if (objectName.Equals("G#/Ab")) pitch = 1 + 4 * 0.07f;
                else if (objectName.Equals("A")) pitch = 1 + 5 * 0.07f;
                else if (objectName.Equals("A#/Bb")) pitch = 1 + 6 * 0.07f;
                else if (objectName.Equals("B")) pitch = 1 + 7 * 0.07f;
                else if (objectName.Equals("C")) pitch = 1 + 8 * 0.07f;
                else if (objectName.Equals("C#/Db")) pitch = 1 + 9 * 0.07f;
                else if (objectName.Equals("D")) pitch = 1 + 10 * 0.07f;
                else if (objectName.Equals("D#/Eb")) pitch = 1 + 11 * 0.07f;
                else if (objectName.Equals("E")) pitch = 1 + 12 * 0.07f;
                else
                {
                    UnityEngine.Debug.Log("Out of test strings match!");
                }

                _audioSource[i].pitch = pitch;
                

                _audioSource[i].Play();
            }
        }


    }

    public void OnHold(InputAction.CallbackContext context)
    {
        //if (!context.started) return;

        //var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (context.started) UnityEngine.Debug.Log("Hold started!");

        UnityEngine.Debug.Log(context.duration.ToString());

        // if (!rayHit.collider) return;
        if (context.performed) {
            held = true;
            UnityEngine.Debug.Log("Holding");
        }



        if (context.canceled) {
            held = false;
            UnityEngine.Debug.Log("Released"); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //initialize all the parent strings; can be moved to 'public' for easily modification
        //but it wont be necessary
        ParentStrings[0] = "e";
        ParentStrings[1] = "B";
        ParentStrings[2] = "G";
        ParentStrings[3] = "D";
        ParentStrings[4] = "A";
        ParentStrings[5] = "E";

    }

    // Update is called once per frame
    void Update()
    {
        //constantly poll if hold is performed per every new frame
        if (held) 
        {
            UnityEngine.Debug.Log("Pitch polling");
            var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

            if (!rayHit.collider) return;

            UnityEngine.Debug.Log(rayHit.collider.gameObject.name);
            //UnityEngine.Debug.Log(transform.parent.rayHit.collider.gameObject);

            GameObject obj;

            obj = rayHit.collider.gameObject;

            var ParentGameObj = obj.transform.parent.gameObject;

            string ParentName = ParentGameObj.name;

            UnityEngine.Debug.Log(ParentName);


            //using a if else tree for comparison of string, maybe should use an array and a loop
            for (int i = 0; i < 6; i++)
            {
                if (ParentName.Equals(ParentStrings[i]))
                {
                    //checking the object name to vary the pitch accordingly
                    string objectName = obj.name;
                    float pitch = 1;

                    if (objectName.Equals("F")) pitch = 1 + 1 * 0.07f;
                    else if (objectName.Equals("F#/Gb")) pitch = 1 + 2 * 0.07f;
                    else if (objectName.Equals("G")) pitch = 1 + 3 * 0.07f;
                    else if (objectName.Equals("G#/Ab")) pitch = 1 + 4 * 0.07f;
                    else if (objectName.Equals("A")) pitch = 1 + 5 * 0.07f;
                    else if (objectName.Equals("A#/Bb")) pitch = 1 + 6 * 0.07f;
                    else if (objectName.Equals("B")) pitch = 1 + 7 * 0.07f;
                    else if (objectName.Equals("C")) pitch = 1 + 8 * 0.07f;
                    else if (objectName.Equals("C#/Db")) pitch = 1 + 9 * 0.07f;
                    else if (objectName.Equals("D")) pitch = 1 + 10 * 0.07f;
                    else if (objectName.Equals("D#/Eb")) pitch = 1 + 11 * 0.07f;
                    else if (objectName.Equals("E")) pitch = 1 + 12 * 0.07f;
                    else
                    {
                        UnityEngine.Debug.Log("Out of test strings match!");
                    }

                    _audioSource[i].pitch = pitch;
                }
            }

        }
        else
        {
            //reset the pitch back to original if slide and pull cancelled : not necessary
        }

    }
}
