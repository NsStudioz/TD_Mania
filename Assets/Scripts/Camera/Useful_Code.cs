using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useful_Code : MonoBehaviour
{
    #region Camera_System:

    // Original Movement:
    /*        if (joyStick.Horizontal >= 0.2f)
            {
                transform.position += (transform.right * movementSpeed * Time.deltaTime);
            }
            else if (joyStick.Horizontal <= -0.2f)
            {
                transform.position += (transform.right * -movementSpeed * Time.deltaTime);
            }

            if (joyStick.Vertical >= 0.2f)
            {
                transform.position += (transform.forward * movementSpeed * Time.deltaTime);
            }
            else if (joyStick.Vertical <= -0.2f)
            {
                transform.position += (transform.forward * -movementSpeed * Time.deltaTime);
            }*/

    #endregion

    #region Enemy_Shield

    /*    private void CalculateRangeOfDeactivatedShield()
{
    if (!shieldOn)
    {
        rangeTimerDelay -= Time.deltaTime;

        if (rangeTimerDelay <= 0f)
            range = 0f;
    }
}*/

    #endregion

    #region WaveSpawner:

    /*countDown -= Time.deltaTime;

    countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);*/

    //waveCountDownText.text = string.Format("{0:00.00}", countDown); // convert to actual watch like, real world time format.
    #endregion

}
