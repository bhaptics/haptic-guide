
##### Testing
For a starting point, you can check the DeathHorizenFeedback scene file. 


From that scene, you can check most of the functionality. 


Assume that the square is a player and the sphere is a zombie. 
You can move zombie by using the arrow key and feel different directional feedback.



#### Setting up in your scene 
1. Add Bhaptics_TactSourceManager Prefab on your scene or Instantiate it in your game manager object(Don't destroy object would be better).
2. Then just call the method like this 
BHaptics_TactSourceManager.instnace.PlayLoop(BHaptics_TactSourceManager.HapticType.FootStep);
BHaptics_TactSourceManager.instnace.Play(BHaptics_TactSourceManager.HapticType.Explosion);

Importantly, by using your player transform and zombie's position, you can make directional feedback as below. 
BHaptics_TactSourceManager.instnace.Play(type, Explosion.transform.position, Player.transform.position, Player.transform.forward);
You will know if you check Bhaptics_FeedbackTest.cs


#### Haptic Patterns prepared 
```
public enum HapticType
    {
        GrabAmmoLeft, 
        GrabAmmoRight,
        GrabLadderLeft,
        GrabLadderRight,
        GrabRifleSecondHandLeft,
        GrabRifleSecondHandRight,
        DoorOpeningLeft,
        DoorOpeningRight,
        ZombieSlash, // Normal zombies
        ZombieSlashStrong,  // Big zombies
        ZombiePunch, // Like a hand zombie
        RifleShotRight,
        RifleShotLeft,
        RifleShotBothHand,
        RifleReloadedLeft,
        RifleReloadedRight,
        PistolShotLeft,
        PistolShotRight,
        PistolReloadLeft,
        PistolReloadRight,
        FireAround,
        Explosion,
        FootStep,
    }
```
