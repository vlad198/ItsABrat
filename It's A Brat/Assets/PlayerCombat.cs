using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float shootTimer;
    public float shootSpeed;
    public Transform shootPosLeft;
    public Transform shootPosRight;
    public GameObject bullet;

    private float _direction;
    private bool _isShooting;
    // Start is called before the first frame update
    void Start()
    {
        _isShooting = false;
        _direction = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        if (dirX > 0f) // running to the right
        {
            _direction = 1f;
        }
        else if (dirX < 0f) // running to the left
        {
            _direction = -1f;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        _isShooting = true;

        GameObject newBullet =
            Instantiate(bullet, _direction > 0f ? shootPosRight.position: shootPosLeft.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity =
            new Vector2(shootSpeed * _direction * Time.fixedDeltaTime, 0f);
        
        yield return new WaitForSeconds(shootTimer);
        _isShooting = false;
    }
}
