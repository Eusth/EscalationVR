using System;
using UnityEngine;
using UnityEngine.UI;
using VRGIN.Core;

namespace VRGIN.Controls
{
	// Token: 0x020000BA RID: 186
	public class HelpText : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x0600042E RID: 1070 RVA: 0x00015084 File Offset: 0x00013284
		public static global::VRGIN.Controls.HelpText Create(string text, global::UnityEngine.Transform target, global::UnityEngine.Vector3 textOffset, global::UnityEngine.Vector3? lineOffset = null)
		{
			global::VRGIN.Controls.HelpText helpText = new global::UnityEngine.GameObject().AddComponent<global::VRGIN.Controls.HelpText>();
			helpText._Text = text;
			helpText._Target = target;
			helpText._TextOffset = textOffset;
			helpText._LineOffset = ((lineOffset != null) ? lineOffset.Value : global::UnityEngine.Vector3.zero);
			global::UnityEngine.Vector3 vector = (lineOffset != null) ? (textOffset - lineOffset.Value) : textOffset;
			helpText._HeightVector = global::UnityEngine.Vector3.Project(vector, global::UnityEngine.Vector3.up);
			helpText._MovementVector = global::UnityEngine.Vector3.ProjectOnPlane(vector, global::UnityEngine.Vector3.up);
			return helpText;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00015110 File Offset: 0x00013310
		protected override void OnStart()
		{
			base.OnStart();
			base.transform.SetParent(this._Target, false);
			global::UnityEngine.Canvas canvas = new global::UnityEngine.GameObject().AddComponent<global::UnityEngine.Canvas>();
			canvas.transform.SetParent(base.transform, false);
			canvas.renderMode = 2;
			canvas.GetComponent<global::UnityEngine.RectTransform>().SetSizeWithCurrentAnchors(0, 300f);
			canvas.GetComponent<global::UnityEngine.RectTransform>().SetSizeWithCurrentAnchors(1, 70f);
			base.transform.rotation = this._Target.parent.rotation;
			canvas.transform.localScale = new global::UnityEngine.Vector3(0.0001549628f, 0.0001549627f, 0f);
			canvas.transform.localPosition = this._TextOffset;
			canvas.transform.localRotation = global::UnityEngine.Quaternion.Euler(90f, 180f, 180f);
			global::UnityEngine.UI.Text text = new global::UnityEngine.GameObject().AddComponent<global::UnityEngine.UI.Text>();
			text.transform.SetParent(canvas.transform, false);
			text.GetComponent<global::UnityEngine.RectTransform>().anchorMin = global::UnityEngine.Vector2.zero;
			text.GetComponent<global::UnityEngine.RectTransform>().anchorMax = global::UnityEngine.Vector2.one;
			text.resizeTextForBestFit = true;
			text.resizeTextMaxSize = 40;
			text.resizeTextMinSize = 1;
			text.color = global::UnityEngine.Color.black;
			text.font = global::UnityEngine.Resources.GetBuiltinResource<global::UnityEngine.Font>("Arial.ttf");
			text.horizontalOverflow = 0;
			text.verticalOverflow = 0;
			text.alignment = 4;
			text.text = this._Text;
			this._Line = base.gameObject.AddComponent<global::UnityEngine.LineRenderer>();
			this._Line.material = global::UnityEngine.Resources.GetBuiltinResource<global::UnityEngine.Material>("Sprites-Default.mat");
			this._Line.SetColors(global::UnityEngine.Color.cyan, global::UnityEngine.Color.cyan);
			this._Line.useWorldSpace = false;
			this._Line.SetVertexCount(4);
			this._Line.SetWidth(0.001f, 0.001f);
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Inverse(this._Target.localRotation);
			this._Line.SetPosition(0, this._LineOffset + this._HeightVector * 0.1f);
			this._Line.SetPosition(1, this._LineOffset + this._HeightVector * 0.5f + this._MovementVector * 0.2f);
			this._Line.SetPosition(2, this._TextOffset - this._HeightVector * 0.5f - this._MovementVector * 0.2f);
			this._Line.SetPosition(3, this._TextOffset - this._HeightVector * 0.1f);
			global::UnityEngine.GameObject gameObject = global::UnityEngine.GameObject.CreatePrimitive(5);
			gameObject.transform.SetParent(base.transform, false);
			gameObject.transform.localPosition = this._TextOffset - global::UnityEngine.Vector3.up * 0.001f;
			gameObject.transform.localRotation = global::UnityEngine.Quaternion.Euler(90f, 0f, 0f);
			gameObject.transform.localScale = new global::UnityEngine.Vector3(0.05539737f, 0.009849964f, 0f);
			bool flag = !global::VRGIN.Controls.HelpText.S_Material;
			if (flag)
			{
				global::VRGIN.Controls.HelpText.S_Material = global::VRGIN.Core.VRManager.Instance.Context.Materials.Unlit;
				global::VRGIN.Controls.HelpText.S_Material.color = global::UnityEngine.Color.white;
			}
			gameObject.transform.GetComponent<global::UnityEngine.Renderer>().sharedMaterial = global::VRGIN.Controls.HelpText.S_Material;
			gameObject.GetComponent<global::UnityEngine.Collider>().enabled = false;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000154B4 File Offset: 0x000136B4
		protected override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x040005EB RID: 1515
		private global::UnityEngine.Vector3 _TextOffset;

		// Token: 0x040005EC RID: 1516
		private global::UnityEngine.Vector3 _LineOffset;

		// Token: 0x040005ED RID: 1517
		private global::UnityEngine.Vector3 _HeightVector;

		// Token: 0x040005EE RID: 1518
		private global::UnityEngine.Vector3 _MovementVector;

		// Token: 0x040005EF RID: 1519
		private global::UnityEngine.Transform _Target;

		// Token: 0x040005F0 RID: 1520
		private string _Text;

		// Token: 0x040005F1 RID: 1521
		private static global::UnityEngine.Material S_Material;

		// Token: 0x040005F2 RID: 1522
		private global::UnityEngine.LineRenderer _Line;
	}
}
