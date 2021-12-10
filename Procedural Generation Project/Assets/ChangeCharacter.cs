using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ChangeCharacter : MonoBehaviour
{
    public bool onWater; //Determine if player on water
    private GameObject currentModel;
    public GameObject FirstPlayerModelPrefab; //Drag the initial player prefab in here
    public GameObject SecondPlayerModelPrefab; //Drag the second player prefab in here
    public GameObject Player;
    public AudioSource PoofSound;
    public VisualEffect TrainPoof;

    private bool onWaterLastFrame = false;

    private void Start() {
        
        currentModel = Player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y > 3.59)
        {
           
            onWater = false;
        } else {

            onWater = true;
        }

        TrainPoof.transform.position = Player.transform.position;

        if (onWater && !onWaterLastFrame)
        {
            TrainPoof.Play();
            PoofSound.Play();
            Vector3 rotation = new Vector3(0, Player.transform.localRotation.eulerAngles.y, 0);
            Destroy(currentModel);
            currentModel = Instantiate(SecondPlayerModelPrefab, Player.transform.position, Quaternion.Euler(rotation));
            currentModel.transform.SetParent(Player.transform);
        }
        else if (!onWater && onWaterLastFrame)
        {
            TrainPoof.Play();
            PoofSound.Play();
            Vector3 rotation = new Vector3(0, Player.transform.localRotation.eulerAngles.y, 0);
            TrainPoof = Instantiate(TrainPoof, Player.transform.position, Quaternion.Euler(rotation));
            Destroy(currentModel);
            currentModel = Instantiate(FirstPlayerModelPrefab, Player.transform.position, Quaternion.Euler(rotation));
            currentModel.transform.SetParent(Player.transform);

        }
        
        onWaterLastFrame = onWater;
    }
}