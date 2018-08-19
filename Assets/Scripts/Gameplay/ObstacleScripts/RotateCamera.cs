using UnityEngine;

public class RotateCamera : ActivatableBehaviour 
{
    public new Transform camera;
    public bool wentHalfRound = false;
    
    public float rotationSpeed = 5f;

    protected override void OnActivate()
    {
        wentHalfRound = false;
    }

    protected override void OnUpdateActive ()
    {
        Debug.Log(camera.transform.rotation);
        if(Input.GetAxis ("Horizontal") > 0)
		{
            camera.transform.Rotate(0, 0, - rotationSpeed);
		}
        else if(Input.GetAxis ("Horizontal") < 0)
        {
            camera.transform.Rotate(0, 0, rotationSpeed);
        }
        else
        {
            camera.transform.Rotate(0, 0, 0);
        }

        //STOP ROTATION IF PLAYER WENT HALF WAY
        if(camera.transform.rotation == new Quaternion(0,0, -1, 0) || camera.transform.rotation == new Quaternion(0,0, 1, 0))
        {
            wentHalfRound = true;
        }

        if(wentHalfRound && (camera.transform.rotation == new Quaternion(0, 0, 0, 1) || camera.transform.rotation == new Quaternion(0, 0, 0, -1)))
        {
            Deactivate();
        }
        
    }


}
