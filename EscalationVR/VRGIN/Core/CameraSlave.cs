using System;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000AD RID: 173
	public class CameraSlave : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x0600034C RID: 844 RVA: 0x00011B9C File Offset: 0x0000FD9C
		protected override void OnAwake()
		{
			base.OnAwake();
			global::UnityEngine.Camera camera = this.Camera;
			bool flag = !camera;
			if (flag)
			{
				global::VRGIN.Core.VRLog.Error("No camera found! {0}", new object[]
				{
					base.name
				});
				global::UnityEngine.Object.Destroy(this);
			}
			else
			{
				this.nearClipPlane = camera.nearClipPlane;
				this.farClipPlane = camera.farClipPlane;
				this.clearFlags = camera.clearFlags;
				this.renderingPath = camera.renderingPath;
				this.clearStencilAfterLightingPass = camera.clearStencilAfterLightingPass;
				this.depthTextureMode = camera.depthTextureMode;
				this.layerCullDistances = camera.layerCullDistances;
				this.layerCullSpherical = camera.layerCullSpherical;
				this.useOcclusionCulling = camera.useOcclusionCulling;
				this.backgroundColor = camera.backgroundColor;
				this.cullingMask = camera.cullingMask;
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00011C7C File Offset: 0x0000FE7C
		public void OnEnable()
		{
			try
			{
				global::VRGIN.Core.VR.Camera.RegisterSlave(this);
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Error(obj);
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00011CB8 File Offset: 0x0000FEB8
		public void OnDisable()
		{
			try
			{
				global::VRGIN.Core.VR.Camera.UnregisterSlave(this);
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Error(obj);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00011CF4 File Offset: 0x0000FEF4
		public global::UnityEngine.Camera Camera
		{
			get
			{
				return base.GetComponent<global::UnityEngine.Camera>();
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000350 RID: 848 RVA: 0x00011D0C File Offset: 0x0000FF0C
		// (set) Token: 0x06000351 RID: 849 RVA: 0x00011D14 File Offset: 0x0000FF14
		public float nearClipPlane { get; private set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000352 RID: 850 RVA: 0x00011D1D File Offset: 0x0000FF1D
		// (set) Token: 0x06000353 RID: 851 RVA: 0x00011D25 File Offset: 0x0000FF25
		public float farClipPlane { get; private set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000354 RID: 852 RVA: 0x00011D2E File Offset: 0x0000FF2E
		// (set) Token: 0x06000355 RID: 853 RVA: 0x00011D36 File Offset: 0x0000FF36
		public global::UnityEngine.CameraClearFlags clearFlags { get; private set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000356 RID: 854 RVA: 0x00011D3F File Offset: 0x0000FF3F
		// (set) Token: 0x06000357 RID: 855 RVA: 0x00011D47 File Offset: 0x0000FF47
		public global::UnityEngine.RenderingPath renderingPath { get; private set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00011D50 File Offset: 0x0000FF50
		// (set) Token: 0x06000359 RID: 857 RVA: 0x00011D58 File Offset: 0x0000FF58
		public bool clearStencilAfterLightingPass { get; private set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00011D61 File Offset: 0x0000FF61
		// (set) Token: 0x0600035B RID: 859 RVA: 0x00011D69 File Offset: 0x0000FF69
		public global::UnityEngine.DepthTextureMode depthTextureMode { get; private set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00011D72 File Offset: 0x0000FF72
		// (set) Token: 0x0600035D RID: 861 RVA: 0x00011D7A File Offset: 0x0000FF7A
		public float[] layerCullDistances { get; private set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00011D83 File Offset: 0x0000FF83
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00011D8B File Offset: 0x0000FF8B
		public bool layerCullSpherical { get; private set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00011D94 File Offset: 0x0000FF94
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00011D9C File Offset: 0x0000FF9C
		public bool useOcclusionCulling { get; private set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00011DA5 File Offset: 0x0000FFA5
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00011DAD File Offset: 0x0000FFAD
		public global::UnityEngine.Color backgroundColor { get; private set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00011DB6 File Offset: 0x0000FFB6
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00011DBE File Offset: 0x0000FFBE
		public int cullingMask { get; private set; }
	}
}
