using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
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
                _audioSource[i].Play();
            }
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
        
    }
}
