using System;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    private Vector3 mousePos;
    public GameObject bulletPrefab;
    public Transform parentTransform, defaultTransform;
    void Update() {
        UpdatePos();
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
            AudioManager.Instance.PlayShootSound();
        }
    }

    private void Shoot() {
        Collider2D collider = Physics2D.OverlapCircle(mousePos, 0.07f);

        GameObject bullet = Instantiate(bulletPrefab, mousePos, Quaternion.identity);
        Destroy(bullet, 1f);

        if (collider.CompareTag("nen_go")) {
            bullet.transform.SetParent(defaultTransform);
        } else if (collider.CompareTag("bia_do_dan")) {
            bullet.transform.SetParent(parentTransform);
        } else if (collider.CompareTag("Player")) {
            bullet.transform.SetParent(parentTransform);
        } else if (collider.CompareTag("vet_dan")) {
            if (collider.transform.parent != null) {
                bullet.transform.SetParent(collider.transform.parent);
            }
        }
    }

    private void UpdatePos() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }
}
