using UnityEngine;

public class ShootTypes : ShootLimittPlayer
{
    
    public KeyCode gum1, gum2, gum3;


    
    public int shootType = 1;
    [SerializeField]
    private int shootAmont = 1;
    [SerializeField]
    private float angle = 0f;

   


    


    protected override void keysUpdate()
    {
        base.keysUpdate();
        if (Input.GetKeyDown(gum1))
        {
            shootType = 1;
            shootAmont = 1;
            angle = 0f;
            maxShoot = 100;
            currentShoot = 0;

        }
        else if (Input.GetKeyDown(gum2))
        {
            shootType = 2;
            shootAmont = 2;
            angle = 15f;
            maxShoot = 10;
            currentShoot = 0;
        }
        else if (Input.GetKeyDown(gum3))
        {
            shootType = 3;
            shootAmont = 4;
            angle = 15f;
            maxShoot = 5;
            currentShoot = 0;
        }
    }



    protected override void shoot()
    {


        currentShoot++;
        if (currentShoot >= maxShoot)
        {

            CancelInvoke();
            Invoke("FullRecharge", timeCharge);

        }
        else
        {
            int mult = 0;
            for (int i = 0; i < shootAmont; i++)
            {
               
                if (i % 2 == 0) mult++;


                GameObject ball = Instantiate(projectil, localGum.transform);
                ball.GetComponent<ProjectileBase>().targetTag = targetTag;

                ball.transform.localPosition = Vector3.zero;
                ball.transform.position = localGum.transform.position;
                ball.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;
                ball.transform.parent = null;
            }

            //GameObject bala = Instantiate(gum, pos, localGum.transform.rotation);

        }







        
    }


}
