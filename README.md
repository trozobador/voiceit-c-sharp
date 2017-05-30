#VoiceIt C# wrapper
A Wrapper for using the VoiceIt Rest API.

##Setup
Simply download the [VoiceIt C-Sharp Library](https://github.com/voiceittech/voiceit-c-sharp/archive/master.zip) and include the VoiceIt.cs Class File in your project.

##Usage
Then initialize a VoiceIt Object like this with your own developer id
```csharp
/* Make Sure to add this at the top of your project */

using static VoiceIt;

var myVoiceIt = new VoiceIt("1d6361f81f3047ca8b0c0332ac0fb17d");
```
Finally use all other API Calls as documented on the [VoiceIt API Documentation](https://siv.voiceprintportal.com/apidocs.jsp) page.
