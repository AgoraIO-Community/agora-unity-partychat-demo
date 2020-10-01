Agora provides ensured quality of experience (QoE) for worldwide Internet-based voice and video communications through a virtual global network optimized for real-time web and mobile-to-mobile applications.

- The {@link agora_gaming_rtc.IRtcEngine IRtcEngine} class is the entry point of the Agora RTC SDK providing API methods for applications to quickly start a voice/video communication or interactive broadcast.
- The {@link agora_gaming_rtc.OnJoinChannelSuccessHandler AgoraCallback} reports runtime events to the applications.
- The {@link agora_gaming_rtc.AgoraChannel AgoraChannel} class provides methods that enable real-time communications
in a specified channel. By creating multiple RtcChannel instances, users can join multiple channels.
- The {@link agora_gaming_rtc.AgoraChannelCallback AgoraChannelCallback} class provides callbacks that report events and statistics of a specified channel.
- The {@link agora_gaming_rtc.AudioEffectManagerImpl AudioEffectManagerImpl} class provides APIs that set the audio effects.
- The {@link agora_gaming_rtc.AudioPlaybackDeviceManager AudioPlaybackDeviceManager} class provides APIs that set the audio playback device, and retrieves the information of the audio playback device.
- The {@link agora_gaming_rtc.AudioRecordingDeviceManager AudioRecordingDeviceManager} class provides APIs that set the audio recording device, and retrieves the information of the audio recording device.
- The {@link agora_gaming_rtc.VideoDeviceManager VideoDeviceManager} class provides APIs that set the video recording device, and retrieves the information of the video recording device.
- The {@link agora_gaming_rtc.MetadataObserver MetadataObserver} class provides APIs that register the MetadataObserver and report the status of the metadata.
- The {@link agora_gaming_rtc.PacketObserver PacketObserver} class provides APIs that register the PacketObserver and report the status of the audio packet.
- The {@link agora_gaming_rtc.AudioRawDataManager AudioRawDataManager} class provides APIs that register the audio raw data observer and report the status of the audio raw data.
- The {@link agora_gaming_rtc.VideoRawDataManager VideoRawDataManager} class provides APIs that register the video raw data observer and report the status of the video raw data.
- The {@link VideoSurface VideoSurface} class provides APIs that set the video renderer type and the local/remote video.

### Channel Management

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetEngine(string appId) GetEngine1}</td>
<td>Initializes the IRtcEngine.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetEngine(RtcEngineConfig engineConfig) GetEngine2}</td>
<td>Initializes the IRtcEngine and specifies the connection area.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.Destroy Destroy}</td>
<td>Destroys all IRtcEngine resources.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetChannelProfile SetChannelProfile}</td>
<td>Sets the channel profile of the Agora IRtcEngine.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetClientRole SetClientRole}</td>
<td>Sets the role of the user in a live broadcast.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.JoinChannel JoinChannel}</td>
<td>Allows a user to join a channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.JoinChannelByKey JoinChannelByKey}</td>
<td>Allows a user to join a channel with token.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SwitchChannel SwitchChannel}</td>
<td>Switches to a different channel in a live broadcast.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.LeaveChannel LeaveChannel}</td>
<td>Allows a user to leave a channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.RenewToken RenewToken}</td>
<td>Renews the Token.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetConnectionState GetConnectionState}</td>
<td>Gets the current connection state of the SDK.</td>
</tr>
</table>

### Channel Events

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnConnectionStateChangedHandler OnConnectionStateChangedHandler}</td>
<td>Occurs when the connection state between the SDK and the server changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnJoinChannelSuccessHandler OnJoinChannelSuccessHandler}</td>
<td>Occurs when a user joins a channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnReJoinChannelSuccessHandler OnReJoinChannelSuccessHandler}</td>
<td>Occurs when a user rejoins the channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnLeaveChannelHandler OnLeaveChannelHandler}</td>
<td>Occurs when a user leaves the channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnClientRoleChangedHandler OnClientRoleChangedHandler}</td>
<td>Occurs when the user role switches in a live broadcast.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnUserJoinedHandler OnUserJoinedHandler}</td>
<td>Occurs when a remote user (Communication)/ host (Live Broadcast) joins the channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnUserOfflineHandler OnUserOfflineHandler}</td>
<td>Occurs when a remote user (Communication)/ host (Live Broadcast) leaves the channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnNetworkTypeChangedHandler OnNetworkTypeChangedHandler}</td>
<td>Occurs when the local network type changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnConnectionLostHandler OnConnectionLostHandler}</td>
<td>Occurs when the SDK cannot reconnect to Agora's edge server 10 seconds after its connection to the server is interrupted.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnTokenPrivilegeWillExpireHandler OnTokenPrivilegeWillExpireHandler}</td>
<td>Occurs when the token expires in 30 seconds.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRequestTokenHandler OnRequestTokenHandler}</td>
<td>Occurs when the token expires.</td>
</tr>
</table>

### Audio Management

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableAudio EnableAudio}</td>
<td>Enables the audio module.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.DisableAudio DisableAudio}</td>
<td>Disables the audio module.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetAudioProfile SetAudioProfile}</td>
<td>Sets the audio parameters and application scenarios.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AdjustRecordingSignalVolume AdjustRecordingSignalVolume}</td>
<td>Adjusts the recording volume.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AdjustUserPlaybackSignalVolume AdjustUserPlaybackSignalVolume}</td>
<td>Adjusts the playback volume of a specified remote user.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AdjustPlaybackSignalVolume AdjustPlaybackSignalVolume}</td>
<td>Adjusts the playback volume of all remote users.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableLocalAudio EnableLocalAudio}</td>
<td>Enables/Disables the local audio sampling.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.MuteLocalAudioStream MuteLocalAudioStream}</td>
<td>Stops/Resumes sending the local audio stream.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.MuteRemoteAudioStream MuteRemoteAudioStream}</td>
<td>Stops/Resumes receiving the audio stream from a specified remote user.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.MuteAllRemoteAudioStreams MuteAllRemoteAudioStreams}</td>
<td>Stops/Resumes receiving all remote users' audio streams.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetDefaultMuteAllRemoteAudioStreams SetDefaultMuteAllRemoteAudioStreams}</td>
<td>Stops/Resumes receiving all remote users' audio streams by default.</td>
</tr>
</table>

### Audio Volume Indication

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableAudioVolumeIndication EnableAudioVolumeIndication}</td>
<td>Enables the {@link agora_gaming_rtc.OnVolumeIndicationHandler OnVolumeIndicationHandler} callback at a set time interval to report on which users are speaking and the speakers' volume.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnVolumeIndicationHandler OnVolumeIndicationHandler}</td>
<td>Reports which users are speaking, the speakers' volumes, and whether the local user is speaking.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnActiveSpeakerHandler OnActiveSpeakerHandler}</td>
<td>Reports which user is the loudest speaker.</td>
</tr>
</table>

### Face detection
<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableFaceDetection EnableFaceDetection}</td>
<td>Enables/Disables face detection for the local user.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnFacePositionChangedHandler OnFacePositionChangedHandler}</td>
<td>Reports the face detection result of the local user.</td>
</tr>
</table>

### Video Management

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableVideo EnableVideo}</td>
<td>Enables the video module.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableVideoObserver EnableVideoObserver}</td>
<td>Enables the video observer.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.DisableVideo DisableVideo}</td>
<td>Disables the video module.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.DisableVideoObserver DisableVideoObserver}</td>
<td>Disables the video observer.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetVideoEncoderConfiguration SetVideoEncoderConfiguration}</td>
<td>Sets the video encoder configuration.</td>
</tr>
<tr>
<td>{@link VideoSurface.SetForUser SetForUser}</td>
<td>Sets the local/remote video.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartPreview StartPreview}</td>
<td>Starts the local video preview before joining the channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StopPreview StopPreview}</td>
<td>Stops the local video preview and disables video.</td>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableLocalVideo EnableLocalVideo}</td>
<td>Enables/Disables the local video capture.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.MuteLocalVideoStream MuteLocalVideoStream}</td>
<td>Stops/Resumes sending the local video stream.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.MuteRemoteVideoStream MuteRemoteVideoStream}</td>
<td>Stops/Resumes receiving the video stream from a specified remote user.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.MuteAllRemoteVideoStreams MuteAllRemoteVideoStreams}</td>
<td>Stops/Resumes receiving all remote video streams.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetDefaultMuteAllRemoteVideoStreams SetDefaultMuteAllRemoteVideoStreams}</td>
<td>Stops/Resumes receiving all remote users' video streams by default.</td>
</tr>
</table>

### Audio Effect Playback

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.GetEffectsVolume GetEffectsVolume}</td>
<td>Gets the volume of the audio effects.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.SetEffectsVolume SetEffectsVolume}</td>
<td>Sets the volume of the audio effects.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetVolumeOfEffect SetVolumeOfEffect}</td>
<td>Sets the volume of a specified audio effect.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.PlayEffect PlayEffect}</td>
<td>Plays a specified audio effect.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.StopEffect StopEffect}</td>
<td>Stops playing a specified audio effect.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.StopAllEffects StopAllEffects}</td>
<td>Stops playing all audio effects.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.PreloadEffect PreloadEffect}</td>
<td>Preloads a specified audio effect file into the memory.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.UnloadEffect UnloadEffect}</td>
<td>Releases a specified audio effect from the memory.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.PauseEffect PauseEffect}</td>
<td>Pauses a specified audio effect.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.PauseAllEffects PauseAllEffects}</td>
<td>Pauses all audio effects.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.ResumeEffect ResumeEffect}</td>
<td>Resumes playing a specified audio effect.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.ResumeAllEffects ResumeAllEffects}</td>
<td>Resumes playing all audio effects.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.SetVoiceOnlyMode SetVoiceOnlyMode}</td>
<td>Sets the voice-only mode.</td>
</tr>
</table>
<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnAudioEffectFinishedHandler OnAudioEffectFinishedHandler}</td>
<td>Occurs when the local audio effect playback finishes.</td>
</tr>
</table>

### Voice Changer and Reverberation

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLocalVoiceChanger SetLocalVoiceChanger}</td>
<td>Sets the local voice changer option.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLocalVoiceReverbPreset SetLocalVoiceReverbPreset}</td>
<td>Sets the preset local voice reverberation effect.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.SetLocalVoicePitch SetLocalVoicePitch}</td>
<td>Changes the voice pitch of the local speaker.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLocalVoiceEqualization SetLocalVoiceEqualization}</td>
<td>Sets the local voice equalization effect.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLocalVoiceReverb SetLocalVoiceReverb}</td>
<td>Sets the local voice reverberation.</td>
</tr>
</table>

### Sound Position Indication

<table>
<tr>
<th>Method</th>
<th>Description</th>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableSoundPositionIndication EnableSoundPositionIndication}</td>
<td>Enables/Disables stereo panning for remote users.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioEffectManagerImpl.SetRemoteVoicePosition SetRemoteVoicePosition}</td>
<td>Sets the sound position and gain of a remote user.</td>
</tr>
</table>

### Local Media Events

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnLocalAudioStateChangedHandler OnLocalAudioStateChangedHandler}</td>
<td>Occurs when the local audio state changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnLocalVideoStateChangedHandler OnLocalVideoStateChangedHandler}</td>
<td>Occurs when the local video state changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnFirstLocalAudioFrameHandler OnFirstLocalAudioFrameHandler}</td>
<td>Occurs when the first local audio frame is sent.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnFirstLocalVideoFrameHandler OnFirstLocalVideoFrameHandler}</td>
<td>Occurs when the first local video frame is rendered.</td>
</tr>
</table>

### Remote Media Events

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRemoteAudioStateChangedHandler OnRemoteAudioStateChangedHandler}</td>
<td>Occurs when the remote audio state changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRemoteVideoStateChangedHandler OnRemoteVideoStateChangedHandler}</td>
<td>Occurs when the remote video state changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnUserMutedAudioHandler OnUserMutedAudioHandler}</td>
<td>Occurs when a remote user's audio stream playback pauses/resumes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnFirstRemoteVideoFrameHandler OnFirstRemoteVideoFrameHandler}</td>
<td>Occurs when the first remote video frame is rendered.</td>
</tr>
</table>

### Statistics Events

> After joining a channel, SDK triggers this group of callbacks once every two seconds.

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRtcStatsHandler OnRtcStatsHandler}</td>
<td>Reports the statistics of the current call session.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnNetworkQualityHandler OnNetworkQualityHandler}</td>
<td>Reports the network quality of each user.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnLocalAudioStatsHandler OnLocalAudioStatsHandler}</td>
<td>Reports the statistics of the local audio stream.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnLocalVideoStatsHandler OnLocalVideoStatsHandler}</td>
<td>Reports the statistics of the local video stream.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRemoteAudioStatsHandler OnRemoteAudioStatsHandler}</td>
<td>Reports the statistics of the audio stream from each remote user/host.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRemoteVideoStatsHandler OnRemoteVideoStatsHandler}</td>
<td>Reports the statistics of the video stream from each remote user/host.</td>
</tr>
</table>

### Video Pre-process and Post-process

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetBeautyEffectOptions SetBeautyEffectOptions}</td>
<td>Sets the image enhancement options. (This method applies to Android and iOS only.)</td>
</tr>
</table>

### Multi-channel management

> We provide an advanced guide on the applicable scenarios, implementation and considerations for this group of methods. For details, see [Join multiple channels]
(https://docs.agora.io/en/Interactive%20Broadcast/multiple_channel_unity).

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AgoraChannel.CreateChannel CreateChannel}</td>
<td>Creates and gets an `AgoraChannel` object. To join multiple channels, create multiple `AgoraChannel` objects.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AgoraChannel AgoraChannel}</td>
<td>Provides methods that enable real-time communications in a specified channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AgoraChannel.ChannelOnWarningHandler AgoraChannelCallback}</td>
<td>Provides callbacks that report events and statistics in a specified channel.</td>
</tr>
</table>

### Screen Capture

> This group of methods applies to Windows or macOS only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartScreenCaptureByDisplayId StartScreenCaptureByDisplayId}</td>
<td>Shares the whole or part of a screen by specifying the display ID.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartScreenCaptureByScreenRect StartScreenCaptureByScreenRect}</td>
<td>Shares the whole or part of a screen by specifying the screen rect.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartScreenCaptureByWindowId StartScreenCaptureByWindowId}</td>
<td>Shares the whole or part of a window by specifying the window ID.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetScreenCaptureContentHint SetScreenCaptureContentHint}</td>
<td>Sets the content hint for screen sharing.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.UpdateScreenCaptureParameters UpdateScreenCaptureParameters}</td>
<td>Updates the screen sharing parameters.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.UpdateScreenCaptureRegion UpdateScreenCaptureRegion}</td>
<td>Updates the screen sharing region.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StopScreenCapture StopScreenCapture}</td>
<td>Stops screen sharing.</td>
</tr>
</table>

### Audio File Playback and Mixing

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartAudioMixing StartAudioMixing}</td>
<td>Starts playing and mixing the music file.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StopAudioMixing StopAudioMixing}</td>
<td>Stops playing and mixing the music file.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.PauseAudioMixing PauseAudioMixing}</td>
<td>Pauses playing and mixing the music file.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.ResumeAudioMixing ResumeAudioMixing}</td>
<td>Resumes playing and mixing the music file.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AdjustAudioMixingVolume AdjustAudioMixingVolume}</td>
<td>Adjusts the volume during audio mixing.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AdjustAudioMixingPlayoutVolume AdjustAudioMixingPlayoutVolume}</td>
<td>Adjusts the volume of audio mixing for local playback.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AdjustAudioMixingPublishVolume AdjustAudioMixingPublishVolume}</td>
<td>Adjusts the volume of audio mixing for remote playback.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AdjustAudioMixingPublishVolume AdjustAudioMixingPublishVolume}</td>
<td>Adjusts the volume of audio mixing for remote playback.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetAudioMixingPitch SetAudioMixingPitch}</td>
<td>Sets the pitch of the local music file.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetAudioMixingPlayoutVolume GetAudioMixingPlayoutVolume}</td>
<td>Gets the audio mixing volume for local playback.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetAudioMixingPublishVolume GetAudioMixingPublishVolume}</td>
<td>Gets the audio mixing volume for publishing.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetAudioMixingDuration GetAudioMixingDuration}</td>
<td>Gets the duration (ms) of the music file.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetAudioMixingCurrentPosition GetAudioMixingCurrentPosition}</td>
<td>Gets the playback position (ms) of the music file.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetAudioMixingPosition SetAudioMixingPosition}</td>
<td>Sets the playback position of the music file.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnAudioMixingStateChangedHandler OnAudioMixingStateChangedHandler}</td>
<td>Occurs when the state of the local user's audio mixing file changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRemoteAudioMixingBeginHandler OnRemoteAudioMixingBeginHandler}</td>
<td>Occurs when a remote user starts audio mixing.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRemoteAudioMixingEndHandler OnRemoteAudioMixingEndHandler}</td>
<td>Occurs when a remote user finishes audio mixing.</td>
</tr>
</table>

### CDN Publisher

> This group of methods apply to Live Broadcast only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLiveTranscoding SetLiveTranscoding}</td>
<td>Sets the video layout and audio for CDN live.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AddPublishStreamUrl AddPublishStreamUrl}</td>
<td>Adds a CDN stream address.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.RemovePublishStreamUrl RemovePublishStreamUrl}</td>
<td>Removes a CDN stream address.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRtmpStreamingStateChangedHandler OnRtmpStreamingStateChangedHandler}</td>
<td>Occurs when the state of the RTMP streaming changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnTranscodingUpdatedHandler OnTranscodingUpdatedHandler}</td>
<td>Occurs when the publisher's transcoding settings are updated.</td>
</tr>
</table>

### Media Stream Relay Across Channels

> This group of methods apply to Live Broadcast only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartChannelMediaRelay StartChannelMediaRelay}</td>
<td>Starts to relay media streams across channels.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.UpdateChannelMediaRelay UpdateChannelMediaRelay}</td>
<td>Updates the channels for media stream relay.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StopChannelMediaRelay StopChannelMediaRelay}</td>
<td>Stops the media stream relay.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnChannelMediaRelayStateChangedHandler OnChannelMediaRelayStateChangedHandler}</td>
<td>Occurs when the state of the media stream relay changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnChannelMediaRelayEventHandler OnChannelMediaRelayEventHandler}</td>
<td>Reports events during the media stream relay.</td>
</tr>
</table>

### Audio Routing Control

> This group of methods applies to Android and iOS only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetDefaultAudioRouteToSpeakerphone SetDefaultAudioRouteToSpeakerphone}</td>
<td>Sets the default audio playback route.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetEnableSpeakerphone SetEnableSpeakerphone}</td>
<td>Enables/Disables the audio playback route to the speakerphone.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.IsSpeakerphoneEnabled IsSpeakerphoneEnabled}</td>
<td>Checks whether the speakerphone is enabled.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnAudioRouteChangedHandler OnAudioRouteChangedHandler}</td>
<td>Occurs when the local audio route changes.</td>
</tr>
</table>

### In-ear Monitoring

> This group of methods applies to Android and iOS only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableInEarMonitoring EnableInEarMonitoring}</td>
<td>Enables in-ear monitoring.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetInEarMonitoringVolume SetInEarMonitoringVolume}</td>
<td>Sets the volume of the in-ear monitor.</td>
</tr>
</table>

### Dual Video Stream Mode

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableDualStreamMode EnableDualStreamMode}</td>
<td>Enables/disables dual video stream mode.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetRemoteVideoStreamType SetRemoteVideoStreamType}</td>
<td>Sets the remote user’s video stream type received by the local user when the remote user sends dual streams.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetRemoteDefaultVideoStreamType SetRemoteDefaultVideoStreamType}</td>
<td>Sets the default video-stream type for the video received by the local user when the remote user sends dual streams.</td>
</tr>
</table>

### Stream Fallback

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLocalPublishFallbackOption SetLocalPublishFallbackOption}</td>
<td>Sets the fallback option for the published video stream under unreliable network conditions.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetRemoteSubscribeFallbackOption SetRemoteSubscribeFallbackOption}</td>
<td>Sets the fallback option for the remote stream under unreliable network conditions.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetRemoteUserPriority SetRemoteUserPriority}</td>
<td>Prioritizes a remote user's stream. </td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnLocalPublishFallbackToAudioOnlyHandler OnLocalPublishFallbackToAudioOnlyHandler}</td>
<td>Occurs: <p><ul><li>When the published media stream falls back to an audio-only stream due to poor network conditions.</li><li>When the published media stream switches back to the video after the network conditions improve.</li></ul></p></td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnRemoteSubscribeFallbackToAudioOnlyHandler OnRemoteSubscribeFallbackToAudioOnlyHandler}</td>
<td>Occurs: <p><ul><li>When the remote media stream falls back to audio-only due to poor network conditions. </li><li>When the remote media stream switches back to the video after the network conditions improve.</li></ul></p></td>
</tr>
</table>

### Pre-call Network Test

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartEchoTest(int intervalInSeconds) StartEchoTest}</td>
<td>Starts an audio call test.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StopEchoTest StopEchoTest}</td>
<td>Stops the audio call test.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableLastmileTest EnableLastmileTest}</td>
<td>Enables the network connection quality test.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.DisableLastmileTest DisableLastmileTest}</td>
<td>Disables the network connection quality test.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartLastmileProbeTest StartLastmileProbeTest}</td>
<td>Starts the last-mile network probe test.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StopLastmileProbeTest StopLastmileProbeTest}</td>
<td>Stops the last-mile network probe test.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnLastmileQualityHandler OnLastmileQualityHandler}</td>
<td>Reports the last mile network quality of the local user before the user joins the channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnLastmileProbeResultHandler OnLastmileProbeResultHandler}</td>
<td>Reports the last-mile network probe result.</td>
</tr>
</table>

### External Video Data (Push-mode only)

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetExternalVideoSource SetExternalVideoSource}</td>
<td>Configures the external video source.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.PushVideoFrame PushVideoFrame}</td>
<td>Pushes the external video frame.</td>
</tr>
</table>

### External Audio Data (Push-mode only)

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetExternalAudioSource SetExternalAudioSource}</td>
<td>Configures the external audio source.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.PushAudioFrame PushAudioFrame}</td>
<td>Pushes the external audio frame.</td>
</tr>
</table>


### External Audio Sink (Pull-mode only)

> This group of methods applies to Windows only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetExternalAudioSink SetExternalAudioSink}</td>
<td>Sets the external audio sink.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.PullAudioFrame PullAudioFrame}</td>
<td>Pulls the external audio frame.</td>
</tr>
</table>

### <a name="rawaudio"></a >Raw Audio Data

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.RegisterAudioRawDataObserver RegisterAudioRawDataObserver}</td>
<td>Registers an audio frame observer object.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.UnRegisterAudioRawDataObserver UnRegisterAudioRawDataObserver}</td>
<td>UnRegisters the audio raw data observer.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.SetOnRecordAudioFrameCallback SetOnRecordAudioFrameCallback}</td>
<td>Listens for the {@link agora_gaming_rtc.AudioRawDataManager.OnRecordAudioFrameHandler OnRecordAudioFrameHandler} delegate.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.SetOnPlaybackAudioFrameCallback SetOnPlaybackAudioFrameCallback}</td>
<td>Listens for the {@link agora_gaming_rtc.AudioRawDataManager.OnPlaybackAudioFrameHandler OnPlaybackAudioFrameHandler} delegate.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.SetOnPlaybackAudioFrameBeforeMixingCallback SetOnPlaybackAudioFrameBeforeMixingCallback}</td>
<td>Listens for the {@link agora_gaming_rtc.AudioRawDataManager.OnPlaybackAudioFrameBeforeMixingHandler OnPlaybackAudioFrameBeforeMixingHandler} delegate.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.SetOnMixedAudioFrameCallback SetOnMixedAudioFrameCallback}</td>
<td>Listens for the {@link agora_gaming_rtc.AudioRawDataManager.OnMixedAudioFrameHandler OnMixedAudioFrameHandler} delegate.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.OnRecordAudioFrameHandler OnRecordAudioFrameHandler}</td>
<td>Retrieves the recorded audio frame.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.OnPlaybackAudioFrameHandler OnPlaybackAudioFrameHandler}</td>
<td>Retrieves the audio playback frame.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.OnPlaybackAudioFrameBeforeMixingHandler OnPlaybackAudioFrameBeforeMixingHandler}</td>
<td>Retrieves the audio frame of a specified user before mixing.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRawDataManager.OnMixedAudioFrameHandler OnMixedAudioFrameHandler}</td>
<td>Retrieves the mixed recorded and playback audio frame.</td>
</tr>
</table>


### <a name="rawvideo"></a >Raw Video Data

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoRawDataManager.RegisterVideoRawDataObserver RegisterVideoRawDataObserver}</td>
<td>Registers a video frame observer object.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoRawDataManager.UnRegisterVideoRawDataObserver UnRegisterVideoRawDataObserver}</td>
<td>UnRegisters the video raw data observer.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoRawDataManager.SetOnCaptureVideoFrameCallback SetOnCaptureVideoFrameCallback}</td>
<td>Listens for the {@link agora_gaming_rtc.VideoRawDataManager.OnCaptureVideoFrameHandler OnCaptureVideoFrameHandler} delegate.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoRawDataManager.SetOnRenderVideoFrameCallback SetOnRenderVideoFrameCallback}</td>
<td>Listens for the {@link agora_gaming_rtc.VideoRawDataManager.OnRenderVideoFrameHandler OnRenderVideoFrameHandler} delegate.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoRawDataManager.OnCaptureVideoFrameHandler OnCaptureVideoFrameHandler}</td>
<td>Occurs when the camera captured image is received.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoRawDataManager.OnRenderVideoFrameHandler OnRenderVideoFrameHandler}</td>
<td>Processes the received image of the specified user (post-processing).</td>
</tr>
</table>


### Media Metadata

> This group of methods apply to Live Broadcast only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.MetadataObserver.RegisterMediaMetadataObserver RegisterMediaMetadataObserver}</td>
<td>Registers a metadata observer.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.MetadataObserver.UnRegisterMediaMetadataObserver UnRegisterMediaMetadataObserver}</td>
<td>Unregisters a metadata observer.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.MetadataObserver.OnGetMaxMetadataSizeHandler OnGetMaxMetadataSizeHandler}</td>
<td>Occurs when the SDK requests the maximum size of the metadata.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.MetadataObserver.OnReadyToSendMetadataHandler OnReadyToSendMetadataHandler}</td>
<td>Occurs when the SDK is ready to receive and send metadata.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.MetadataObserver.OnMediaMetaDataReceivedHandler OnMediaMetaDataReceivedHandler}</td>
<td>Occurs when the local user receives the metadata.</td>
</tr>
</table>


### Watermark

> This group of methods apply to Live Broadcast only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AddVideoWatermark(string watermarkUrl, WatermarkOptions watermarkOptions) AddVideoWatermark}</td>
<td>Adds a watermark image to the local video stream.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.ClearVideoWatermarks ClearVideoWatermarks}</td>
<td>Removes the added watermark image from the video stream.</td>
</tr>
</table>


### Encryption

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetEncryptionSecret SetEncryptionSecret}</td>
<td>Enables built-in encryption with an encryption password before joining a channel.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetEncryptionMode SetEncryptionMode}</td>
<td>Sets the built-in encryption mode.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.PacketObserver.RegisterPacketObserver RegisterPacketObserver}</td>
<td>Registers a packet observer.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.PacketObserver.UnRegisterPacketObserver UnRegisterPacketObserver}</td>
<td>UnRegisters the packet observer.</td>
</tr>
</table>

### Audio Recorder

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality) StartAudioRecording}</td>
<td>Starts an audio recording on the client.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.StopAudioRecording StopAudioRecording}</td>
<td>Stops an audio recording on the client.</td>
</tr>
</table>

### Inject an Online Media Stream

> This group of methods apply to Live Broadcast only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.AddInjectStreamUrl AddInjectStreamUrl}</td>
<td>Adds an online media stream to a live broadcast.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.RemoveInjectStreamUrl RemoveInjectStreamUrl}</td>
<td>Removes the online media stream from a live broadcast.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnStreamInjectedStatusHandler OnStreamInjectedStatusHandler}</td>
<td>Reports the status of the injected online media stream.</td>
</tr>
</table>


### Camera Control

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SwitchCamera SwitchCamera}</td>
<td>Switches between front and rear cameras (for Android and iOS only).</td>
</tr>
</table>

### Audio Device Manager

> This group of methods applies to Windows and macOS only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.CreateAAudioPlaybackDeviceManager CreateAAudioPlaybackDeviceManager}</td>
<td>Creates an AudioPlaybackDeviceManager instance.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.ReleaseAAudioPlaybackDeviceManager ReleaseAAudioPlaybackDeviceManager}</td>
<td>Releases an AudioPlaybackDeviceManager instance.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.CreateAAudioRecordingDeviceManager CreateAAudioRecordingDeviceManager}</td>
<td>Creates an AudioRecordingDeviceManager instance.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.ReleaseAAudioRecordingDeviceManager ReleaseAAudioRecordingDeviceManager}</td>
<td>Releases an AudioRecordingDeviceManager instance.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.GetAudioPlaybackDeviceCount GetAudioPlaybackDeviceCount}</td>
<td>Retrieves the total number of the indexed audio playback devices in the system.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.GetAudioRecordingDeviceCount GetAudioRecordingDeviceCount}</td>
<td>Retrieves the total number of the indexed audio recording devices in the system.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.GetAudioPlaybackDevice GetAudioPlaybackDevice}</td>
<td>Retrieves the audio playback device associated with the index.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.GetAudioRecordingDevice GetAudioRecordingDevice}</td>
<td>Retrieves the audio recording device associated with the index.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.SetAudioPlaybackDevice SetAudioPlaybackDevice}</td>
<td>Sets the audio playback device using the device ID.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.SetAudioRecordingDevice SetAudioRecordingDevice}</td>
<td>Sets the audio recording device using the device ID.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.StartAudioPlaybackDeviceTest StartAudioPlaybackDeviceTest}</td>
<td>Starts the test of the current audio playback device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.StopAudioPlaybackDeviceTest StopAudioPlaybackDeviceTest}</td>
<td>Stops the test of the current audio playback device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.StartAudioRecordingDeviceTest StartAudioRecordingDeviceTest}</td>
<td>Starts the test of the current audio recording device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.StopAudioRecordingDeviceTest StopAudioRecordingDeviceTest}</td>
<td>Stops the test of the current audio recording device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.SetAudioPlaybackDeviceVolume SetAudioPlaybackDeviceVolume}</td>
<td>Sets the volume of the current audio playback device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.GetAudioPlaybackDeviceVolume GetAudioPlaybackDeviceVolume}</td>
<td>Retrieves the volume of the current audio playback device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.SetAudioRecordingDeviceVolume SetAudioRecordingDeviceVolume}</td>
<td>Sets the volume of the current audio recording device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.GetAudioRecordingDeviceVolume GetAudioRecordingDeviceVolume}</td>
<td>Retrieves the volume of the current audio recording device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.SetAudioPlaybackDeviceMute SetAudioPlaybackDeviceMute}</td>
<td>Sets whether to stop audio playback.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.IsAudioPlaybackDeviceMute IsAudioPlaybackDeviceMute}</td>
<td>Retrieves the status of the current audio playback device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.SetAudioRecordingDeviceMute SetAudioRecordingDeviceMute}</td>
<td>Sets whether to stop audio recording.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.IsAudioRecordingDeviceMute IsAudioRecordingDeviceMute}</td>
<td>Gets the status of the current audio recording device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.GetCurrentPlaybackDevice GetCurrentPlaybackDevice}</td>
<td>Retrieves the device ID of the current audio playback device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.GetCurrentRecordingDevice GetCurrentRecordingDevice}</td>
<td>Retrieves the device ID of the current audio recording device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioPlaybackDeviceManager.GetCurrentPlaybackDeviceInfo GetCurrentPlaybackDeviceInfo}</td>
<td>Retrieves the device information of the current audio playback device.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.AudioRecordingDeviceManager.GetCurrentRecordingDeviceInfo GetCurrentRecordingDeviceInfo}</td>
<td>Retrieves the device information of the current audio recording device.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnAudioDeviceStateChangedHandler OnAudioDeviceStateChangedHandler}</td>
<td>Occurs when the audio device state changes.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnAudioDeviceVolumeChangedHandler OnAudioDeviceVolumeChangedHandler}</td>
<td>Occurs when the volume of the playback, microphone, or application changes.</td>
</tr>
</table>

### Video Device Manager

> This group of methods applies to Windows and macOS only.

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoDeviceManager.CreateAVideoDeviceManager CreateAVideoDeviceManager}</td>
<td>Creates an VideoDeviceManager instance.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoDeviceManager.ReleaseAVideoDeviceManager ReleaseAVideoDeviceManager}</td>
<td>Releases an VideoDeviceManager instance.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoDeviceManager.GetVideoDeviceCount GetVideoDeviceCount}</td>
<td>Retrieves the total number of the indexed video recording devices in the system.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoDeviceManager.GetVideoDevice GetVideoDevice}</td>
<td>Retrieves the video recording device associated with the index.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoDeviceManager.SetVideoDevice SetVideoDevice}</td>
<td>Sets the video recording device using the device ID.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoDeviceManager.StartVideoDeviceTest StartVideoDeviceTest}</td>
<td>Starts the video recording device test.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoDeviceManager.StopVideoDeviceTest StopVideoDeviceTest}</td>
<td>Stops the video recording device test.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.VideoDeviceManager.GetCurrentVideoDevice GetCurrentVideoDevice}</td>
<td>Retrieves the device ID of the current video recording device.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnVideoDeviceStateChangedHandler OnVideoDeviceStateChangedHandler}</td>
<td>Occurs when the video device state changes.</td>
</tr>
</table>



### Stream Message

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.CreateDataStream CreateDataStream}</td>
<td>Creates a data stream.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SendStreamMessage SendStreamMessage}</td>
<td>Sends data stream messages to all users in a channel.</td>
</tr>
</table>

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnStreamMessageHandler OnStreamMessageHandler}</td>
<td>Occurs when the local user receives the data stream from the remote user within five seconds.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnStreamMessageErrorHandler OnStreamMessageErrorHandler}</td>
<td>Occurs when the local user does not receive the data stream from the remote user within five seconds.</td>
</tr>
</table>


### Miscellaneous Audio Control

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.EnableLoopbackRecording EnableLoopbackRecording}</td>
<td>Enables loopback recording (for macOS and Windows only).</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetAudioSessionOperationRestriction SetAudioSessionOperationRestriction}</td>
<td>Sets the audio session’s operational restriction (for iOS only).</td>
</tr>
</table>

### Miscellaneous Video Control
<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetCameraCapturerConfiguration SetCameraCapturerConfiguration}</td>
<td>Sets the camera capturer configuration.</td>
</tr>
</table>


### Miscellaneous Methods
<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link VideoSurface.SetGameFps SetGameFps}</td>
<td>Sets the video rendering frame rate.</td>
</tr>
<tr>
<td>{@link VideoSurface.EnableFilpTextureApply EnableFilpTextureApply}</td>
<td>Enables/Disables the mirror mode when renders the Texture.</td>
</tr>
<tr>
<td>{@link VideoSurface.SetVideoSurfaceType SetVideoSurfaceType}</td>
<td>Set the video renderer type.</td>
</tr>
<tr>
<td>{@link VideoSurface.SetEnable SetEnable}</td>
<td>Starts/Stops the video rendering.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetCallId GetCallId}</td>
<td>Retrieves the current call ID.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.Rate Rate}</td>
<td>Allows the user to rate the call and is called after the call ends.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.Complain Complain}</td>
<td>Allows a user to complain about the call quality after a call ends.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetSdkVersion GetSdkVersion}</td>
<td>Gets the SDK version number.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLogFile SetLogFile}</td>
<td>Specifies an SDK output log file.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLogFilter SetLogFilter}</td>
<td>Sets the output log level of the SDK.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetLogFileSize SetLogFileSize}</td>
<td>Sets the log file size (KB).</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.GetErrorDescription GetErrorDescription}</td>
<td>Retrieves the description of a warning or error code.</td>
</tr>
</table>


### Miscellaneous Events

<table>
<tr>
<th>Event</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnSDKWarningHandler OnSDKWarningHandler}</td>
<td>Reports a warning during SDK runtime.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnSDKErrorHandler OnSDKErrorHandler}</td>
<td>Reports an error during SDK runtime.</td>
</tr>
<tr>
<td>{@link agora_gaming_rtc.OnApiExecutedHandler OnApiExecutedHandler}</td>
<td>Occurs when a method is executed by the SDK.</td>
</tr>
</table>


### Customized Methods

<table>
<tr>
<th>Method</th>
<th>Description</th>
</tr>
<tr>
<td>{@link agora_gaming_rtc.IRtcEngine.SetParameters SetParameters}</td>
<td>Provides the technical preview functionalities or special customizations by configuring the SDK with JSON options.</td>
</tr>
</table>

<a name="warn"></a>
## Warning Code

<table>
    <tr>
        <th>Warning Code</th>
        <th>Description</th>
    </tr>
    <tr>
        <td>WARN_INVALID_VIEW</td>
        <td>8: The specified view is invalid. Specify a view when using the video call function.</td>
    </tr>
    <tr>
        <td>WARN_INIT_VIDEO</td>
        <td>16: Failed to initialize the video function, possibly caused by a lack of resources. The users cannot see the video while the voice communication is not affected.</td>
    </tr>
    <tr>
        <td>WARN_PENDING</td>
        <td>20: The request is pending, usually due to some module not being ready, and the SDK postponed processing the request.</td>
    </tr>
    <tr>
        <td>WARN_NO_AVAILABLE_CHANNEL</td>
        <td>103: No channel resources are available. Maybe because the server cannot allocate any channel resource.</td>
    </tr>
    <tr>
        <td>WARN_LOOKUP_CHANNEL_TIMEOUT</td>
        <td>104: A timeout occurs when looking up the channel. When joining a channel, the SDK looks up the specified channel. This warning usually occurs when the network condition is too poor for the SDK to connect to the server.</td>
    </tr>
    <tr>
        <td>WARN_LOOKUP_CHANNEL_REJECTED</td>
        <td><B>DEPRECATED</B> 105: The server rejects the request to look up the channel. The server cannot process this request or the request is illegal.Deprecated as of v2.4.1. Use {@link agora_gaming_rtc.CONNECTION_CHANGED_REASON_TYPE#CONNECTION_CHANGED_REJECTED_BY_SERVER CONNECTION_CHANGED_REJECTED_BY_SERVER(10)} in the {@link agora_gaming_rtc.OnConnectionStateChangedHandler OnConnectionStateChangedHandler} callback instead.</td>
    </tr>
    <tr>
        <td>WARN_OPEN_CHANNEL_TIMEOUT</td>
        <td>106: A timeout occurs when opening the channel. Once the specific channel is found, the SDK opens the channel. This warning usually occurs when the network condition is too poor for the SDK to connect to the server.</td>
    </tr>
    <tr>
        <td>WARN_OPEN_CHANNEL_REJECTED</td>
        <td>107: The server rejects the request to open the channel. The server cannot process this request or the request is illegal.</td>
    </tr>
    <tr>
        <td>WARN_SWITCH_LIVE_VIDEO_TIMEOUT</td>
        <td>111: A timeout occurs when switching to the live video.</td>
    </tr>
    <tr>
        <td>WARN_SET_CLIENT_ROLE_TIMEOUT</td>
        <td>118: A timeout occurs when setting the client role in the live broadcast profile.</td>
    </tr>
    <tr>
        <td>WARN_OPEN_CHANNEL_INVALID_TICKET</td>
        <td>121: The ticket to open the channel is invalid.</td>
    </tr>
    <tr>
        <td>WARN_OPEN_CHANNEL_TRY_NEXT_VOS</td>
        <td>122: Try connecting to another server.</td>
    </tr>
    <tr>
        <td>WARN_AUDIO_MIXING_OPEN_ERROR</td>
        <td>701: An error occurs in opening the audio mixing file.</td>
    </tr>
    <tr>
        <td>WARN_ADM_RUNTIME_PLAYOUT_WARNING</td>
        <td>1014: Audio Device Module: A warning occurs in the playback device.</td>
    </tr>
    <tr>
        <td>WARN_ADM_RUNTIME_RECORDING_WARNING</td>
        <td>1016: Audio Device Module: A warning occurs in the recording device.</td>
    </tr>
    <tr>
        <td>WARN_ADM_RECORD_AUDIO_SILENCE</td>
        <td>1019: Audio Device Module: No valid audio data is collected.</td>
    </tr>
    <tr>
        <td>WARN_ADM_PLAYOUT_MALFUNCTION</td>
        <td>1020: Audio Device Module: The playback device fails.</td>
    </tr>
    <tr>
        <td>WARN_ADM_RECORD_MALFUNCTION</td>
        <td>1021: Audio Device Module: The recording device fails.</td>
    </tr>
    <tr>
        <td>WARN_ADM_IOS_CATEGORY_NOT_PLAYANDRECORD</td>
        <td>1029: During a call, the audio session category should be set to AVAudioSessionCategoryPlayAndRecord, and IRtcEngine monitors this value. If the audio session category is set to other values, this warning code is triggered and IRtcEngine will forcefully set it back to AVAudioSessionCategoryPlayAndRecord.</td>
    </tr>
    <tr>
        <td>WARN_ADM_RECORD_AUDIO_LOWLEVEL</td>
        <td>1031: Audio Device Module: The recorded audio voice is too low.</td>
    </tr>
    <tr>
        <td>WARN_ADM_PLAYOUT_AUDIO_LOWLEVEL</td>
        <td>1032: Audio Device Module: The playback audio voice is too low.</td>
    </tr>
    <tr>
        <td>WARN_ADM_WINDOWS_NO_DATA_READY_EVENT</td>
        <td>1040: Audio device module: An exception occurs with the audio drive. Solutions:<ul><li>Disable or re-enable the audio device. <li>Re-enable your device.<li>Update the sound card drive.</li></ul></td>
    </tr>
    <tr>
        <td>WARN_ADM_INCONSISTENT_AUDIO_DEVICE</td>
        <td>1042: Audio device module: The audio recording device is different from the audio playback device, which may cause echoes problem. Agora recommends using the same audio device to record and playback audio.</td>
    </tr>
    <tr>
        <td>WARN_APM_HOWLING</td>
        <td>1051: (Communication profile only) Audio Device Module: Howling is detected.</td>
    </tr>
    <tr>
        <td>WARN_ADM_GLITCH_STATE</td>
        <td>1052: Audio Device Module: The device is in the glitch state.</td>
    </tr>
    <tr>
        <td>WARN_ADM_IMPROPER_SETTINGS</td>
        <td>1053: Audio Device Module: The underlying audio settings have changed.</td>
    </tr>
    <tr>
        <td>WARN_ADM_WIN_CORE_NO_PLAYOUT_DEVICE</td>
        <td>1323: Audio device module: No available playback device. Solution: Plug in the audio device.</td>
    </tr>
    <tr>
        <td>WARN_ADM_WIN_CORE_IMPROPER_CAPTURE_RELEASE</td>
        <td>Audio device module: The capture device is released improperly. Solutions:Disable or re-enable the audio device.Re-enable your device.Update the sound card drive.</td>
    </tr>
    <tr>
        <td>WARN_SUPER_RESOLUTION_STREAM_OVER_LIMITATION</td>
        <td>1610: Super-resolution warning: The original video dimensions of the remote user exceed 640 &times; 480.</td>
    </tr>
    <tr>
        <td>WARN_SUPER_RESOLUTION_USER_COUNT_OVER_LIMITATION</td>
        <td>1611: Super-resolution warning: Another user is using super resolution.</td>
    </tr>
    <tr>
        <td>WARN_SUPER_RESOLUTION_DEVICE_NOT_SUPPORTED</td>
        <td>1612: The device is not supported.</td>
    </tr>
</table>

<a name="error"></a>
## Error Code

<table>
    <tr>
        <th>Error Code</th>
        <th>Description</th>
    </tr>
    <tr>
        <td>ERR_OK</td>
        <td>0: No error occurs.</td>
    </tr>
    <tr>
        <td>ERR_FAILED</td>
        <td>1: A general error occurs (no specified reason).</td>
    </tr>
    <tr>
        <td>ERR_INVALID_ARGUMENT</td>
        <td>2: An invalid parameter is used. For example, the specific channel name includes illegal characters.</td>
    </tr>
    <tr>
        <td>ERR_NOT_READY</td>
        <td>3: The SDK module is not ready. Possible solutions:<ul><li>Check the audio device.<li>Check the completeness of the application.<li>Re-initialize the RTC engine.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_NOT_SUPPORTED</td>
        <td>4: The SDK does not support this function.</td>
    </tr>
    <tr>
        <td>ERR_REFUSED</td>
        <td>5: The request is rejected.</td>
    </tr>
    <tr>
        <td>ERR_BUFFER_TOO_SMALL</td>
        <td>6: The buffer size is not big enough to store the returned data.</td>
    </tr>
    <tr>
        <td>ERR_NOT_INITIALIZED</td>
        <td>7: The SDK is not initialized before calling this method.</td>
    </tr>
    <tr>
        <td>ERR_NO_PERMISSION</td>
        <td>9: No permission exists. This is for internal SDK use only, and it does not return to the application through any method or callback.</td>
    </tr>
    <tr>
        <td>ERR_TIMEDOUT</td>
        <td>10: An API method timeout occurs. Some API methods require the SDK to return the execution result, and this error occurs if the request takes too long (more than 10 seconds) for the SDK to process.</td>
    </tr>
    <tr>
        <td>ERR_CANCELED</td>
        <td>11: The request is canceled. This is for internal SDK use only, and it does not return to the application through any method or callback.</td>
    </tr>
    <tr>
        <td>ERR_TOO_OFTEN</td>
        <td>12: The method is called too often. This is for internal SDK use only, and it does not return to the application through any method or callback.</td>
    </tr>
    <tr>
        <td>ERR_BIND_SOCKET</td>
        <td>13: The SDK fails to bind to the network socket. This is for internal SDK use only, and it does not return to the application through any method or callback.</td>
    </tr>
    <tr>
        <td>ERR_NET_DOWN</td>
        <td>14: The network is unavailable. This is for internal SDK use only, and it does not return to the application through any method or callback.</td>
    </tr>
    <tr>
        <td>ERR_NET_NOBUFS</td>
        <td>15: No network buffers are available. This is for internal SDK internal use only, and it does not return to the application through any method or callback.</td>
    </tr>
    <tr>
        <td>ERR_JOIN_CHANNEL_REJECTED</td>
        <td>17: The request to join the channel is rejected. This error usually occurs when the user is already in the channel, and still calls the method to join the channel, for example, {@link agora_gaming_rtc.IRtcEngine.JoinChannelByKey JoinChannelByKey}.</td>
    </tr>
    <tr>
        <td>ERR_LEAVE_CHANNEL_REJECTED</td>
        <td>18: The request to leave the channel is rejected. This error usually occurs:<ul><li>When the user has left the channel and still calls {@link agora_gaming_rtc.IRtcEngine.LeaveChannel LeaveChannel} to leave the channel. In this case, stop calling {@link agora_gaming_rtc.IRtcEngine.LeaveChannel LeaveChannel}.<li>When the user has not joined the channel and still calls `LeaveChannel` to leave the channel. In this case, no extra operation is needed.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ALREADY_IN_USE</td>
        <td>19: Resources are occupied and cannot be reused.</td>
    </tr>
    <tr>
        <td>ERR_ABORTED</td>
        <td>20: The SDK gives up the request due to too many requests.</td>
    </tr>
    <tr>
        <td>ERR_INIT_NET_ENGINE</td>
        <td>21: In Windows, specific firewall settings can cause the SDK to fail to initialize and crash.</td>
    </tr>
    <tr>
        <td>ERR_RESOURCE_LIMITED</td>
        <td>22: The application uses too much of the system resources and the SDK fails to allocate the resources.</td>
    </tr>
    <tr>
        <td>ERR_INVALID_APP_ID</td>
        <td>101: The specified App ID is invalid. Please try to rejoin the channel with a valid App ID.</td>
    </tr>
    <tr>
        <td>ERR_INVALID_CHANNEL_NAME</td>
        <td>102: The specified channel name is invalid. Please try to rejoin the channel with a valid channel name.</td>
    </tr>
    <tr>
        <td>ERR_TOKEN_EXPIRED</td>
        <td><B>DEPRECATED</B> 109: Deprecated as of v2.4.1. Use {@link agora_gaming_rtc.CONNECTION_CHANGED_REASON_TYPE#CONNECTION_CHANGED_TOKEN_EXPIRED CONNECTION_CHANGED_TOKEN_EXPIRED(9)} in the {@link agora_gaming_rtc.OnConnectionStateChangedHandler OnConnectionStateChangedHandler} callback instead. The token expired due to one of the following reasons:<ul><li>Authorized Timestamp expired: The timestamp is represented by the number of seconds elapsed since 1/1/1970. The user can use the Token to access the Agora service within 24 hours after the Token is generated. If the user does not access the Agora service after 24 hours, this Token is no longer valid. <li>Call Expiration Timestamp expired: The timestamp is the exact time when a user can no longer use the Agora service (for example, when a user is forced to leave an ongoing call). When a value is set for the Call Expiration Timestamp, it does not mean that the token will expire, but that the user will be banned from the channel.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_INVALID_TOKEN</td>
        <td><B>DEPRECATED</B> 110: Deprecated as of v2.4.1. Use {@link agora_gaming_rtc.CONNECTION_CHANGED_REASON_TYPE#CONNECTION_CHANGED_INVALID_TOKEN CONNECTION_CHANGED_INVALID_TOKEN(8)} in the {@link agora_gaming_rtc.OnConnectionStateChangedHandler OnConnectionStateChangedHandler} callback instead. The token is invalid due to one of the following reasons: <ul><li>The App Certificate for the project is enabled in Console, but the user is still using the App ID. Once the App Certificate is enabled, the user must use a token. <li>The uid is mandatory, and users must set the same uid as the one set in the {@link agora_gaming_rtc.IRtcEngine.JoinChannelByKey JoinChannelByKey} method.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_CONNECTION_INTERRUPTED</td>
        <td>111: The internet connection is interrupted. This applies to the Agora Web SDK only.</td>
    </tr>
    <tr>
        <td>ERR_CONNECTION_LOST</td>
        <td>112: The internet connection is lost. This applies to the Agora Web SDK only.</td>
    </tr>
    <tr>
        <td>ERR_NOT_IN_CHANNEL</td>
        <td>113: The user is not in the channel when calling the {@link agora_gaming_rtc.IRtcEngine.SendStreamMessage SendStreamMessage} or {@link agora_gaming_rtc.IRtcEngine.GetUserInfoByUserAccount GetUserInfoByUserAccount} method.</td>
    </tr>
    <tr>
        <td>ERR_SIZE_TOO_LARGE</td>
        <td>114: The size of the sent data is over 1024 bytes when the user calls the {@link agora_gaming_rtc.IRtcEngine.SendStreamMessage SendStreamMessage} method.</td>
    </tr>
    <tr>
        <td>ERR_BITRATE_LIMIT</td>
        <td>115: The bitrate of the sent data exceeds the limit of 6 Kbps when the user calls the {@link agora_gaming_rtc.IRtcEngine.SendStreamMessage SendStreamMessage} method.</td>
    </tr>
    <tr>
        <td>ERR_TOO_MANY_DATA_STREAMS</td>
        <td>116: Too many data streams (over 5 streams) are created when the user calls the {@link agora_gaming_rtc.IRtcEngine.CreateDataStream CreateDataStream} method.</td>
    </tr>
    <tr>
        <td>ERR_STREAM_MESSAGE_TIMEOUT</td>
        <td>117: The data stream transmission timed out.</td>
    </tr>
    <tr>
        <td>ERR_SET_CLIENT_ROLE_NOT_AUTHORIZED</td>
        <td>119: Switching roles fail. Please try to rejoin the channel.</td>
    </tr>
    <tr>
        <td>ERR_DECRYPTION_FAILED</td>
        <td>120: Decryption fails. The user may have used a different encryption password to join the channel. Check your settings or try rejoining the channel.</td>
    </tr>
    <tr>
        <td>ERR_CLIENT_IS_BANNED_BY_SERVER</td>
        <td>123: The client is banned by the server.</td>
    </tr>
    <tr>
        <td>ERR_WATERMARK_PARAM</td>
        <td>124: Incorrect watermark file parameter.</td>
    </tr>
    <tr>
        <td>ERR_WATERMARK_PATH</td>
        <td>125: Incorrect watermark file path.</td>
    </tr>
    <tr>
        <td>ERR_WATERMARK_PNG</td>
        <td>126: Incorrect watermark file format.</td>
    </tr>
    <tr>
        <td>ERR_WATERMARKR_INFO</td>
        <td>127: Incorrect watermark file information.</td>
    </tr>
    <tr>
        <td>ERR_WATERMARK_ARGB</td>
        <td>128: Incorrect watermark file data format.</td>
    </tr>
    <tr>
        <td>ERR_WATERMARK_READ</td>
        <td>129: An error occurs in reading the watermark file.</td>
    </tr>
    <tr>
        <td>ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH</td>
        <td>130: Encryption is enabled when the user calls the {@link agora_gaming_rtc.IRtcEngine.AddPublishStreamUrl AddPublishStreamUrl} method (CDN live streaming does not support encrypted streams).</td>
    </tr>
    <tr>
        <td>ERR_INVALID_USER_ACCOUNT</td>
        <td>134: The user account is invalid.</td>
    </tr>
    <tr>
        <td>ERR_PUBLISH_STREAM_CDN_ERROR</td>
        <td>151: CDN related errors. Remove the original URL address and add a new one by calling the {@link agora_gaming_rtc.IRtcEngine.RemovePublishStreamUrl RemovePublishStreamUrl} and {@link agora_gaming_rtc.IRtcEngine.AddPublishStreamUrl AddPublishStreamUrl} methods.</td>
    </tr>
    <tr>
        <td>ERR_PUBLISH_STREAM_NUM_REACH_LIMIT</td>
        <td>152: The host publishes more than 10 URLs. Delete the unnecessary URLs before adding new ones.</td>
    </tr>
    <tr>
        <td>ERR_PUBLISH_STREAM_NOT_AUTHORIZED</td>
        <td>153: The host manipulates other hosts' URLs. Check your app logic.</td>
    </tr>
    <tr>
        <td>ERR_PUBLISH_STREAM_INTERNAL_SERVER_ERROR</td>
        <td>154: An error occurs in Agora's streaming server. Call the addPublishStreamUrl method to publish the streaming again.</td>
    </tr>
    <tr>
        <td>ERR_PUBLISH_STREAM_NOT_FOUND</td>
        <td>155: The server fails to find the stream.</td>
    </tr>
    <tr>
        <td>ERR_PUBLISH_STREAM_FORMAT_NOT_SUPPORTED</td>
        <td>156: The format of the RTMP stream URL is not supported. Check whether the URL format is correct.</td>
    </tr>
    <tr>
        <td>ERR_LOAD_MEDIA_ENGINE</td>
        <td>1001: Fails to load the media engine.</td>
    </tr>
    <tr>
        <td>ERR_START_CALL</td>
        <td>1002: Fails to start the call after enabling the media engine.</td>
    </tr>
    <tr>
        <td>ERR_START_CAMERA</td>
        <td><B>DEPRECATED</B> 1003: Fails to start the camera. Deprecated as of v2.4.1. Use {@link agora_gaming_rtc.LOCAL_VIDEO_STREAM_ERROR#LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE(4)} in the {@link agora_gaming_rtc.OnConnectionStateChangedHandler OnConnectionStateChangedHandler} callback instead.</td>
    </tr>
    <tr>
        <td>ERR_START_VIDEO_RENDER</td>
        <td>1004: Fails to start the video rendering module.</td>
    </tr>
    <tr>
        <td>ERR_ADM_GENERAL_ERROR</td>
        <td>1005: A general error occurs in the Audio Device Module (no specified reason). Check if the audio device is used by another application, or try rejoining the channel.</td>
    </tr>
    <tr>
        <td>ERR_ADM_JAVA_RESOURCE</td>
        <td>1006: Audio Device Module: An error occurs in using the Java resources.</td>
    </tr>
    <tr>
        <td>ERR_ADM_SAMPLE_RATE</td>
        <td>1007: Audio Device Module: An error occurs in setting the sampling frequency.</td>
    </tr>
    <tr>
        <td>ERR_ADM_INIT_PLAYOUT</td>
        <td>1008: Audio Device Module: An error occurs in initializing the playback device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_START_PLAYOUT</td>
        <td>1009: Audio Device Module: An error occurs in starting the playback device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_STOP_PLAYOUT</td>
        <td>1010: Audio Device Module: An error occurs in stopping the playback device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_INIT_RECORDING</td>
        <td>1011: Audio Device Module: An error occurs in initializing the recording device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_START_RECORDING</td>
        <td>1012: Audio Device Module: An error occurs in starting the recording device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_STOP_RECORDING</td>
        <td>1013: Audio Device Module: An error occurs in stopping the recording device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_RUNTIME_PLAYOUT_ERROR</td>
        <td>1015: Audio Device Module: A playback error occurs. Check your playback device and try rejoining the channel.</td>
    </tr>
    <tr>
        <td>ERR_ADM_RUNTIME_RECORDING_ERROR</td>
        <td>1017: Audio Device Module: A recording error occurs.</td>
    </tr>
    <tr>
        <td>ERR_ADM_RECORD_AUDIO_FAILED</td>
        <td>1018: Audio Device Module: Fails to record.</td>
    </tr>
    <tr>
        <td>ERR_ADM_INIT_LOOPBACK</td>
        <td>1022: Audio Device Module: An error occurs in initializing the loopback device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_START_LOOPBACK</td>
        <td>1023: Audio Device Module: An error occurs in starting the loopback device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_NO_PERMISSION</td>
        <td>1027: Audio Device Module: No recording permission exists. Check if the recording permission is granted.</td>
    </tr>
    <tr>
        <td>ERR_ADM_RECORD_AUDIO_IS_ACTIVE</td>
        <td>1033: Audio device module: The device is occupied.</td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_JNI_JAVA_RESOURCE</td>
        <td>1101: Audio device module: A fatal exception occurs.</td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_JNI_NO_RECORD_FREQUENCY</td>
        <td>1108: Audio device module: The recording frequency is lower than 50. 0 indicates that the recording is not yet started. We recommend checking your recording permission.</td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_JNI_NO_PLAYBACK_FREQUENCY</td>
        <td>1109: The playback frequency is lower than 50. 0 indicates that the playback is not yet started. We recommend checking if you have created too many AudioTrack instances.</td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_JNI_JAVA_START_RECORD</td>
        <td>1111: Audio device module: AudioRecord fails to start up. A ROM system error occurs. We recommend the following options to debug:<ul><li>Restart your App.<li>Restart your cellphone.<li>Check your recording permission.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_JNI_JAVA_START_PLAYBACK</td>
        <td>1112: Audio device module: AudioTrack fails to start up. A ROM system error occurs. We recommend the following options to debug:<ul><li>Restart your App.<li>Restart your cellphone.<li>Check your playback permission.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_JNI_JAVA_RECORD_ERROR</td>
        <td>1115: Audio device module: AudioRecord returns error. The SDK will automatically restart AudioRecord.</td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_OPENSL_CREATE_ENGINE</td>
        <td><B>DEPRECATED</B></td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_OPENSL_CREATE_AUDIO_RECORDER</td>
        <td><B>DEPRECATED</B></td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_OPENSL_START_RECORDER_THREAD</td>
        <td><B>DEPRECATED</B></td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_OPENSL_CREATE_AUDIO_PLAYER</td>
        <td><B>DEPRECATED</B></td>
    </tr>
    <tr>
        <td>ERR_ADM_ANDROID_OPENSL_START_PLAYER_THREAD</td>
        <td><B>DEPRECATED</B></td>
    </tr>
    <tr>
        <td>ERR_ADM_IOS_INPUT_NOT_AVAILABLE</td>
        <td>1201: Audio device module: The current device does not support audio input, possibly because you have mistakenly configured the audio session category, or because some other app is occupying the input device. We recommend terminating all background apps and re-joining the channel.</td>
    </tr>
    <tr>
        <td>ERR_ADM_IOS_ACTIVATE_SESSION_FAIL</td>
        <td>1206: Audio device module: Cannot activate the Audio Session.</td>
    </tr>
    <tr>
        <td>ERR_ADM_IOS_VPIO_INIT_FAIL</td>
        <td>1210: Audio device module: Fails to initialize the audio device, normally because the audio device parameters are wrongly set.</td>
    </tr>
    <tr>
        <td>ERR_ADM_IOS_VPIO_REINIT_FAIL</td>
        <td>1213: Audio device module: Fails to re-initialize the audio device, normally because the audio device parameters are wrongly set.</td>
    </tr>
    <tr>
        <td>ERR_ADM_IOS_VPIO_RESTART_FAIL</td>
        <td>1214: Fails to re-start up the Audio Unit, possibly because the audio session category is not compatible with the settings of the Audio Unit.</td>
    </tr>
    <tr>
        <td>ERR_ADM_IOS_SESSION_SAMPLERATR_ZERO</td>
        <td><B>DEPRECATED</B></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_INIT</td>
        <td>1301: Audio device module: An audio driver abnomality or a compatibility issue occurs. Solutions: Disable and restart the audio device, or reboot the system.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_INIT_RECORDING</td>
        <td>1303: Audio device module: A recording driver abnomality or a compatibility issue occurs. Solutions: Disable and restart the audio device, or reboot the system.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_INIT_PLAYOUT</td>
        <td>1306: Audio device module: A playout driver abnomality or a compatibility issue occurs. Solutions: Disable and restart the audio device, or reboot the system.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_INIT_PLAYOUT_NULL</td>
        <td>1307: Audio device module: No audio device is available. Solutions: Plug in a proper audio device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_START_RECORDING</td>
        <td>1309: Audio device module: An audio driver abnomality or a compatibility issue occurs. Solutions: Disable and restart the audio device, or reboot the system.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_CREATE_REC_THREAD</td>
        <td>1311: Audio device module: Insufficient system memory or poor device performance. Solutions: Reboot the system or replace the device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_CAPTURE_NOT_STARTUP</td>
        <td>1314: Audio device module: An audio driver abnormality occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Upgrade your audio card driver.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_CREATE_RENDER_THREAD</td>
        <td>1319: Audio device module: Insufficient system memory or poor device performance. Solutions: Reboot the system or replace the device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_RENDER_NOT_STARTUP</td>
        <td>1320: Audio device module: An audio driver abnormality occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Replace the device.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_NO_RECORDING_DEVICE</td>
        <td>1322: Audio device module: No audio sampling device is available. Solutions: Plug in a proper recording device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_CORE_NO_PLAYOUT_DEVICE</td>
        <td>1323: Audio device module: No audio playout device is available. Solutions: Plug in a proper playback device.</td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_WAVE_INIT</td>
        <td>1351: Audio device module: An audio driver abnormality or a compatibility issue occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Upgrade your audio card driver.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_WAVE_INIT_RECORDING</td>
        <td>1353: Audio device module: An audio driver abnormality occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Upgrade your audio card driver.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_WAVE_INIT_MICROPHONE</td>
        <td>1354: Audio device module: An audio driver abnormality occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Upgrade your audio card driver.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_WAVE_INIT_PLAYOUT</td>
        <td>1355: Audio device module: An audio driver abnormality occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Upgrade your audio card driver.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_WAVE_INIT_SPEAKER</td>
        <td>1356: Audio device module: An audio driver abnormality occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Upgrade your audio card driver.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_WAVE_START_RECORDING</td>
        <td>1357: Audio device module: An audio driver abnormality occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Upgrade your audio card driver.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_WIN_WAVE_START_PLAYOUT</td>
        <td>1358: Audio device module: An audio driver abnormality occurs. Solutions:<ul><li>Disable and then re-enable the audio device.<li>Reboot the system.<li>Upgrade your audio card driver.</li></ul></td>
    </tr>
    <tr>
        <td>ERR_ADM_NO_RECORDING_DEVICE</td>
        <td>1359: Audio Device Module: No recording device exists.</td>
    </tr>
    <tr>
        <td>ERR_ADM_NO_PLAYOUT_DEVICE</td>
        <td>1360: Audio Device Module: No playback device exists.</td>
    </tr>
    <tr>
        <td>ERR_VDM_CAMERA_NOT_AUTHORIZED</td>
        <td>1501: Video Device Module: The camera is unauthorized.</td>
    </tr>
    <tr>
        <td>ERR_VDM_WIN_DEVICE_IN_USE</td>
        <td><B>DEPRECATED</B> 1502: Video Device Module: The camera in use. Deprecated as of v2.4.1. Use {@link agora_gaming_rtc.LOCAL_VIDEO_STREAM_ERROR#LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY(3)} in the {@link agora_gaming_rtc.OnConnectionStateChangedHandler OnConnectionStateChangedHandler} callback instead.</td>
    </tr>
    <tr>
        <td>ERR_VCM_UNKNOWN_ERROR</td>
        <td>1600: Video Device Module: An unknown error occurs.</td>
    </tr>
    <tr>
        <td>ERR_VCM_ENCODER_INIT_ERROR</td>
        <td>1601: Video Device Module: An error occurs in initializing the video encoder.</td>
    </tr>
    <tr>
        <td>ERR_VCM_ENCODER_ENCODE_ERROR</td>
        <td>1602: Video Device Module: An error occurs in encoding.</td>
    </tr>
    <tr>
        <td>ERR_VCM_ENCODER_SET_ERROR</td>
        <td>1603: Video Device Module: An error occurs in setting the video encoder.</td>
    </tr>
</table>
