# SeekingDawn X bHaptics
## SampleScenes
For a starting point, you can check each sample scenes.

![image](https://user-images.githubusercontent.com/15921608/79723951-a5615400-8321-11ea-847e-6188430ab6e2.png)


From each scenes, you can check most of the functionality in "FeedbackCall" scripts.
![image](https://user-images.githubusercontent.com/15921608/79725101-a6938080-8323-11ea-8263-57278f1cc21e.png)

You can check hotkey for using sample scene on the left, top screen.
You can move enemy, explosion object's position press a Position button right side on screen.

Change Haptic feedback Press "[" "]" key
Play Haptic feedback Press "Space bar" key

---
## Setting up in your scene
1. Then just call the method like this
bHaptics_TactSourceManager.instance.Play("@tactIdString");

Importantly, by using your player transform and explosion,
you can make directional feedback as below.
Bhaptics_TactSourceManager.instance.Play("@tactIdString", explosion or bullet position(Vector3), player position(Vector3), player forward(Vector3), feelMinDistance(default parameter float));
![image](https://user-images.githubusercontent.com/15921608/79724430-7b5c6180-8322-11ea-815b-b33c6852dba7.png)

2. In the case of a projectile using collision, the player's transform and the direction of the projectile
To create a direction for feedback. 
![image](https://user-images.githubusercontent.com/15921608/79724622-d2623680-8322-11ea-951a-13196c782b7b.png)
You will know if you check projectile prefab and projectile.cs

3. If you want to give multiple feedbacks like head and body, body and hand, head and hand at once, you can declare them together in a container.
![image](https://user-images.githubusercontent.com/15921608/79724960-63d1a880-8323-11ea-8528-ebad843147e6.png)
---
## Haptic Pattern Prepared
- Vest
	- Explosion		 //Has directional
	- Explosion2		 //Has directional
	- Explosion3		 //Has directional
	- PlayerHitbyProjectile  //Has directional
	- PlayerHitbyProjectile2 //Has directional
	- PlayerHitbyProjectile3 //Has directional
	- FlowerMonster_Bite //Has directional
	- SpiderMonster_Slash //Has directional
	- FlyingMonster_BodyAttack //Has directional

- Tosy
   - Pistol_L (LeftHand)
   - Smg_L (LeftHand)
   - Shotgun_L
   - CrossBow_L
   - GrenadeLauncher_L
   - PoisonGun_L
   - PunchLauncher_Shoot_L
   - PunchLauncher_Return_L
   
- Head
   - FlyingMonster_HeadAttack