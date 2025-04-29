using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // تحقق من وجود Instance و currentTarget
            if (LocationManager.Instance != null && LocationManager.Instance.currentTarget != null)
            {
                LocationManager.Instance.LocationTriggered(this.gameObject);
            }
            else
            {
                Debug.LogError("LocationManager.Instance or currentTarget is null!");
            }
        }
    }
}