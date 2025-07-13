using UnityEngine;

public class ShootLimittPlayer : GumBase
{
    public int maxShoot = 5;
    public float timeCharge = 1f;

    public float currentShoot = 0;
    private bool recharge = false;

    protected virtual void Shoot()
    {
        
        currentShoot++;
        if(currentShoot >= maxShoot)
        {

            CancelInvoke();
            Invoke("FullRecharge", timeCharge);

        }
        else
        {
            base.shoot();
            
        }

        Debug.Log("SootlimittPlayer");
    }


    public void FullRecharge()
    {
        currentShoot = 0;
    }


    


}
