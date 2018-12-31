using System;
using System.IO;
namespace SharedProject
{
	public class MySharedCode
	{
		public string GetFilePath(string filename)
		{
			#if WINDOWS_UWP
				var FilePath=Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,filename);
			#else
				#if __ANDROID__
					string LibraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					var FilePath=Path.Combine(LibraryPath,filename);
				#endif
			#endif
			return FilePath;
		}
	}
}