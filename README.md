# Agora Unity Party Chat Demo

Get yourself up to speed on Agora SDK essentials with 4 different projects!



## Project List
This demo is a portal to 4 different projects that can be accessed in the branches shown:

#### 1. [master:](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/tree/master)   Learn the basics of connecting two or more players in Unity to the Agora RTE network inside a snowy viking demo!

- Walk up to a player to invite them to your party 
- Accept the invite in the remote client
- Connect with your fellow players in a scalable video chat UI powered by Agora!

Refer to this [Medium post](https://medium.com/p/76769cdd200/edit) for a step by step guide from beginning to end.

          

<img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/party-chat-Joel.gif" width="350">    <img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/party-chat-Rick.gif" width="350">

---

2. [In-Call-Stats:](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/tree/In-Call-Stats) Displays the different stats and realtime data you can access when in an Agora channel.
<img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/in-call-stats.gif" width="550">

---

3. [live-audio-broadcast:](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/tree/live-audio-broadcast) Showcases Agora's "broadcast" mode, where players to choose to either be a Broadcaster or Audience. 

<img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/broadcasting.gif" width="350">

---

4. [spatial-audio-demo:](https://github.com/AgoraIO-Community/agora-unity-partychat-demo/tree/spatial-audio-demo) Showcases "spatial audio" feature where incoming player audio is adjusted based on proximity and orientation to player.

<img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/spatial-audio.gif" width="550">

_Note: In this demo all players start in the same channel_
---

## Getting Started
All main demo scenes using the viking example are inside Assets > DemoVikings > Scenes > VikingScene

<img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/demo-location.gif">

1. If a photon room hasn't been created, select the "GO" button next to the "Create Room: " option. 

<img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/network-lobby-1.gif">

2. You can leave the name the same when testing.
3. If you already have a photon room created in another client, and would like to join and test, select the "GO" button next to "Join Room: ".

<img src="https://github.com/AgoraIO-Community/agora-unity-partychat-demo/blob/master/ReadMe/network-lobby-2.gif">

---

### Bounty Board!
Current Open Bounties...
```diff
When upgrading to Unity 2020.3 (LTS)
- Assets/DemoVikings/Editor/PropertyEditor.cs(233,134): error CS0426: The type name 'DrawCapFunction' does not exist in the type 'Handles'

```
