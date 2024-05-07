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

    [SerializeField] private GameObject broomSlash;
    [SerializeField] private Transform weaponAnimPoint;

    private PlayerControls playerControls;
    private ActiveWeapon activeWeapon;
    private PlayerController1 playerController;
    [SerializeField] private Transform weaponCollider;

    public GameObject WeaponCollider;
    public SpriteRenderer SlashRenderer;

    GameObject slashAnim;
    GameObject broomAnim;



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
        this.GetComponent<Renderer>().enabled = false;
        WeaponCollider.SetActive(true);
    }
    public void Eatk()
    {
        this.GetComponent<Renderer>().enabled = true;
        WeaponCollider.SetActive(false);
    }
    public void Attack()
    {

        Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookdir = mouseP - activeWeapon.transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.Euler(0, 0, angle));
        slashAnim.transform.parent = this.transform.parent;

        broomAnim = Instantiate(broomSlash, weaponAnimPoint.position, Quaternion.Euler(0, 0, angle));
        
        broomAnim.transform.parent = this.transform.parent;
    }
  
   

    private void FlipAmim()
    {
        Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookdir = mouseP - activeWeapon.transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;

        SlashRenderer.transform.rotation = Quaternion.Euler(0, 0, angle);
      
       
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
