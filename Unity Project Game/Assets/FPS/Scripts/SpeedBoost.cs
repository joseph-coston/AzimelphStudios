using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Percent speed increase on pickup")]
    public float boostAmount = 1.2f;

    [Tooltip("Prefab for the game message")]
    public GameObject messagePrefab;

    Pickup m_Pickup;


    void Start()
    {

        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        //notify player of action
        var message = Instantiate(messagePrefab).GetComponent<DisplayMessage>();
        if (message)
        {
            message.delayBeforeShowing = 0.5f;
            message.GetComponent<Transform>().SetAsLastSibling();
        }

        //increase speed by boost amount
        player.changeSpeed(boostAmount);
        Destroy(gameObject);
    }
}
