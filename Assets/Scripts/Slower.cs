using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float _speedAmount = 3;
    public bool isSlow = false;
    protected override void PlayerImpact(Player player)
    {
        //pull motor controller from player
        TankController controller = player.GetComponent<TankController>();
        if (controller != null && isSlow == false)
        {
            controller.MaxSpeed -= _speedAmount;
            isSlow = true;
        }
    }

    
}
