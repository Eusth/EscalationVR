using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000A7 RID: 167
	public class ScreenGrabber : global::VRGIN.Core.IScreenGrabber
	{
		// Token: 0x06000332 RID: 818 RVA: 0x00011824 File Offset: 0x0000FA24
		public static global::VRGIN.Core.ScreenGrabber.JudgingMethod FromList(global::System.Collections.Generic.IEnumerable<global::UnityEngine.Camera> allowedCameras)
		{
			return (global::UnityEngine.Camera camera) => global::System.Linq.Enumerable.Contains<global::UnityEngine.Camera>(allowedCameras, camera);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0001184C File Offset: 0x0000FA4C
		public static global::VRGIN.Core.ScreenGrabber.JudgingMethod FromList(params string[] allowedCameraNames)
		{
			return (global::UnityEngine.Camera camera) => global::System.Linq.Enumerable.Contains<string>(allowedCameraNames, camera.name);
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00011872 File Offset: 0x0000FA72
		// (set) Token: 0x06000335 RID: 821 RVA: 0x0001187A File Offset: 0x0000FA7A
		public global::UnityEngine.RenderTexture Texture { get; private set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00011883 File Offset: 0x0000FA83
		// (set) Token: 0x06000337 RID: 823 RVA: 0x0001188B File Offset: 0x0000FA8B
		public int Height { get; private set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000338 RID: 824 RVA: 0x00011894 File Offset: 0x0000FA94
		// (set) Token: 0x06000339 RID: 825 RVA: 0x0001189C File Offset: 0x0000FA9C
		public int Width { get; private set; }

		// Token: 0x0600033A RID: 826 RVA: 0x000118A8 File Offset: 0x0000FAA8
		public ScreenGrabber(int width, int height, global::VRGIN.Core.ScreenGrabber.JudgingMethod method)
		{
			this.Texture = new global::UnityEngine.RenderTexture(width, height, 24, 7);
			this.Width = width;
			this.Height = height;
			this._Judge = method;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000118FC File Offset: 0x0000FAFC
		public bool Check(global::UnityEngine.Camera camera)
		{
			return this._Judge(camera);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0001191A File Offset: 0x0000FB1A
		public global::System.Collections.Generic.IEnumerable<global::UnityEngine.RenderTexture> GetTextures()
		{
			yield return this.Texture;
			yield break;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0001192A File Offset: 0x0000FB2A
		public void OnAssign(global::UnityEngine.Camera camera)
		{
		}

		// Token: 0x0400056A RID: 1386
		private global::System.Collections.Generic.IList<global::UnityEngine.Camera> _Cameras = new global::System.Collections.Generic.List<global::UnityEngine.Camera>();

		// Token: 0x0400056B RID: 1387
		private global::System.Collections.Generic.HashSet<global::UnityEngine.Camera> _CheckedCameras = new global::System.Collections.Generic.HashSet<global::UnityEngine.Camera>();

		// Token: 0x0400056F RID: 1391
		private global::VRGIN.Core.ScreenGrabber.JudgingMethod _Judge;

		// Token: 0x020001F9 RID: 505
		// (Invoke) Token: 0x06000A71 RID: 2673
		public delegate bool JudgingMethod(global::UnityEngine.Camera camera);
	}
}
