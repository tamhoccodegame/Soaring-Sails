using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Weapon1 : MonoBehaviour
{

    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;

    private PlayerControls playerControls;
    private ActiveWeapon activeWeapon;
    private PlayerController1 playerController;
    [SerializeField] private Transform weaponCollider;

    public SpriteRenderer SlashRenderer;

    private GameObject slashAnim;
    

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController1>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        playerControls = new PlayerControls();
    }
    void Start()
    {

    }

    private void OnEnable()
    {
        if (playerControls != null)
        {
            playerControls.Enable();
        }
    }
    void Update()
    {
        MouseFollowWithOffset();
        FlipAmim();
    }


    public void Atk()
    {
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;

    }
    public void Attack()
    {

        Atk();
    }

    private void FlipAmim()
    {
        if (activeWeapon.transform.rotation.y == 180)
        {
            SlashRenderer.flipX = true;
        }
        if (activeWeapon.transform.rotation.y == 0)
        {
            SlashRenderer.flipX = false;
        }
    }

     

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        float colliangle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

      if (mousePos.x < playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
           
            weaponCollider.transform.rotation = Quaternion.Euler(0,-180,colliangle);
        }
        else
        {   
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
           
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, colliangle);

        }
          

    }

}
