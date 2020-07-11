using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int currentKeySetUpNum = 0;
    public static float moveCost = .1f;


    public bool isActivePlayer = false;

    SphereCollider thisCollider;

    GameObject[] allPlayers;

    public static float playerSwapCooldown = 0.0f;

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



        thisCollider = GetComponent<SphereCollider>();
        allPlayers = GameObject.FindGameObjectsWithTag("Player");

        InvokeRepeating("cooldownUpdater", .1f, .1f);

    }

    void keyPresses()
    {
        float horizontalForce = 0;
        float verticalForce = 0;

        if (hasEnergyLeft() && Input.GetKey(keymap[currentKeySetUpNum][0]))
        {
            masterPlayerScript.energyUsed += moveCost;
            verticalForce += 1;
        }
        if (hasEnergyLeft() && Input.GetKey(keymap[currentKeySetUpNum][1]))
        {
            masterPlayerScript.energyUsed += moveCost;
            horizontalForce += 1;
        }
        if (hasEnergyLeft() && Input.GetKey(keymap[currentKeySetUpNum][2]))
        {
            masterPlayerScript.energyUsed += moveCost;
            verticalForce -= 1;
        }
        if (hasEnergyLeft() && Input.GetKey(keymap[currentKeySetUpNum][3]))
        {
            masterPlayerScript.energyUsed += moveCost;
            horizontalForce -= 1;
        }


        rb.AddForce(new Vector3(horizontalForce, 0.0f, verticalForce));
        GameObject.Find("PlayerHolder").GetComponent<masterPlayerScript>().updateEnergyBar();

    }

    bool hasEnergyLeft()
    {
        if (masterPlayerScript.energyUsed < masterPlayerScript.startingEnergy)
        {
            return true;
        }
        return false;
    }

    void debugKeyPresses()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentKeySetUpNum = (currentKeySetUpNum + 1) % keymap.Count;
            Debug.Log("new " + currentKeySetUpNum);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            launchUp();
            Debug.Log("launched up");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject.Find("PlayerHolder").GetComponent<masterPlayerScript>().updateEnergyBar();

        }
    }

    void cooldownUpdater()
    {
        playerSwapCooldown = Mathf.Max(0.0f, playerSwapCooldown - .1f);
        Debug.Log("current cooldown: " + playerSwapCooldown);


    }

    //void checkHittingOtherPlayer()
    //{
    //    if (playerSwapCooldown > 0.0f)
    //        return;
    //    //foreach (var a in allPlayers)
    //    //{
    //    //    if (thisCollider. (a.GetComponent<Collider2D>()))
    //    //    {
    //    //        a.GetComponent<playerMovement>().isActivePlayer = true;
    //    //        isActivePlayer = false;
    //    //        playerSwapCooldown += 3;
    //    //        break;
    //    //    }
    //    //}

    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if (playerSwapCooldown < 0.1f && collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerMovement>().isActivePlayer = true;
            isActivePlayer = false;
            playerSwapCooldown += 3;

            cameraPositioning.player = collision.gameObject;
            Debug.Log("CHANGED");

        }

    }


    void launchUp()
    {
        rb.AddForce(new Vector3(0.0f, 180.0f, 0.0f));
    }


    // Update is called once per frame
    void Update()
    {
        //if (!(transform.name.Contains(masterPlayerScript.activePlayerNum.ToString())))
        //    return;
        if (!isActivePlayer)
            return;
        keyPresses();
        //checkHittingOtherPlayer();
        debugKeyPresses();
    }
}
