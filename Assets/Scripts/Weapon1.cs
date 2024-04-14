using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        playerControls.Combat.Attack.started += _ => Attack();

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
    void Attack()
    {
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
       
    }

      private void FlipAmim()
      {
         if (playerController.mySpriteRender.flipX == true)
          {
              SlashRenderer.flipX = true;
          }
          if (playerController.mySpriteRender.flipX == false)
          {
              SlashRenderer.flipX = false;
          }
      }
    
    public void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {



            if (activeWeapon != null)
            {
                Debug.Log("haha");
                activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
                weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
        else
        {
            if (activeWeapon != null)
            {
                activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
                weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
