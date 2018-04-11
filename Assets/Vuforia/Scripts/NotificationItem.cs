using System;


[Serializable]
public class NotificationItem
{
	public long devTimestamp { get; set;}
	public long notifId { get; set; }
	public string provider { get; set; }
	public string title { get; set; }
	public string message { get; set; }
}


