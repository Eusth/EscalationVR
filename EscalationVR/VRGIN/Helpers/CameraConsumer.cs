using System;
using System.Collections.Generic;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Helpers
{
	// Token: 0x020000D3 RID: 211
	public class CameraConsumer : global::VRGIN.Core.IScreenGrabber
	{
		// Token: 0x06000541 RID: 1345 RVA: 0x0001A8C4 File Offset: 0x00018AC4
		public bool Check(global::UnityEngine.Camera camera)
		{
			return !camera.GetComponent("UICamera") && !camera.name.Contains("VR") && camera.targetTexture == null && (!camera.CompareTag("MainCamera") || !this._SpareMainCamera);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001A924 File Offset: 0x00018B24
		public global::System.Collections.Generic.IEnumerable<global::UnityEngine.RenderTexture> GetTextures()
		{
			yield return this._Texture;
			yield break;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001A934 File Offset: 0x00018B34
		public void OnAssign(global::UnityEngine.Camera camera)
		{
			bool softMode = this._SoftMode;
			if (softMode)
			{
				camera.cullingMask = 0;
				camera.nearClipPlane = 1f;
				camera.farClipPlane = 1f;
			}
			else
			{
				camera.enabled = false;
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0001A97A File Offset: 0x00018B7A
		public CameraConsumer(bool spareMainCamera = false, bool softMode = false)
		{
			this._SoftMode = softMode;
			this._SpareMainCamera = spareMainCamera;
			this._Texture = new global::UnityEngine.RenderTexture(1, 1, 0);
		}

		// Token: 0x0400065B RID: 1627
		private global::UnityEngine.RenderTexture _Texture;

		// Token: 0x0400065C RID: 1628
		private bool _SpareMainCamera;

		// Token: 0x0400065D RID: 1629
		private bool _SoftMode;
	}
}
