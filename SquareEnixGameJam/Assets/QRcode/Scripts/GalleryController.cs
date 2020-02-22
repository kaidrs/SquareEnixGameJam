using System;
using System.IO;
using UnityEngine;

public class GalleryController : MonoBehaviour {
	
	private string androidImagePath = string.Empty;
	#if !UNITY_EDITOR && UNITY_IOS
	[System.Runtime.InteropServices.DllImport( "__Internal" )]
	private static extern void SaveImageToAlbum(string path);
	#endif

	public string GalleryPath
	{
		get
		{
			return this.androidImagePath;
		}
	}

	private void Start()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			this.SetGalleryPath();
		}
	}

	private void SetGalleryPath()
	{
		if (Application.platform == RuntimePlatform.Android && Application.platform == RuntimePlatform.Android)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.ToolBar.EasyWebCam.EasyWebCam");
			androidJavaClass.CallStatic("getGalleryPath", new object[]
				{
					base.gameObject.name
				});
		}
	}

	/// <summary>
	/// Androids the gallery path. get the back call func 
	/// </summary>
	/// <param name="androidPath">Android path.</param>
	private void receiveGalleryPath(string androidPath)
	{
		this.androidImagePath = androidPath;
		if (!Directory.Exists(this.androidImagePath))
		{
			Directory.CreateDirectory(this.androidImagePath);
		}
	}

	public void Refresh(string path)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.ToolBar.EasyWebCam.EasyWebCam");
			androidJavaClass.CallStatic("Refresh", new object[]
				{
					path
				});
		}
	}

	public static void SaveImageToGallery(Texture2D qrCode)
	{
#if (!UNITY_WEBPLAYER) && (!UNITY_WEBGL)
        byte[] bytes = qrCode.EncodeToJPG();
		if (Application.platform == RuntimePlatform.Android) {
			GalleryController mediactr = UnityEngine.Object.FindObjectOfType<GalleryController> ();
			if (mediactr != null) {
				string aPath = mediactr.GalleryPath;
				if (!string.IsNullOrEmpty (aPath)) {
                    aPath = Path.Combine (aPath, "QRCode_" + DateTime.Now.ToFileTime () + ".jpg");
					try {
						File.WriteAllBytes (aPath, bytes);
						Debug.Log ("Saved : " + aPath);
					} catch  {

					}
					mediactr.Refresh (aPath);
				} else {
					Debug.Log ("Saved Code image Failed !");
				}
			}
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			
			string iPath = Application.persistentDataPath;
			iPath = Path.Combine( iPath, "QRCode" + DateTime.Now.ToFileTime () + ".jpg" );
			try {
				File.WriteAllBytes (iPath, bytes);
				Debug.Log ("Saved : " + iPath);
			} catch {
				Debug.Log ("Saved Code image Failed !");
			}

#if !UNITY_EDITOR && UNITY_IOS
			SaveImageToAlbum( iPath );
			Debug.Log( "Saving to Pictures: " + Path.GetFileName( iPath ) );
#endif
		}                  	
		else if (Application.platform == RuntimePlatform.WindowsPlayer 
			|| Application.platform == RuntimePlatform.OSXPlayer 
			|| Application.platform == RuntimePlatform.LinuxPlayer 
			|| Application.platform == RuntimePlatform.OSXEditor 
			|| Application.platform == RuntimePlatform.WindowsEditor)
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			text = Path.Combine(text, "QRCode" + DateTime.Now.ToFileTime() + ".jpg");
			try
			{
				File.WriteAllBytes(text, bytes);
				Debug.Log("Saved : " + text);
			}
			catch
			{

			}
		}
#endif
    }

}
