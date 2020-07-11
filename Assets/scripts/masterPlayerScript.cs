using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterPlayerScript : MonoBehaviour
{

    //public static int activePlayerNum = 1;
    private static float energyStartHeight = 0;
    public static float startingEnergy = 1000;
    public static float energyUsed = 0;


    public int dummy = 0;


    public RectTransform rectangle;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("changeActivePlayer", 3, 3);
        GameObject.Find("Player1").GetComponent<playerMovement>().isActivePlayer = true;
        energyStartHeight = rectangle.sizeDelta.y;

    }

    public void updateEnergyBar()
    {

        rectangle.sizeDelta = new Vector2(rectangle.sizeDelta.x, energyStartHeight * ((startingEnergy - energyUsed) / startingEnergy));

    }

    // Update is called once per frame
    void Update()
    {

    }
    //void changeActivePlayer()
    //{
    //    activePlayerNum = ((activePlayerNum + 1) % 3) + 1;
    //    Debug.Log("updated counter to " + activePlayerNum);

    //    Debug.Log("searching for: " + "Player" + activePlayerNum);

    //    cameraPositioning.player = GameObject.Find("Player" + activePlayerNum);

    //}
}
