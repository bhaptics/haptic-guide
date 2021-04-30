## HyperDash
* Randomization
* Play video: https://www.youtube.com/watch?v=MEY9ogXkQ3E&ab_channel=Ph4ntomProph3t



### Attacking(Vest/Arm)

* Pistol(RecoilLevel1)


![img](https://static.wikia.nocookie.net/hyper_dash_vr/images/6/6c/Pistol.jpg/revision/latest/scale-to-width-down/628?cb=20200531054648)

* Shock Pistol(RecoilLevel1)

![img](https://static.wikia.nocookie.net/hyper_dash_vr/images/d/dc/Shock_pistol.png/revision/latest/scale-to-width-down/606?cb=20200531051800)

* Rocket Launcher(RecoilLevel2)

![img](https://static.wikia.nocookie.net/hyper_dash_vr/images/6/6d/Rocket_lawnchair.png/revision/latest?cb=20200531052809)

* Silenced SMG(RecoilLevel1)

![img](https://static.wikia.nocookie.net/hyper_dash_vr/images/1/1e/%28silenced%29_smg.png/revision/latest/scale-to-width-down/405?cb=20200531052937)

* Burst Pistol (Weapon) (RecoilLevel2)

![img](https://static.wikia.nocookie.net/hyper_dash_vr/images/5/54/Burst_pistol.png/revision/latest/scale-to-width-down/518?cb=20200531052130)
https://hyper-dash-vr.fandom.com/wiki/Burst_Pistol_(Weapon)

* Sniper Pistol (RecoilLevel2)

![img](https://static.wikia.nocookie.net/hyper_dash_vr/images/c/cf/Sniper_pistol.png/revision/latest/scale-to-width-down/468?cb=20200531052409)

* Shotgun (Shotgun)

![img](https://static.wikia.nocookie.net/hyper_dash_vr/images/6/61/Shotgun.png/revision/latest/scale-to-width-down/427?cb=20200531053121)


### Interaction
* Reload(Arm/Vest)
* Shield(Arm/Vest) --- ADDED
* Weapon/Item pickup(Arm/Vest)
* Healing (Vest)  ---- PATTENR CHANGED
* Teleport (Arm)
* Movement: Griding (Vest)




### Attacked
* BulletHit(Head/Vest)
* ExplosionHit(Head/Vest)



### Special
* Low Health(Vest)
* Falling_into_water(Vest) --- ADDED

* Lobby BGM with haptic!!

 




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