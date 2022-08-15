using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    LayerMask layerMask = 1 << 3;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            HitEnemy();
        }
#endif
#if PLATFORM_ANDROID
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                HitEnemy();
            }
        }
#endif
    }

    void HitEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100f, layerMask);
        if(hit.collider != null)
        {
            EnemyMovement enemy = hit.collider.gameObject.GetComponent<EnemyMovement>();
            if (enemy != null)
                enemy.EnemyBurst();
        }
    }
}
