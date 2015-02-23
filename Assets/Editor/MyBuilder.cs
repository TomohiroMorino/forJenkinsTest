using UnityEngine;
using UnityEditor;
using System.Collections;

public class MyBuilder : MonoBehaviour {
	
	[UnityEditor.MenuItem("Tools/Build Project AllScene Android")]
	public static void BuildProjectAllSceneAndroid() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
		string[] allScene = new string[EditorBuildSettings.scenes.Length];
		int i = 0;
		foreach( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ){
			allScene[i] = scene.path;
			i++;
		}	
		PlayerSettings.bundleIdentifier = "com.unity3d.forjenkinstest";//"jp.co.hoge.hoge";
		PlayerSettings.statusBarHidden = true;
		BuildPipeline.BuildPlayer( allScene,
		                          "hoge.apk",
		                          BuildTarget.Android,
		                          BuildOptions.None
		                          );
	}
	
	[UnityEditor.MenuItem("Tools/Build Project AllScene iOS")]
	public static void BuildProjectAllSceneiOS() {	
		Debug.Log("##########iOS Build Start#########");
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.iPhone );
		string[] allScene = new string[EditorBuildSettings.scenes.Length];
		int i = 0;
		foreach( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ){
			allScene[i] = scene.path;
			i++;
		}
		
		BuildOptions opt = BuildOptions.SymlinkLibraries |
			BuildOptions.AllowDebugging |
				BuildOptions.ConnectWithProfiler |
				BuildOptions.Development;
		
		//BUILD for Device
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK;
		PlayerSettings.bundleIdentifier = "com.unity3d.forjenkinstest";//"jp.co.hoge.hoge";
		PlayerSettings.statusBarHidden = true;
		string errorMsg_Device = BuildPipeline.BuildPlayer( 
		                                                   allScene,
		                                                   "hoge4iOSDevice",
		                                                   BuildTarget.iPhone,
		                                                   opt
		                                                   );
		
		if (string.IsNullOrEmpty(errorMsg_Device)){
			
		} else {
			//エラー処理適当に		
		}
		
		
		//BUILD for Simulator
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.SimulatorSDK;
		//あとはDeviceビルドと同様に。
	}
}
