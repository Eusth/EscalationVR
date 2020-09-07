using System;
using System.IO;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000DE RID: 222
	public static class RenderTextureExtensions
	{
		// Token: 0x06000590 RID: 1424 RVA: 0x0001BA90 File Offset: 0x00019C90
		public static void SaveToFile(this global::UnityEngine.RenderTexture renderTexture, string name)
		{
			global::UnityEngine.RenderTexture active = global::UnityEngine.RenderTexture.active;
			global::UnityEngine.RenderTexture.active = renderTexture;
			global::UnityEngine.Texture2D texture2D = new global::UnityEngine.Texture2D(renderTexture.width, renderTexture.height);
			texture2D.ReadPixels(new global::UnityEngine.Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), 0, 0);
			byte[] array = global::UnityEngine.ImageConversion.EncodeToPNG(texture2D);
			global::System.IO.File.WriteAllBytes(name, array);
			global::UnityEngine.Object.Destroy(texture2D);
			global::UnityEngine.RenderTexture.active = active;
		}
	}
}
