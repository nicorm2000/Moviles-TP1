<h1>Design Patterns used in the project:</h1>
<h2>FlyWeight</h2>
<h3>FlyWeight purpose was to utilize scriptable objects to persistently store diverse data, such as the difficulty level or a boolean value indicating the game's multiplayer status. By doing so, the need for multiple objects containing this information across different scenes is eliminated, resulting in resource savings. 

https://www.youtube.com/watch?v=0N7C-XzT2Nw&ab_channel=Bala_7</h3>
<h2>Memento</hh2>
<h3>The purpose of Memento in this case was for the game manager to store players scores as private data within its class, and save them in an external class for retrieval, so it basically avoids the need for the final game screen to directly access the game manager's public variables to obtain the scores.

https://www.youtube.com/watch?v=SAaIsErpGDY&ab_channel=RawCoding
</h3>
<h2>Observer</h2>
<h3>The Observer pattern was used to delegate the responsibility of scene transition at the end of the game from the game manager to the menu manager. The menu manager establishes a subscription to the aforementioned event, and upon receiving the signal indicating the game's completion, it executes the necessary scene change operation.

https://www.youtube.com/watch?v=NY_fzd8g5MU&ab_channel=iHeartGameDev
<h2>Singleton</h2>
<h3>Singleton was used to keep the audio manager alive throughout the different scenes, so the player can enjoy the music while playing everywhere in the game.

https://www.youtube.com/watch?v=F6Y8q9H3UZI&ab_channel=SoloGameDev</h3>
