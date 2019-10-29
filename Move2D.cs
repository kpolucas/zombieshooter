using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    [SerializeField]
    float PlayerSpeed = 6f;
        void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position += movement * PlayerSpeed * Time.deltaTime;


        // Poner en el lugar correct cuando tenga ganas, algun gameManager o algo similar
        EscToQuit();
    }



    void EscToQuit()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }
}
