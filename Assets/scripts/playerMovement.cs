using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int currentKeySetUpNum = 0;
    // Start is called before the first frame update
    Dictionary<int, KeyCode[]> keymap = new Dictionary<int, KeyCode[]>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //*****************************UP,********RIGHT******DOWN*******LEFT 
        keymap[0] = new KeyCode[] { KeyCode.W, KeyCode.D, KeyCode.S, KeyCode.A };
        keymap[1] = new KeyCode[] { KeyCode.E, KeyCode.F, KeyCode.D, KeyCode.S };
        keymap[2] = new KeyCode[] { KeyCode.R, KeyCode.G, KeyCode.F, KeyCode.D };
        keymap[3] = new KeyCode[] { KeyCode.T, KeyCode.H, KeyCode.G, KeyCode.F };
        keymap[4] = new KeyCode[] { KeyCode.Y, KeyCode.J, KeyCode.H, KeyCode.G };
        keymap[5] = new KeyCode[] { KeyCode.U, KeyCode.K, KeyCode.J, KeyCode.H };
        keymap[6] = new KeyCode[] { KeyCode.I, KeyCode.L, KeyCode.K, KeyCode.J };
        keymap[7] = new KeyCode[] { KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.LeftArrow };
    }

    void keyPresses()
    {
        float horizontalForce = 0;
        float verticalForce = 0;

        if (Input.GetKey(keymap[currentKeySetUpNum][0]))
        {
            verticalForce += 1;
        }
        if (Input.GetKey(keymap[currentKeySetUpNum][1]))
        {
            horizontalForce += 1;
        }
        if (Input.GetKey(keymap[currentKeySetUpNum][2]))
        {
            verticalForce -= 1;
        }
        if (Input.GetKey(keymap[currentKeySetUpNum][3]))
        {
            horizontalForce -= 1;
        }

        rb.AddForce(new Vector3(horizontalForce, 0.0f, verticalForce));

        if (Input.GetKeyDown(KeyCode.C))
        {
            currentKeySetUpNum = (currentKeySetUpNum + 1) % keymap.Count;
            Debug.Log("new " + currentKeySetUpNum);

        }
        //}
    }

    // Update is called once per frame
    void Update()
    {

        keyPresses();
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    rb.AddForce(Vector3.up * 50);
        //}
        //var horizontal = Input.GetAxis("Horizontal");
        //var vertical = Input.GetAxis("Vertical");

        //var horizontal = Input.GetAxis("Horizontal");
        //var vertical = Input.GetAxis("Vertical");

        //Debug.Log(horizontal);
        //Debug.Log(vertical);


        //var movement = new Vector3(horizontal, 0.0f, vertical);



        //rb.AddForce(movement);
        ////Input.GetAxis()
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Ran");

        //    //rb.AddExplosionForce(100f, new Vector3(0, 40, 0), 30);
        //    //rb.AddForce(new Vector3(0, 40, 0), ForceMode.Impulse);
        //    //var movement = new Vector3(horizontal, 0.0f, vertical);
        //    rb.AddForce(movement);

        //}
    }
}
