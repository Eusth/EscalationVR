using System;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000E4 RID: 228
	public class TravelDistanceRumble : global::VRGIN.Helpers.IRumbleSession, global::System.IComparable<global::VRGIN.Helpers.IRumbleSession>
	{
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0001BDDC File Offset: 0x00019FDC
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x0001BDF4 File Offset: 0x00019FF4
		public bool UseLocalPosition
		{
			get
			{
				return this._UseLocalPosition;
			}
			set
			{
				this._UseLocalPosition = value;
				this.Reset();
			}
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0001BE05 File Offset: 0x0001A005
		public void Reset()
		{
			this.PrevPosition = (this._UseLocalPosition ? this._Transform.localPosition : this._Transform.position);
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x0001BE2E File Offset: 0x0001A02E
		// (set) Token: 0x060005B8 RID: 1464 RVA: 0x0001BE36 File Offset: 0x0001A036
		public bool IsOver { get; private set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0001BE3F File Offset: 0x0001A03F
		// (set) Token: 0x060005BA RID: 1466 RVA: 0x0001BE47 File Offset: 0x0001A047
		public ushort MicroDuration { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0001BE50 File Offset: 0x0001A050
		public float MilliInterval
		{
			get
			{
				this.CurrentPosition = (this._UseLocalPosition ? this._Transform.localPosition : this._Transform.position);
				float distanceTraveled = this.DistanceTraveled;
				bool flag = distanceTraveled > this._Distance;
				float result;
				if (flag)
				{
					this.PrevPosition = this.CurrentPosition;
					result = 0f;
				}
				else
				{
					result = float.MaxValue;
				}
				return result;
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0001BEB7 File Offset: 0x0001A0B7
		public TravelDistanceRumble(ushort intensity, float distance, global::UnityEngine.Transform transform)
		{
			this.MicroDuration = intensity;
			this._Transform = transform;
			this._Distance = distance;
			this.PrevPosition = transform.position;
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060005BD RID: 1469 RVA: 0x0001BEEC File Offset: 0x0001A0EC
		protected virtual float DistanceTraveled
		{
			get
			{
				return global::UnityEngine.Vector3.Distance(this.PrevPosition, this.CurrentPosition);
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001BF10 File Offset: 0x0001A110
		public int CompareTo(global::VRGIN.Helpers.IRumbleSession other)
		{
			return this.MicroDuration.CompareTo(other.MicroDuration);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001BF36 File Offset: 0x0001A136
		public void Consume()
		{
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001BF39 File Offset: 0x0001A139
		public void Close()
		{
			this.IsOver = true;
		}

		// Token: 0x0400067D RID: 1661
		private global::UnityEngine.Transform _Transform;

		// Token: 0x0400067E RID: 1662
		private float _Distance;

		// Token: 0x0400067F RID: 1663
		protected global::UnityEngine.Vector3 PrevPosition;

		// Token: 0x04000680 RID: 1664
		protected global::UnityEngine.Vector3 CurrentPosition;

		// Token: 0x04000681 RID: 1665
		private bool _UseLocalPosition = false;
	}
}
