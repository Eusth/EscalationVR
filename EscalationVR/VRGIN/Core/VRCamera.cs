using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using VRGIN.Helpers;

namespace VRGIN.Core
{
	// Token: 0x020000AE RID: 174
	public class VRCamera : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00011DD0 File Offset: 0x0000FFD0
		// (set) Token: 0x06000368 RID: 872 RVA: 0x00011DD8 File Offset: 0x0000FFD8
		public global::SteamVR_Camera SteamCam { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00011DE4 File Offset: 0x0000FFE4
		public global::UnityEngine.Camera Blueprint
		{
			get
			{
				global::UnityEngine.Camera result;
				if (!this._Blueprint || !this._Blueprint.isActiveAndEnabled)
				{
					result = global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.Camera>(global::System.Linq.Enumerable.Select<global::VRGIN.Core.CameraSlave, global::UnityEngine.Camera>(this.Slaves, (global::VRGIN.Core.CameraSlave s) => s.Camera), (global::UnityEngine.Camera c) => !global::VRGIN.Core.VR.GUI.Owns(c));
				}
				else
				{
					result = this._Blueprint;
				}
				return result;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00011E66 File Offset: 0x00010066
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00011E6E File Offset: 0x0001006E
		private global::UnityEngine.Camera _Blueprint { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00011E78 File Offset: 0x00010078
		public bool HasValidBlueprint
		{
			get
			{
				return this.Slaves.Count > 0;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00011E98 File Offset: 0x00010098
		public global::UnityEngine.Transform Origin
		{
			get
			{
				return this.SteamCam.origin;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00011EB8 File Offset: 0x000100B8
		public global::UnityEngine.Transform Head
		{
			get
			{
				return this.SteamCam.head;
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600036F RID: 879 RVA: 0x00011ED8 File Offset: 0x000100D8
		// (remove) Token: 0x06000370 RID: 880 RVA: 0x00011F10 File Offset: 0x00010110
		[global::System.Diagnostics.DebuggerBrowsable(0)]
		public event global::System.EventHandler<global::VRGIN.Core.InitializeCameraEventArgs> InitializeCamera = delegate(object <p0>, global::VRGIN.Core.InitializeCameraEventArgs <p1>)
		{
		};

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000371 RID: 881 RVA: 0x00011F48 File Offset: 0x00010148
		// (remove) Token: 0x06000372 RID: 882 RVA: 0x00011F80 File Offset: 0x00010180
		[global::System.Diagnostics.DebuggerBrowsable(0)]
		public event global::System.EventHandler<global::VRGIN.Core.CopiedCameraEventArgs> CopiedCamera = delegate(object <p0>, global::VRGIN.Core.CopiedCameraEventArgs <p1>)
		{
		};

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00011FB8 File Offset: 0x000101B8
		public static global::VRGIN.Core.VRCamera Instance
		{
			get
			{
				bool flag = global::VRGIN.Core.VRCamera._Instance == null;
				if (flag)
				{
					global::VRGIN.Core.VRCamera._Instance = new global::UnityEngine.GameObject("VRGIN_Camera").AddComponent<global::UnityEngine.AudioListener>().gameObject.AddComponent<global::VRGIN.Core.VRCamera>();
				}
				return global::VRGIN.Core.VRCamera._Instance;
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00012000 File Offset: 0x00010200
		protected override void OnAwake()
		{
			global::VRGIN.Core.VRLog.Info("Creating VR Camera", global::System.Array.Empty<object>());
			this._Camera = base.gameObject.AddComponent<global::UnityEngine.Camera>();
			base.gameObject.AddComponent<global::SteamVR_Camera>();
			this.SteamCam = base.GetComponent<global::SteamVR_Camera>();
			this.SteamCam.Expand();
			bool flag = !global::VRGIN.Core.VR.Settings.MirrorScreen;
			if (flag)
			{
				global::UnityEngine.Object.Destroy(this.SteamCam.head.GetComponent<global::SteamVR_GameView>());
				global::UnityEngine.Object.Destroy(this.SteamCam.head.GetComponent<global::UnityEngine.Camera>());
			}
			global::SteamVR_Camera.sceneResolutionScale = global::VRGIN.Core.VR.Settings.RenderScale;
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("CenterEyeAnchor");
			gameObject.transform.SetParent(this.SteamCam.head);
			global::UnityEngine.Object.DontDestroyOnLoad(this.SteamCam.origin.gameObject);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000120DC File Offset: 0x000102DC
		public void Copy(global::UnityEngine.Camera blueprint, bool master = false, bool hasOtherConsumers = false)
		{
			global::VRGIN.Core.VRLog.Info("Copying camera: {0}", new object[]
			{
				blueprint ? blueprint.name : "NULL"
			});
			bool flag = blueprint && blueprint.GetComponent<global::VRGIN.Core.CameraSlave>();
			if (flag)
			{
				global::VRGIN.Core.VRLog.Warn("Is already slave -- NOOP", global::System.Array.Empty<object>());
			}
			else
			{
				bool flag2 = master && this.UseNewCamera(blueprint);
				if (flag2)
				{
					this._Blueprint = (blueprint ?? this._Camera);
					this.ApplyToCameras(delegate(global::UnityEngine.Camera targetCamera)
					{
						targetCamera.nearClipPlane = global::VRGIN.Core.VR.Context.NearClipPlane;
						targetCamera.farClipPlane = global::UnityEngine.Mathf.Max(this.Blueprint.farClipPlane, 10f);
						targetCamera.clearFlags = ((this.Blueprint.clearFlags == 1) ? 1 : 2);
						targetCamera.renderingPath = this.Blueprint.renderingPath;
						targetCamera.clearStencilAfterLightingPass = this.Blueprint.clearStencilAfterLightingPass;
						targetCamera.depthTextureMode = this.Blueprint.depthTextureMode;
						targetCamera.layerCullDistances = this.Blueprint.layerCullDistances;
						targetCamera.layerCullSpherical = this.Blueprint.layerCullSpherical;
						targetCamera.useOcclusionCulling = this.Blueprint.useOcclusionCulling;
						targetCamera.allowHDR = false;
						targetCamera.depth = this.Blueprint.depth;
						targetCamera.backgroundColor = this.Blueprint.backgroundColor;
						this.Blueprint.clearFlags = 2;
						global::UnityEngine.Skybox component2 = this.Blueprint.GetComponent<global::UnityEngine.Skybox>();
						bool flag6 = component2 != null;
						if (flag6)
						{
							global::UnityEngine.Skybox skybox = targetCamera.gameObject.GetComponent<global::UnityEngine.Skybox>();
							bool flag7 = skybox == null;
							if (flag7)
							{
								skybox = skybox.gameObject.AddComponent<global::UnityEngine.Skybox>();
							}
							skybox.material = component2.material;
						}
					});
				}
				bool flag3 = blueprint;
				if (flag3)
				{
					blueprint.gameObject.AddComponent<global::VRGIN.Core.CameraSlave>();
					global::UnityEngine.AudioListener component = blueprint.GetComponent<global::UnityEngine.AudioListener>();
					bool flag4 = component;
					if (flag4)
					{
						global::UnityEngine.Object.Destroy(component);
					}
					bool flag5 = !hasOtherConsumers && blueprint.targetTexture == null && global::VRGIN.Core.VR.Interpreter.IsIrrelevantCamera(blueprint);
					if (flag5)
					{
						blueprint.gameObject.AddComponent<global::VRGIN.Core.CameraKiller>();
					}
				}
				if (master)
				{
					this.InitializeCamera.Invoke(this, new global::VRGIN.Core.InitializeCameraEventArgs(base.GetComponent<global::UnityEngine.Camera>(), this.Blueprint));
				}
				this.CopiedCamera.Invoke(this, new global::VRGIN.Core.CopiedCameraEventArgs(blueprint));
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0001221C File Offset: 0x0001041C
		private bool UseNewCamera(global::UnityEngine.Camera blueprint)
		{
			bool flag = this._Blueprint && this._Blueprint != this._Camera && this._Blueprint != blueprint;
			if (flag)
			{
				bool flag2 = this._Blueprint.name == "Main Camera";
				if (flag2)
				{
					global::VRGIN.Core.VRLog.Info("Using {0} over {1} as main camera", new object[]
					{
						this._Blueprint.name,
						blueprint.name
					});
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x000122AC File Offset: 0x000104AC
		private void UpdateCameraConfig()
		{
			int num = global::System.Linq.Enumerable.Aggregate<global::VRGIN.Core.CameraSlave, int>(this.Slaves, 0, (int cull, global::VRGIN.Core.CameraSlave cam) => cull | cam.cullingMask);
			num |= global::VRGIN.Core.VR.Interpreter.DefaultCullingMask;
			num &= ~global::UnityEngine.LayerMask.GetMask(new string[]
			{
				global::VRGIN.Core.VR.Context.UILayer,
				global::VRGIN.Core.VR.Context.InvisibleLayer
			});
			num &= ~global::VRGIN.Core.VR.Context.IgnoreMask;
			string text = "The camera sees {0} ({1})";
			object[] array = new object[2];
			array[0] = string.Join(", ", global::VRGIN.Helpers.UnityHelper.GetLayerNames(num));
			array[1] = string.Join(", ", global::System.Linq.Enumerable.ToArray<string>(global::System.Linq.Enumerable.Select<global::VRGIN.Core.CameraSlave, string>(this.Slaves, (global::VRGIN.Core.CameraSlave s) => s.name)));
			global::VRGIN.Core.VRLog.Info(text, array);
			base.GetComponent<global::UnityEngine.Camera>().cullingMask = num;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00012397 File Offset: 0x00010597
		public void CopyFX(global::UnityEngine.Camera blueprint)
		{
			this.CopyFX(blueprint.gameObject, base.gameObject, true);
			this.FixEffectOrder();
		}

		// Token: 0x06000379 RID: 889 RVA: 0x000123B8 File Offset: 0x000105B8
		public void FixEffectOrder()
		{
			bool flag = !this.SteamCam;
			if (flag)
			{
				this.SteamCam = base.GetComponent<global::SteamVR_Camera>();
			}
			this.SteamCam.ForceLast();
			this.SteamCam = base.GetComponent<global::SteamVR_Camera>();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00012400 File Offset: 0x00010600
		private void CopyFX(global::UnityEngine.GameObject source, global::UnityEngine.GameObject target, bool disabledSourceFx = false)
		{
			foreach (global::UnityEngine.MonoBehaviour monoBehaviour in target.GetCameraEffects())
			{
				global::UnityEngine.Object.DestroyImmediate(monoBehaviour);
			}
			int num = target.GetComponents<global::UnityEngine.Component>().Length;
			global::VRGIN.Core.VRLog.Info("Copying FX to {0}...", new object[]
			{
				target.name
			});
			foreach (global::UnityEngine.MonoBehaviour monoBehaviour2 in source.GetCameraEffects())
			{
				bool flag = global::VRGIN.Core.VR.Interpreter.IsAllowedEffect(monoBehaviour2);
				if (flag)
				{
					global::VRGIN.Core.VRLog.Info("Copy FX: {0} (enabled={1})", new object[]
					{
						monoBehaviour2.GetType().Name,
						monoBehaviour2.enabled
					});
					global::UnityEngine.MonoBehaviour monoBehaviour3 = target.CopyComponentFrom(monoBehaviour2);
					bool flag2 = monoBehaviour3;
					if (flag2)
					{
						global::VRGIN.Core.VRLog.Info("Attached!", global::System.Array.Empty<object>());
					}
					monoBehaviour3.enabled = monoBehaviour2.enabled;
				}
				else
				{
					global::VRGIN.Core.VRLog.Info("Skipping image effect {0}", new object[]
					{
						monoBehaviour2.GetType().Name
					});
				}
				if (disabledSourceFx)
				{
					monoBehaviour2.enabled = false;
				}
			}
			global::VRGIN.Core.VRLog.Info("{0} components before the additions, {1} after", new object[]
			{
				num,
				target.GetComponents<global::UnityEngine.Component>().Length
			});
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00012590 File Offset: 0x00010790
		private void ApplyToCameras(global::VRGIN.Core.VRCamera.CameraOperation operation)
		{
			operation(this.SteamCam.GetComponent<global::UnityEngine.Camera>());
		}

		// Token: 0x0600037C RID: 892 RVA: 0x000125A8 File Offset: 0x000107A8
		protected override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.SteamCam.origin;
			if (flag)
			{
				this.SteamCam.origin.localScale = global::UnityEngine.Vector3.one * global::VRGIN.Core.VR.Settings.IPDScale;
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x000125F8 File Offset: 0x000107F8
		public void Refresh()
		{
			this.CopyFX(this.Blueprint);
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00012608 File Offset: 0x00010808
		internal global::UnityEngine.Camera Clone(bool copyEffects = true)
		{
			global::UnityEngine.Camera camera = new global::UnityEngine.GameObject("VRGIN_Camera_Clone").CopyComponentFrom(this.SteamCam.GetComponent<global::UnityEngine.Camera>());
			if (copyEffects)
			{
				this.CopyFX(this.SteamCam.gameObject, camera.gameObject, false);
			}
			camera.transform.position = base.transform.position;
			camera.transform.rotation = base.transform.rotation;
			camera.nearClipPlane = 0.01f;
			return camera;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00012690 File Offset: 0x00010890
		internal void RegisterSlave(global::VRGIN.Core.CameraSlave slave)
		{
			global::VRGIN.Core.VRLog.Info("Camera went online: {0}", new object[]
			{
				slave.name
			});
			this.Slaves.Add(slave);
			this.UpdateCameraConfig();
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000126C1 File Offset: 0x000108C1
		internal void UnregisterSlave(global::VRGIN.Core.CameraSlave slave)
		{
			global::VRGIN.Core.VRLog.Info("Camera went offline: {0}", new object[]
			{
				slave.name
			});
			this.Slaves.Remove(slave);
			this.UpdateCameraConfig();
		}

		// Token: 0x04000582 RID: 1410
		private static global::VRGIN.Core.VRCamera _Instance;

		// Token: 0x04000585 RID: 1413
		private global::System.Collections.Generic.IList<global::VRGIN.Core.CameraSlave> Slaves = new global::System.Collections.Generic.List<global::VRGIN.Core.CameraSlave>();

		// Token: 0x04000586 RID: 1414
		private const float MIN_FAR_CLIP_PLANE = 10f;

		// Token: 0x04000587 RID: 1415
		private global::UnityEngine.Camera _Camera;

		// Token: 0x020001FD RID: 509
		// (Invoke) Token: 0x06000A81 RID: 2689
		private delegate void CameraOperation(global::UnityEngine.Camera camera);
	}
}
