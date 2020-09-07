using System;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000E5 RID: 229
	public class AxisBoundTravelDistanceRumble : global::VRGIN.Helpers.TravelDistanceRumble
	{
		// Token: 0x060005C1 RID: 1473 RVA: 0x0001BF44 File Offset: 0x0001A144
		public AxisBoundTravelDistanceRumble(ushort intensity, float distance, global::UnityEngine.Transform transform, global::UnityEngine.Vector3 axis) : base(intensity, distance, transform)
		{
			this._Axis = axis;
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x0001BF5C File Offset: 0x0001A15C
		protected override float DistanceTraveled
		{
			get
			{
				return global::UnityEngine.Mathf.Abs(global::UnityEngine.Vector3.Dot(this.CurrentPosition - this.PrevPosition, this._Axis));
			}
		}

		// Token: 0x04000684 RID: 1668
		private global::UnityEngine.Vector3 _Axis;
	}
}
