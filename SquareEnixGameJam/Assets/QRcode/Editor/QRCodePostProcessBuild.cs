#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;
#endif

public class QRCodePostProcessBuild 
{
	private const bool ENABLED = true;

	private const string PHOTO_LIBRARY_USAGE_DESCRIPTION = "Save media to Photos";
	private const string CAMERA_USAGE_DESCRIPTION = "Open Camera to get data of devicecamera !";

#if UNITY_IOS
#pragma warning disable 0162
	[PostProcessBuild]
	public static void OnPostprocessBuild( BuildTarget target, string buildPath )
	{
		if( !ENABLED )
			return;

		if( target == BuildTarget.iOS )
		{
			string pbxProjectPath = PBXProject.GetPBXProjectPath( buildPath );
			string plistPath = Path.Combine( buildPath, "Info.plist" );


			PlistDocument plist = new PlistDocument();
			plist.ReadFromString( File.ReadAllText( plistPath ) );

			PlistElementDict rootDict = plist.root;
			rootDict.SetString( "NSPhotoLibraryUsageDescription", PHOTO_LIBRARY_USAGE_DESCRIPTION );
			rootDict.SetString( "NSPhotoLibraryAddUsageDescription", PHOTO_LIBRARY_USAGE_DESCRIPTION );
			rootDict.SetString( "NSCameraUsageDescription", CAMERA_USAGE_DESCRIPTION );


			File.WriteAllText( plistPath, plist.WriteToString() );
		}
	}
#pragma warning restore 0162
#endif
}