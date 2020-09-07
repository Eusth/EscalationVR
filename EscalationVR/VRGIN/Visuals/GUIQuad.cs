using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Visuals
{
	// Token: 0x0200008B RID: 139
	public class GUIQuad : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x06000232 RID: 562 RVA: 0x0000DFA0 File Offset: 0x0000C1A0
		public static global::VRGIN.Visuals.GUIQuad Create(global::VRGIN.Core.IScreenGrabber source = null)
		{
			source = (source ?? global::VRGIN.Core.VR.GUI);
			global::VRGIN.Core.VRLog.Info("Create GUI", global::System.Array.Empty<object>());
			global::VRGIN.Visuals.GUIQuad guiquad = global::UnityEngine.GameObject.CreatePrimitive(5).AddComponent<global::VRGIN.Visuals.GUIQuad>();
			guiquad.name = "GUIQuad";
			bool flag = source != global::VRGIN.Core.VR.GUI;
			if (flag)
			{
				guiquad.gameObject.SetActive(false);
				guiquad._Source = source;
				guiquad.gameObject.SetActive(true);
			}
			guiquad.UpdateGUI();
			return guiquad;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000E020 File Offset: 0x0000C220
		protected override void OnAwake()
		{
			this.renderer = base.GetComponent<global::UnityEngine.Renderer>();
			this._Source = global::VRGIN.Core.VR.GUI;
			base.transform.localPosition = global::UnityEngine.Vector3.zero;
			base.transform.localRotation = global::UnityEngine.Quaternion.identity;
			base.gameObject.layer = global::UnityEngine.LayerMask.NameToLayer(global::VRGIN.Core.VRManager.Instance.Context.GuiLayer);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000E087 File Offset: 0x0000C287
		protected override void OnStart()
		{
			base.OnStart();
			this.UpdateAspect();
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000E098 File Offset: 0x0000C298
		protected virtual void OnEnable()
		{
			bool flag = this.IsGUISource();
			if (flag)
			{
				global::VRGIN.Core.VRLog.Info("Start listening to GUI ({0})", new object[]
				{
					base.name
				});
				global::VRGIN.Visuals.GUIQuadRegistry.Register(this);
				global::VRGIN.Core.VR.GUI.Listen();
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000E0E0 File Offset: 0x0000C2E0
		protected virtual void OnDisable()
		{
			bool flag = this.IsGUISource();
			if (flag)
			{
				global::VRGIN.Core.VRLog.Info("Stop listening to GUI ({0})", new object[]
				{
					base.name
				});
				global::VRGIN.Visuals.GUIQuadRegistry.Unregister(this);
				global::VRGIN.Core.VR.GUI.Unlisten();
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000E128 File Offset: 0x0000C328
		private bool IsGUISource()
		{
			return this._Source == global::VRGIN.Core.VR.GUI;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000E148 File Offset: 0x0000C348
		public virtual void UpdateAspect()
		{
			float y = base.transform.localScale.y;
			float num = y / (float)global::UnityEngine.Screen.height * (float)global::UnityEngine.Screen.width;
			base.transform.localScale = new global::UnityEngine.Vector3(num, y, 1f);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000E190 File Offset: 0x0000C390
		public virtual void UpdateGUI()
		{
			this.UpdateAspect();
			bool flag = !this.renderer;
			if (flag)
			{
				global::VRGIN.Core.VRLog.Warn("No renderer!", global::System.Array.Empty<object>());
			}
			try
			{
				this.renderer.receiveShadows = false;
				this.renderer.shadowCastingMode = 0;
				global::System.Collections.Generic.IEnumerable<global::UnityEngine.RenderTexture> textures = this._Source.GetTextures();
				global::VRGIN.Core.VRLog.Info("Updating GUI {0} with {1} textures", new object[]
				{
					base.name,
					global::System.Linq.Enumerable.Count<global::UnityEngine.RenderTexture>(textures)
				});
				bool flag2 = global::System.Linq.Enumerable.Count<global::UnityEngine.RenderTexture>(textures) >= 2;
				if (flag2)
				{
					this.renderer.material = global::VRGIN.Core.VR.Context.Materials.UnlitTransparentCombined;
					this.renderer.material.SetTexture("_MainTex", global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.RenderTexture>(textures));
					this.renderer.material.SetTexture("_SubTex", global::System.Linq.Enumerable.Last<global::UnityEngine.RenderTexture>(textures));
				}
				else
				{
					this.renderer.material = global::VRGIN.Core.VR.Context.Materials.UnlitTransparent;
					this.renderer.material.SetTexture("_MainTex", global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.RenderTexture>(textures));
				}
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Info(obj);
			}
		}

		// Token: 0x04000513 RID: 1299
		private global::UnityEngine.Renderer renderer;

		// Token: 0x04000514 RID: 1300
		public bool IsOwned = false;

		// Token: 0x04000515 RID: 1301
		private global::VRGIN.Core.IScreenGrabber _Source;
	}
}
