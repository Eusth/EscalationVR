using System;
using UnityEngine;
using VRGIN.Core;

namespace EscalationVR
{
	// Token: 0x020000E8 RID: 232
	public class EscalationActor : global::VRGIN.Core.IActor
	{
		// Token: 0x060005DC RID: 1500 RVA: 0x0001CCB8 File Offset: 0x0001AEB8
		public EscalationActor(global::FlagActivator_Man man, global::FlagActivator_Skanojo woman)
		{
			this._man = man;
			this._woman = woman;
			this._face = this._man.transform.Find("Face");
			this._animator = this._man.GetComponent<global::UnityEngine.Animator>();
			typeof(global::FlagActivator_Skanojo).GetField("SB_Head_Man", 36).SetValue(this._woman, global::VRGIN.Core.VR.Camera.gameObject);
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x0001CD34 File Offset: 0x0001AF34
		public bool IsValid
		{
			get
			{
				return this._man && this._woman && global::UnityEngine.Mathf.Abs(this._man.transform.position.y) < 500f && global::UnityEngine.Vector3.Distance(this._woman.transform.position, this._man.transform.position) < 5f;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x0001CDAC File Offset: 0x0001AFAC
		public global::UnityEngine.Pose Eyes
		{
			get
			{
				return new global::UnityEngine.Pose(this._man.HeadPos + (this.GetBodyOrientation() * global::UnityEngine.Vector3.up + this._man.HeadDirFwd * 0.5f).normalized * 0.2f, global::UnityEngine.Quaternion.LookRotation(this._man.HeadDirFwd, this._man.HeadDirUp));
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x0001CE28 File Offset: 0x0001B028
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x0001CE5B File Offset: 0x0001B05B
		public bool HasHead
		{
			get
			{
				return this._animator.GetBoneTransform(10).localScale.magnitude > 0.5f;
			}
			set
			{
				this._animator.GetBoneTransform(10).localScale = (value ? global::UnityEngine.Vector3.one : global::UnityEngine.Vector3.zero);
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0001CE80 File Offset: 0x0001B080
		public global::UnityEngine.Quaternion GetBodyOrientation()
		{
			global::UnityEngine.Transform boneTransform = this._animator.GetBoneTransform(11);
			global::UnityEngine.Transform boneTransform2 = this._animator.GetBoneTransform(12);
			global::UnityEngine.Transform boneTransform3 = this._animator.GetBoneTransform(0);
			global::UnityEngine.Vector3 normalized = (global::UnityEngine.Vector3.Lerp(boneTransform.position, boneTransform2.position, 0.5f) - boneTransform3.position).normalized;
			global::UnityEngine.Vector3 normalized2 = ((boneTransform2.position - boneTransform.position).normalized + boneTransform3.right).normalized;
			global::UnityEngine.Vector3 vector = -global::UnityEngine.Vector3.Cross(normalized, normalized2).normalized;
			return global::UnityEngine.Quaternion.LookRotation(vector, normalized);
		}

		// Token: 0x0400068B RID: 1675
		private global::FlagActivator_Man _man;

		// Token: 0x0400068C RID: 1676
		private global::UnityEngine.Transform _face;

		// Token: 0x0400068D RID: 1677
		private global::UnityEngine.Animator _animator;

		// Token: 0x0400068E RID: 1678
		private global::FlagActivator_Skanojo _woman;
	}
}
