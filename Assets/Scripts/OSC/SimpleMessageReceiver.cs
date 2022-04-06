/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.CUSTOM
{
	public class SimpleMessageReceiver : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/xy1";

		[Header("OSC Settings")]
		public OSCReceiver Receiver;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
			Receiver.Bind(Address, ReceivedMessage);
		}

		#endregion

		#region Private Methods

		private void ReceivedMessage(OSCMessage message)
		{
			// Debug.LogFormat("Received: {0}", message);
			float x = message.Values[0].FloatValue;
			float y = message.Values[1].FloatValue;
			PositionManager.Instance.SetPosition(new Vector2(x,y));
		}

		#endregion
	}
}