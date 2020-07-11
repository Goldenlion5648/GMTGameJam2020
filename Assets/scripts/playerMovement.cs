using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int currentKeySetUpNum = 0;
    public RectTransform rectangle;
    private float energyStartHeight = 0;
    private float startingEnergy = 100;
    private float energyUsed = 0;
    private float moveCost = .1f;
    private bool isActivePlayer = false;


    // Start is called before the first frame update
    Dictionary<int, KeyCode[]> keymap = new Dictionary<int, KeyCode[]>();
    void Start()
    {
        if (transform.name == "Player1")
        {
            isActivePlayer = true;
        }
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

        energyStartHeight = rectangle.sizeDelta.y;
    }

    void keyPresses()
    {
        float horizontalForce = 0;
        float verticalForce = 0;

        if (hasEnergyLeft() && Input.GetKey(keymap[currentKeySetUpNum][0]))
        {
            energyUsed += moveCost;
            verticalForce += 1;
        }
        if (hasEnergyLeft() && Input.GetKey(keymap[currentKeySetUpNum][1]))
        {
            energyUsed += moveCost;
            horizontalForce += 1;
        }
        if (hasEnergyLeft() && Input.GetKey(keymap[currentKeySetUpNum][2]))
        {
            energyUsed += moveCost;
            verticalForce -= 1;
        }
        if (hasEnergyLeft() && Input.GetKey(keymap[currentKeySetUpNum][3]))
        {
            energyUsed += moveCost;
            horizontalForce -= 1;
        }


        rb.AddForce(new Vector3(horizontalForce, 0.0f, verticalForce));
        updateEnergyBar();
    }

    bool hasEnergyLeft()
    {
        if (energyUsed < startingEnergy)
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
            updateEnergyBar();

        }
    }


    void launchUp()
    {
        rb.AddForce(new Vector3(0.0f, 180.0f, 0.0f));
    }

    void updateEnergyBar()
    {
        rectangle.sizeDelta = new Vector2(rectangle.sizeDelta.x, energyStartHeight * ((startingEnergy - energyUsed) / startingEnergy));

    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivePlayer)
            return;
        keyPresses();
        debugKeyPresses();
    }
}
