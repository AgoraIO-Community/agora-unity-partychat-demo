# agora-unity-partychat-demo
Unity video party chat using Agora SDK for RTE chat and Photon for networked multiplayer scene. Refer to the [Medium post](https://medium.com/p/76769cdd200/edit) for project setup from scratch!


## Before You Start
This demo is a portal to 4 different projects that can be accessed in each branch.
1. [master:](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/tree/master) Players can invite a player to join their video chat when close enough.

Solo Player             |  Party Joined!
:-------------------------:|:-------------------------:
<img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/Solo-Player.png" width="350">  |  <img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/Party-Time.png" width="350">

2. [In-Call-Stats:](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/tree/In-Call-Stats) Displays the different stats and realtime data you can access when in an Agora channel.

3. [live-audio-broadcast:](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/tree/live-audio-broadcast) Showcases Agora's "broadcast" mode, where players to choose to either be a Broadcaster or Audience. 

4. ![Broadcasters are displayed with gold skin](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/Live-Broadcasters.gif)

5. [spatial-audio-demo:](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/tree/spatial-audio-demo) Showcases "spatial audio" feature where incoming player audio is adjusted based on proximity and orientation to player.


## Getting Started
All main demo scenes using the viking example are inside Assets > DemoVikings > Scenes > VikingScene

If a photon room hasn't been created, select the "GO" button next to the "Create Room: " option. You can leave the name the same when testing.
If you already have a photon room created in another client, and would like to join and test, select the "GO" button next to "Join Room: ".
