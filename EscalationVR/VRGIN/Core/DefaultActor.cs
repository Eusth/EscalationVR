using System;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x0200009B RID: 155
	public abstract class DefaultActor<T> : global::VRGIN.Core.IActor where T : global::UnityEngine.MonoBehaviour
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00010E41 File Offset: 0x0000F041
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00010E49 File Offset: 0x0000F049
		public T Actor { get; protected set; }

		// Token: 0x060002CE RID: 718 RVA: 0x00010E52 File Offset: 0x0000F052
		public DefaultActor(T nativeActor)
		{
			this.Actor = nativeActor;
			this.Initialize(nativeActor);
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060002CF RID: 719 RVA: 0x00010E6C File Offset: 0x0000F06C
		public virtual bool IsValid
		{
			get
			{
				return this.Actor;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060002D0 RID: 720
		public abstract global::UnityEngine.Pose Eyes { get; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060002D1 RID: 721
		// (set) Token: 0x060002D2 RID: 722
		public abstract bool HasHead { get; set; }

		// Token: 0x060002D3 RID: 723 RVA: 0x00010E8E File Offset: 0x0000F08E
		protected virtual void Initialize(T actor)
		{
			this.Actor.gameObject.AddComponent<global::VRGIN.Core.Marker>();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00010EA8 File Offset: 0x0000F0A8
		public static bool IsAlreadyMapped(T nativeActor)
		{
			return nativeActor.GetComponent<global::VRGIN.Core.Marker>();
		}
	}
}
