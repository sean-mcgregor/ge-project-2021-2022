using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ChangeCharacter : MonoBehaviour
{
    public bool onWater;                        // Determine if player on water
    private bool onWaterLastFrame = false;      // Used to check whether the player is newly on water or was already on water previously
    private GameObject currentModel;            // The prefab of the form the player is currently taking
    public GameObject trainModel;               // Drag the train model prefab in here
    public GameObject boatModel;                // Drag the boat model prefab in here
    public GameObject Player;                   // Drag the player Object and character controls etc in here
    public AudioSource transitionSound;         // Audio source for transition between prefabs
    public VisualEffect transitionVisualPoof;   // Visual effect for transition between prefabs


    // Start is called once when Play is pressed
    private void Start()
    {
        // This gets the player model, which at the beginning is the train
        currentModel = Player.transform.GetChild(0).gameObject;
    }


    // Update is called once per frame
    void Update()
    {
        // Checking if player is on water, by analysing player height
        if(Player.transform.position.y > 0.38)
        {
           
            onWater = false;
        } else {

            onWater = true;
        }

        // Moves the object which plays the visual poof transition effect to the location of the player
        transitionVisualPoof.transform.position = Player.transform.position;

        // Checks if the player if newly on water
        if (onWater && !onWaterLastFrame)
        {
            switchCharacter(boatModel);
        }
        // Checks if the player is newly on land
        else if (!onWater && onWaterLastFrame)
        {
            switchCharacter(trainModel);
        }
        
        onWaterLastFrame = onWater;
    }

    // Changes from currentModel to the model which is passed in
    void switchCharacter(GameObject nextCharacter)
    {
        transitionVisualPoof.Play();    // Playing the visual playermodel transition effect
        transitionSound.Play();         // Playing the audio for transition effect
        
        // Gets the direction which the player is currently facing
        Vector3 rotation = new Vector3(0, Player.transform.localRotation.eulerAngles.y, 0);
        
        Destroy(currentModel); // Destroying the current player model

        // Instantiating the new player model using the location and look rotation of the player 
        currentModel = Instantiate(nextCharacter, Player.transform.position, Quaternion.Euler(rotation));

        // Setting the new player model as a child of the Player object,
        // so that it moves and responds to user input
        currentModel.transform.SetParent(Player.transform);
    }
}