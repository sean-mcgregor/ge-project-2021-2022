using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public bool PlayerDead;//Determine PlayerDead in your health script
    private GameObject currentPlayer;
    public GameObject FirstPlayerModelPrefab;//Drag the initial player prefab in here
    public GameObject SecondPlayerModelPrefab;//Drag the second player prefab in here

    public GameObject Player;

    private bool wasDeadLastFrame = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerDead && !wasDeadLastFrame)
        {
            Destroy(FirstPlayerModelPrefab);
            currentPlayer = Instantiate(SecondPlayerModelPrefab, Player.transform.position, Quaternion.identity);
            currentPlayer.transform.SetParent(Player.transform);
        }

        wasDeadLastFrame = PlayerDead;
    }
}