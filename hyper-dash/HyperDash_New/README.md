

### Falling into water. 
* IntoWater.tact (vest)

 

### Haptic response for holding a shield/blocking a shot
* Shield_ArmLeft.tact Shield_ArmRight.tact (on the arm)

 
 

### Payload_SelfKill (push-crash)
* Payload_SelfKill.tact (Vest)

 

### - Heal pickups
* HealthKit1.tact HealthKit2.tact (Vest)


### About Directional Damage
* stronger haptic pattern for damage would be better -->  By increasing intensity and duration, stronger happatern will be generated.
* About the headshot -> If user dont't have head gear, by checking head device (Tactal) is connected, alternative hatpic patterns can be generated to the Vest 
* while getting hit multiple times in a short time, only last one generated fully. --> By changing the identifier all the damage patterns will be generated without missing. 

```c#
    private int idCount = 0;
    private float damageIntensity = 2f;
    private float damageDuration = 1.2f;

    private void PlayBodyHit(float vestRotationAngleX = 0f, float vestRotationOffsetY = 0f)
    {
        vestClip.Play(damageIntensity, damageDuration, vestRotationAngleX, vestRotationOffsetY, GenerateIdentifier());
    }

    private void PlayHeadShot()
    {
        var haptic = BhapticsManager.GetHaptic();

        if (haptic.IsConnect(PositionType.Head))
        {
            headClip.Play(damageIntensity, damageDuration, GenerateIdentifier());
        }
        else
        {
            float vestRotationAngleX = 0f;
            float vestRotationOffsetY = 0f;
            PlayBodyHit(vestRotationAngleX, vestRotationOffsetY);
        }
    }

    // By changing identifier, submitted haptic patterns will not be ignored.
    private string GenerateIdentifier()
    {
        string identifier = idCount % 10 + "";
        idCount++;
        return identifier;
    }
```