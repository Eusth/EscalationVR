using System;
using System.Xml.Serialization;
using VRGIN.Helpers;

namespace VRGIN.Core
{
	// Token: 0x020000B5 RID: 181
	public class Shortcuts
	{
		// Token: 0x040005BF RID: 1471
		public global::VRGIN.Core.XmlKeyStroke ResetView = new global::VRGIN.Core.XmlKeyStroke("F12", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005C0 RID: 1472
		public global::VRGIN.Core.XmlKeyStroke ChangeMode = new global::VRGIN.Core.XmlKeyStroke("Ctrl+C, Ctrl+C", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005C1 RID: 1473
		public global::VRGIN.Core.XmlKeyStroke ShrinkWorld = new global::VRGIN.Core.XmlKeyStroke("Alt + KeypadMinus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005C2 RID: 1474
		public global::VRGIN.Core.XmlKeyStroke EnlargeWorld = new global::VRGIN.Core.XmlKeyStroke("Alt + KeypadPlus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005C3 RID: 1475
		public global::VRGIN.Core.XmlKeyStroke ToggleUserCamera = new global::VRGIN.Core.XmlKeyStroke("Ctrl+C, Ctrl+V", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005C4 RID: 1476
		public global::VRGIN.Core.XmlKeyStroke SaveSettings = new global::VRGIN.Core.XmlKeyStroke("Alt + S", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005C5 RID: 1477
		public global::VRGIN.Core.XmlKeyStroke LoadSettings = new global::VRGIN.Core.XmlKeyStroke("Alt + L", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005C6 RID: 1478
		public global::VRGIN.Core.XmlKeyStroke ResetSettings = new global::VRGIN.Core.XmlKeyStroke("Ctrl + Alt + L", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005C7 RID: 1479
		public global::VRGIN.Core.XmlKeyStroke ApplyEffects = new global::VRGIN.Core.XmlKeyStroke("Ctrl + F5", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005C8 RID: 1480
		[global::System.Xml.Serialization.XmlElement("GUI.Raise")]
		public global::VRGIN.Core.XmlKeyStroke GUIRaise = new global::VRGIN.Core.XmlKeyStroke("KeypadMinus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005C9 RID: 1481
		[global::System.Xml.Serialization.XmlElement("GUI.Lower")]
		public global::VRGIN.Core.XmlKeyStroke GUILower = new global::VRGIN.Core.XmlKeyStroke("KeypadPlus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005CA RID: 1482
		[global::System.Xml.Serialization.XmlElement("GUI.IncreaseAngle")]
		public global::VRGIN.Core.XmlKeyStroke GUIIncreaseAngle = new global::VRGIN.Core.XmlKeyStroke("Ctrl + KeypadMinus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005CB RID: 1483
		[global::System.Xml.Serialization.XmlElement("GUI.DecreaseAngle")]
		public global::VRGIN.Core.XmlKeyStroke GUIDecreaseAngle = new global::VRGIN.Core.XmlKeyStroke("Ctrl + KeypadPlus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005CC RID: 1484
		[global::System.Xml.Serialization.XmlElement("GUI.IncreaseDistance")]
		public global::VRGIN.Core.XmlKeyStroke GUIIncreaseDistance = new global::VRGIN.Core.XmlKeyStroke("Shift + KeypadMinus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005CD RID: 1485
		[global::System.Xml.Serialization.XmlElement("GUI.DecreaseDistance")]
		public global::VRGIN.Core.XmlKeyStroke GUIDecreaseDistance = new global::VRGIN.Core.XmlKeyStroke("Shift + KeypadPlus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005CE RID: 1486
		[global::System.Xml.Serialization.XmlElement("GUI.RotateRight")]
		public global::VRGIN.Core.XmlKeyStroke GUIRotateRight = new global::VRGIN.Core.XmlKeyStroke("Ctrl + Shift + KeypadMinus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005CF RID: 1487
		[global::System.Xml.Serialization.XmlElement("GUI.RotateLeft")]
		public global::VRGIN.Core.XmlKeyStroke GUIRotateLeft = new global::VRGIN.Core.XmlKeyStroke("Ctrl + Shift + KeypadPlus", global::VRGIN.Helpers.KeyMode.Press);

		// Token: 0x040005D0 RID: 1488
		[global::System.Xml.Serialization.XmlElement("GUI.ChangeProjection")]
		public global::VRGIN.Core.XmlKeyStroke GUIChangeProjection = new global::VRGIN.Core.XmlKeyStroke("F4", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005D1 RID: 1489
		public global::VRGIN.Core.XmlKeyStroke ToggleRotationLock = new global::VRGIN.Core.XmlKeyStroke("F5", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005D2 RID: 1490
		public global::VRGIN.Core.XmlKeyStroke ImpersonateApproximately = new global::VRGIN.Core.XmlKeyStroke("Ctrl + X", global::VRGIN.Helpers.KeyMode.PressUp);

		// Token: 0x040005D3 RID: 1491
		public global::VRGIN.Core.XmlKeyStroke ImpersonateExactly = new global::VRGIN.Core.XmlKeyStroke("Ctrl + Shift + X", global::VRGIN.Helpers.KeyMode.PressUp);
	}
}
