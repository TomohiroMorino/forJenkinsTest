using UnityEngine;
using UnityEditor;
using System.Collections;

/*
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
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.iOS );
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
		PlayerSettings.bundleIdentifier = "jp.co.tayutau.lf.dev";//"com.unity3d.forjenkinstest";//"jp.co.hoge.hoge";
		PlayerSettings.statusBarHidden = true;
		string errorMsg_Device = BuildPipeline.BuildPlayer( 
		                                                   allScene,
		                                                   "hoge4iOSDevice",
		                                                   BuildTarget.iOS,
		                                                   opt
		                                                   );
		
		if (string.IsNullOrEmpty(errorMsg_Device)){
			
		} else {
			//エラー処理適当に		
		}
		
		

		//BUILD for Simulator 
		//Simulatorでも見られるように XCODEプロジェクトを別途用意。
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.SimulatorSDK;
		//あとはDeviceビルドと同様に。
		string errorMsg_Simulator = BuildPipeline.BuildPlayer( 
		                                                      allScene,
		                                                      "hoge4iOSsimulator",
		                                                      BuildTarget.iOS,
		                                                      opt
		                                                      );
		if (string.IsNullOrEmpty(errorMsg_Simulator)){
			
		} else {
			//エラー処理適当に		
		}
	}
}*/

public class MyBuilder : MonoBehaviour {
	
	//[UnityEditor.MenuItem("Tools/Build Project AllScene Android")]
	public static void BuildProjectAllSceneAndroid() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
		string[] allScene = new string[EditorBuildSettings.scenes.Length];
		int i = 0;
		foreach( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ){
			allScene[i] = scene.path;
			i++;
		}	
		PlayerSettings.bundleIdentifier = "jp.co.tayutau.lf.dev";
		SetVersionForAndroidBuild ();//バージョンとバージョンコードもjenkins自動ビルド対応にする。
		PlayerSettings.statusBarHidden = true;
		BuildPipeline.BuildPlayer( allScene,
		                          "hoge.apk",
		                          BuildTarget.Android,
		                          BuildOptions.None
		                          );
	}
	static void SetVersionForAndroidBuild(){
		//バージョンとバージョンコードもjenkins自動ビルド対応にするためのメソッド。
		//引数がとれないので、System.Environment.GetCommandLineArgsメソッドで読むコマンドと同列で引数を記入してしまうという策をとっています。
		var commands = System.Environment.GetCommandLineArgs ();
		int methodIndex = -1;
		for (int i = 0; i < commands.Length; i++) {
			if (commands [i] == "MyBuilder.BuildProjectAllSceneAndroid") {
				methodIndex = i;
			}
		}
		var version = commands [methodIndex + 1];
		var versionCode = commands [methodIndex + 2];
		
		PlayerSettings.bundleVersion = version;
		PlayerSettings.Android.bundleVersionCode = int.Parse(versionCode);
	}
	
	
	
	
	
	//[UnityEditor.MenuItem("Tools/Build Project AllScene iOS")]
	public static void BuildProjectAllSceneiOS() {	
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.iOS );
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
		PlayerSettings.bundleIdentifier = "jp.co.tayutau.lf.dev";
		SetVersionForiOSBuild ();//バージョンとバージョンコードもjenkins自動ビルド対応にする。
		PlayerSettings.statusBarHidden = true;
		string errorMsg_Device = BuildPipeline.BuildPlayer( 
		                                                   allScene,
		                                                   "hoge4iOSDevice",
		                                                   BuildTarget.iOS,
		                                                   opt
		                                                   );
		
		if (string.IsNullOrEmpty(errorMsg_Device)){
			
		} else {
			//エラー処理適当に		
		}
		
		
		
		//BUILD for Simulator 
		//Simulatorでも見られるように XCODEプロジェクトを別途用意。
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.SimulatorSDK;
		//あとはDeviceビルドと同様に。
		string errorMsg_Simulator = BuildPipeline.BuildPlayer( 
		                                                      allScene,
		                                                      "hoge4iOSsimulator",
		                                                      BuildTarget.iOS,
		                                                      opt
		                                                      );
		if (string.IsNullOrEmpty(errorMsg_Simulator)){
			
		} else {
			//エラー処理適当に		
		}
	}
	
	static void SetVersionForiOSBuild(){
		//iOSバージョンもjenkins自動ビルド対応にするためのメソッド。
		//引数がとれないので、System.Environment.GetCommandLineArgsメソッドで読むコマンドと同列で引数を記入してしまうという策をとっています。
		var commands = System.Environment.GetCommandLineArgs ();
		int methodIndex = -1;
		for (int i = 0; i < commands.Length; i++) {
			if (commands [i] == "MyBuilder.BuildProjectAllSceneiOS") {
				methodIndex = i;
			}
		}
		var version = commands [methodIndex + 1];
		
		PlayerSettings.bundleVersion = version;
	}
	
	
}

