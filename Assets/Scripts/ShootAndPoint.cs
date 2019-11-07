using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndPoint : MonoBehaviour
{
    public GameObject crossHairs;
    public GameObject player;
    private Vector3 target;
    public GameObject bulletPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crossHairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if(Input.GetMouseButton(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            Shoot(direction,rotationZ);
        }
    }

    void Shoot(Vector2 direction,float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefabs) as GameObject;
        b.transform.position = player.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
}
