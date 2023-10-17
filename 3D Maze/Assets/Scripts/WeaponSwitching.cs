using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public static int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        
        //Default Handgun
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        //AR Gun (found in parkour section of level 1)
        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            if(ARCollectionDetector.ARUnlocked == true)
            {
                selectedWeapon = 1;
            }
        }
        else return;

        SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
