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


    //constructManager.BuildDefUnitOn(this); // this = we pass in this node.


    #region Trash Code
    // Material Values
    //private static Material material;
    //private static Color greenColor = new Color32(7, 185, 0 , 255);
    //private static Color redColor = new Color32(192, 23, 0 , 255);


    //material.SetFloat("_NodeStartEFX", 0f);
    //Shader.SetGlobalColor("_NodeColor_Global", greenColor);

    //material = GetComponent<MeshRenderer>().material;
    //startColor = rend.material.color;


    /*    public static void OnTurretChoice_EnableNodeEffect()
        {
            //material.SetFloat("_NodeStartEFX", 1f);
            Shader.SetGlobalFloat("_NodeStartEFX", 1f);
        }
        public static void OnTurretUnchoice_DisableNodeEffect()
        {
            //material.SetFloat("_NodeStartEFX", 0f);
            Shader.SetGlobalFloat("_NodeStartEFX", 0f);
        }
        private void OnGoldAmount_SetNodeColorAndEffect()
        {
            if (PlayerStats.Gold >= PlayerStats.notEnoughGoldThreshold) { Shader.SetGlobalColor("_NodeColor_Global", greenColor); }

            else if (PlayerStats.Gold < PlayerStats.notEnoughGoldThreshold)
            {
                //material.SetColor("_NodeColor", redColor);
                //Shader.SetGlobalColor("_NodeColor_Global", redColor);
                OnTurretUnchoice_DisableNodeEffect();
            }
        }*/

    /*    public void UpgradeTurretOrDefUnit()
        {
            if (PlayerStats.Gold < d_Unit_Blueprint.upgradeCost)
            {
                Debug.Log("Not enough gold to upgrade that turret!");
                return;
            }

            PlayerStats.Gold -= d_Unit_Blueprint.upgradeCost;

            // destroy old turret:
            Destroy(defendingUnit);

            // build new upgraded turret:
            GameObject turret = Instantiate(d_Unit_Blueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
            defendingUnit = turret;

            // set in a temporary gameobject, so we can rid of it later on ingame.
            GameObject buildEFX = Instantiate(constructManager.buildEffects, GetBuildPosition(), Quaternion.identity);
            Destroy(buildEFX, 5f);

            isDefUnitUpgraded = true;

            Debug.Log("Turret Upgraded!");
        }*/

    /*    // Change Color:
        public static void OnTurretChoice_ChangeNodeColor_Green() // Enough Gold
        {
            material.SetColor("_Color", greenColor);
        }

        public static void OnTurretChoice_ChangeNodeColor_Red() //Not Enough Gold
        {
            material.SetColor("_Color", redColor);
        }*/

    #region Old Mouse Input
    // During this method it makes sure that we will only highlight the different nodes when we hover over them,
    // we will only do the hover animation when we actually have a turret to build.
    /*void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // if the mouse hovers a gameobject while on a UI Element (Panel in this case)
        {
            return;
        }

        if (!constructManager.CanBuild)
        {
            return;
        }

        if (constructManager.HasGold)
        {
            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notEnoughGoldColor;
        }
    }*/

    /*    void OnMouseExit()
        {
            rend.material.color = startColor;
        }*/

    #endregion

    #endregion


    /*        if (!target.isDefUnitUpgraded) // if not upgraded, set upgrade text. else set it to Maxed out.
        {
            upgradeCost.text = "$" + target.d_Unit_Blueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAXED";
            upgradeButton.interactable = false;
        }*/

    /*    public void UpgradeDefUnit()
{
    target.UpgradeTurretOrDefUnit();
    ConstructManager.instance.DeselectNode();
}*/

}
