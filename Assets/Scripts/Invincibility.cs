using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupInvincibility : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _healthIncreaseAmount = 1;
    [SerializeField] float _powerupDuration = 5;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate = null;
    [SerializeField] AudioClip _invcSound = null;

    Collider _colliderToDeactivate = null;
    bool _poweredUp = false;

    private void Awake()
    {
        _colliderToDeactivate = GetComponent<Collider>();

        EnableObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player playerShip
            = other.gameObject.GetComponent<Player>();

        if (playerShip != null && _poweredUp == false)
        {
            StartCoroutine(PowerupSequence(playerShip));
            AudioHelper.PlayClip2D(_invcSound, 1);
        }
    }

    IEnumerator PowerupSequence(Player playerShip)
    {
        _poweredUp = true;

        ActivatePowerup(playerShip);

        DisableObject();

        yield return new WaitForSeconds(_powerupDuration);

        DeactivatePowerup(playerShip);
        EnableObject();

        _poweredUp = false;

    }

    void ActivatePowerup(Player playerShip)
    {
        if (playerShip != null)
        {
            playerShip.SetHealth(_healthIncreaseAmount);

            //playerShip.SetInvcBoosters(true);
        }
    }

    void DeactivatePowerup(Player playerShip)
    {


        playerShip?.SetHealth(-_healthIncreaseAmount);

        //playerShip?.SetInvcBoosters(false);

    }

    public void DisableObject()
    {
        _colliderToDeactivate.enabled = false;

        _visualsToDeactivate.SetActive(false);
    }

    public void EnableObject()
    {
        _colliderToDeactivate.enabled = true;

        _visualsToDeactivate.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}