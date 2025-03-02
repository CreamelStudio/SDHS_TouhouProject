using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PatternSystem
{
    public int patternValue = 0;
    public int patternCount;
    public float _attackCooldownTimer;
    public float _moveCooldownTimer;
    public int isCanMove;

    public Vector2 position;

    public PatternSystem(int patternValue, Vector2 initPosition)
    {
        isCanMove = 1;
        patternCount = 0;

        this.patternValue = patternValue;
        this.position = initPosition;

        switch (patternValue)
        {
            case 0:
                Debug.Log("Pattern 0 Summon");
                break;
            case 1:
                Debug.Log("Pattern 1 Summon");
                _attackCooldownTimer = 80;
                break;
            case 2:
                Debug.Log("Pattern 2 Summon");
                _attackCooldownTimer = 80;
                break;
            case 3:
                Debug.Log("Pattern 3 Summon");
                _attackCooldownTimer = 60;
                break;
            case 4:
                Debug.Log("Pattern 3 Summon");
                _attackCooldownTimer = 30;
                break;
        }
    }

    public void LogicUpdate()
    {
        Vector3 dirvec;
        Bullet bullet;
        float angle;
        switch (patternValue)
        {
            case 0:
                position += new Vector2(0, Time.deltaTime * -150);

                _attackCooldownTimer--;
                if (_attackCooldownTimer > 0)
                    return;

                _attackCooldownTimer = 20;
                dirvec = (PlayerUnit._instance.position - position).normalized;
                bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                bullet.SetZOffset(1);
                bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                break;
            case 1:
                if(isCanMove == 1) position += new Vector2(0, Time.deltaTime * -120);
                if(isCanMove == 2) position += new Vector2(0, Time.deltaTime * 120);

                _attackCooldownTimer--;
                if (_attackCooldownTimer > 0)
                    return;

                _attackCooldownTimer = 180;
                patternCount++;
                for (int i = 0; i < 8; i++)
                {
                    dirvec = new Vector2(-0.125f * i, 1 - (0.125f* i));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                for (int i = 0; i < 8; i++)
                {
                    dirvec = new Vector2(0.125f * i, 1 - (0.125f * i));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                for (int i = 0; i < 8; i++)
                {
                    dirvec = new Vector2(0.125f * i, -1 + (0.125f * i));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                for (int i = 0; i < 8; i++)
                {
                    dirvec = new Vector2(-0.125f * i, -1 + (0.125f * i));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                if(patternCount == 1) isCanMove = 0;
                if(patternCount >= 3) isCanMove = 2;
                break;
            case 2:
                if (isCanMove == 1) position += new Vector2(0, Time.deltaTime * -120);
                if (isCanMove == 2) position += new Vector2(0, Time.deltaTime * 120);

                _attackCooldownTimer--;
                if (_attackCooldownTimer > 0)
                    return;

                _attackCooldownTimer = 1;
                patternCount++;

                angle = Random.Range(0f, 2f * Mathf.PI);
                dirvec = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                bullet = BulletSystem.Get().SpawnSlowBullet("Kunai_Blue1", Constants.Team.Enemy, position, dirvec, 300);
                bullet.SetZOffset(1);
                bullet.bulletPrefab.SetSpriteAlpha(0.5f);

                if (patternCount == 1) isCanMove = 0;
                if (patternCount >= 80) isCanMove = 2;

                break;
            case 3:
                if (isCanMove == 1) position += new Vector2(0, Time.deltaTime * -240);
                if (isCanMove == 2) position += new Vector2(0, Time.deltaTime * 120);

                _attackCooldownTimer--;
                if (_attackCooldownTimer > 0)
                    return;

                _attackCooldownTimer = 1;
                patternCount++;
                for(int i = 0; i < 2; i++)
                {
                    angle = Random.Range(0f, 2f * Mathf.PI);
                    dirvec = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                    bullet = BulletSystem.Get().SpawnReBullet("Crystal_Yellow1", Constants.Team.Enemy, position, dirvec, 260);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                if (patternCount == 1) isCanMove = 0;
                if (patternCount >= 120) isCanMove = 2;
                break;
            case 4:
                if (isCanMove == 1) position += new Vector2(0, Time.deltaTime * -120);

                _attackCooldownTimer--;
                if (_attackCooldownTimer > 0)
                    return;

                _attackCooldownTimer = 80;
                patternCount++;
                dirvec = (PlayerUnit._instance.position - position).normalized;
                bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                bullet.SetZOffset(1);
                bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                if (patternCount == 2) isCanMove = 0;
                break;
        }
        
    }

}
