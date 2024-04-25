using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Weapon1 : MonoBehaviour
{

    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;

    private PlayerControls playerControls;
    private ActiveWeapon activeWeapon;
    private PlayerController1 playerController;
    [SerializeField] private Transform weaponCollider;

    public GameObject WeaponCollider;
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


    public void Satk()
    {

        WeaponCollider.SetActive(true);
    }
    public void Eatk()
    {     
            WeaponCollider.SetActive(false);        
    }
    public void Attack()
    {
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
       
    }

    private void FlipAmim()
    {
        Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookdir = mouseP - activeWeapon.transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        SlashRenderer.transform.rotation = Quaternion.Euler(0, 0, angle);
        if (angle > -45)
        {
            SlashRenderer.flipY = false;
            SlashRenderer.flipX = false;
        } 
        if (angle < 45)
        {
            SlashRenderer.flipY = false;
            SlashRenderer.flipX = false;
        }
        if (angle > 135)
        {
            SlashRenderer.flipX = true;
            SlashRenderer.flipY = false;
        } 
        if(angle < -135)
        {
            SlashRenderer.flipX = true;
            SlashRenderer.flipY = false;
        }


        if (angle > 45 && angle < 135)
          {
              SlashRenderer.flipY = true;
          }
          else if (angle < -45 && angle > -135)
          {
              SlashRenderer.flipY = false;
          }
    }



    private void MouseFollowWithOffset()
    {
        Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookdir = mouseP - activeWeapon.transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
       
        weaponCollider.transform.rotation = Quaternion.Euler(0, 0, angle);

    }

}
