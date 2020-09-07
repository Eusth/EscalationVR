using System;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x0200009C RID: 156
	public abstract class DefaultActorBehaviour<T> : global::VRGIN.Core.ProtectedBehaviour, global::VRGIN.Core.IActor where T : global::UnityEngine.MonoBehaviour
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x00010ECA File Offset: 0x0000F0CA
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x00010ED2 File Offset: 0x0000F0D2
		public T Actor { get; protected set; }

		// Token: 0x060002D7 RID: 727 RVA: 0x00010EDC File Offset: 0x0000F0DC
		public static A Create<A>(T nativeActor) where A : global::VRGIN.Core.DefaultActorBehaviour<T>
		{
			A a = nativeActor.GetComponent<A>();
			bool flag = !a;
			if (flag)
			{
				a = nativeActor.gameObject.AddComponent<A>();
				a.Initialize(nativeActor);
			}
			return a;
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00010F30 File Offset: 0x0000F130
		public virtual bool IsValid
		{
			get
			{
				return this.Actor;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060002D9 RID: 729
		public abstract global::UnityEngine.Pose Eyes { get; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060002DA RID: 730
		// (set) Token: 0x060002DB RID: 731
		public abstract bool HasHead { get; set; }

		// Token: 0x060002DC RID: 732 RVA: 0x00010F52 File Offset: 0x0000F152
		protected virtual void Initialize(T actor)
		{
			this.Actor = actor;
			global::VRGIN.Core.VRLog.Info("Creating character {0}", new object[]
			{
				actor.name
			});
		}
	}
}
