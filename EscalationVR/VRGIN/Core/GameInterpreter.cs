using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x0200009E RID: 158
	public class GameInterpreter : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00010F88 File Offset: 0x0000F188
		public virtual global::System.Collections.Generic.IEnumerable<global::VRGIN.Core.IActor> Actors
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00010FA8 File Offset: 0x0000F1A8
		public virtual bool IsEveryoneHeaded
		{
			get
			{
				return global::System.Linq.Enumerable.All<global::VRGIN.Core.IActor>(this.Actors, (global::VRGIN.Core.IActor a) => a.HasHead);
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00010FE4 File Offset: 0x0000F1E4
		protected override void OnLevel(int level)
		{
			base.OnLevel(level);
			global::VRGIN.Core.VRLog.Info("Loaded level {0}", new object[]
			{
				level
			});
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0001100C File Offset: 0x0000F20C
		public virtual global::VRGIN.Core.IActor FindImpersonatedActor()
		{
			return global::System.Linq.Enumerable.FirstOrDefault<global::VRGIN.Core.IActor>(this.Actors, (global::VRGIN.Core.IActor a) => !a.HasHead);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00011048 File Offset: 0x0000F248
		public virtual global::VRGIN.Core.IActor FindNextActorToImpersonate()
		{
			global::System.Collections.Generic.List<global::VRGIN.Core.IActor> list = global::System.Linq.Enumerable.ToList<global::VRGIN.Core.IActor>(this.Actors);
			global::VRGIN.Core.IActor actor2 = this.FindImpersonatedActor();
			bool flag = actor2 != null;
			if (flag)
			{
				list.Remove(actor2);
			}
			return global::System.Linq.Enumerable.FirstOrDefault<global::VRGIN.Core.IActor>(global::System.Linq.Enumerable.OrderByDescending<global::VRGIN.Core.IActor, float>(list, (global::VRGIN.Core.IActor actor) => global::UnityEngine.Vector3.Dot((actor.Eyes.position - global::VRGIN.Core.VR.Camera.transform.position).normalized, global::VRGIN.Core.VR.Camera.SteamCam.head.forward)));
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x000110AC File Offset: 0x0000F2AC
		public virtual global::UnityEngine.Camera FindCamera()
		{
			return global::UnityEngine.Camera.main;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000110C4 File Offset: 0x0000F2C4
		public virtual global::System.Collections.Generic.IEnumerable<global::UnityEngine.Camera> FindSubCameras()
		{
			return global::System.Linq.Enumerable.Except<global::UnityEngine.Camera>(global::System.Linq.Enumerable.Where<global::UnityEngine.Camera>(global::UnityEngine.Camera.allCameras, (global::UnityEngine.Camera c) => c.targetTexture == null), new global::UnityEngine.Camera[]
			{
				global::UnityEngine.Camera.main
			});
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00011114 File Offset: 0x0000F314
		public global::VRGIN.Core.CameraJudgement JudgeCamera(global::UnityEngine.Camera camera)
		{
			bool flag = camera.name.Contains("VRGIN") || camera.name == "poseUpdater";
			global::VRGIN.Core.CameraJudgement result;
			if (flag)
			{
				result = global::VRGIN.Core.CameraJudgement.Ignore;
			}
			else
			{
				result = this.JudgeCameraInternal(camera);
			}
			return result;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0001115C File Offset: 0x0000F35C
		protected virtual global::VRGIN.Core.CameraJudgement JudgeCameraInternal(global::UnityEngine.Camera camera)
		{
			bool flag = global::VRGIN.Core.VR.GUI.IsInterested(camera);
			bool flag2 = camera.targetTexture == null;
			global::VRGIN.Core.CameraJudgement result;
			if (flag2)
			{
				bool flag3 = flag;
				if (flag3)
				{
					result = global::VRGIN.Core.CameraJudgement.GUIAndCamera;
				}
				else
				{
					bool flag4 = camera.CompareTag("MainCamera");
					if (flag4)
					{
						result = global::VRGIN.Core.CameraJudgement.MainCamera;
					}
					else
					{
						result = global::VRGIN.Core.CameraJudgement.SubCamera;
					}
				}
			}
			else
			{
				result = (flag ? global::VRGIN.Core.CameraJudgement.GUI : global::VRGIN.Core.CameraJudgement.Ignore);
			}
			return result;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000111B8 File Offset: 0x0000F3B8
		public virtual bool IsBody(global::UnityEngine.Collider collider)
		{
			return false;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000111CC File Offset: 0x0000F3CC
		public virtual bool IsIgnoredCanvas(global::UnityEngine.Canvas canvas)
		{
			return false;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x000111E0 File Offset: 0x0000F3E0
		public virtual bool IsAllowedEffect(global::UnityEngine.MonoBehaviour effect)
		{
			return true;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060002EA RID: 746 RVA: 0x000111F4 File Offset: 0x0000F3F4
		public virtual int DefaultCullingMask
		{
			get
			{
				return global::UnityEngine.LayerMask.GetMask(new string[]
				{
					"Default"
				});
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0001121C File Offset: 0x0000F41C
		public virtual bool IsIrrelevantCamera(global::UnityEngine.Camera blueprint)
		{
			return true;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00011230 File Offset: 0x0000F430
		public virtual bool IsUICamera(global::UnityEngine.Camera camera)
		{
			return camera.GetComponent("UICamera");
		}
	}
}
