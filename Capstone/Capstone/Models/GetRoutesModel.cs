namespace Capstone.Models
{	
	public class Anchor
	{
		public string text { get; set; }
		public string controller { get; set; }
		public string action { get; set; }

		public Anchor(string _text, string _controller, string _action)
		{
			text = _text;
			controller = _controller;
			action = _action;
		}
	}
}
