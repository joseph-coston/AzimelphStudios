using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyBoost : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Percent accuracy increase on pickup")]
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

        var wepMan = player.GetComponent<PlayerWeaponsManager>(); //get the player weapon manager

        WeaponController temp = wepMan.getWeaponSlots()[0]; //the first weapon held

        //modify the first weapon
        temp.bulletSpreadAngle *= boostAmount; 
        temp.crosshairDataDefault.crosshairSize = (int)((double)temp.crosshairDataDefault.crosshairSize * boostAmount);





        if (wepMan)
        {
            //foreach (WeaponController wand in wepMan.getStartingWeapons())
            //{
            //    wand.setBulletSpreadAngle(wand.getBulletSpreadAngle() * boostAmount);
            //wand.getCrosshairDataDefault().setCrosshairSize((int)((float)wand.getCrosshairDataDefault().getCrosshairSize() * boostAmount));
            //}
            //wepMan.getStartingWeapons()[0].setBulletSpreadAngle(wepMan.getStartingWeapons()[0].getBulletSpreadAngle() * boostAmount);
        }

        m_Pickup.PlayPickupFeedback();
        Destroy(gameObject);
    }
}
