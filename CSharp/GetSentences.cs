public String GetSentences(string text, int number, bool removeEnters = false)
{
	if (string.IsNullOrWhiteSpace(text) || number < 1)
	{
		return text;
	}

	if (removeEnters) // Replace \r\n with a space
	{
		text = text.Replace("\r", "").Replace('\n', ' ');
	}

	var delimeters = ".!?";
	var start = false; // A valid sentence starts.
	int found = 0;
	for (int i = 0; i < text.Length; i++)
	{
		var c = text[i];
		if (!start && ('A' < c && c < 'Z' || 'a' < c && c < 'z'))
		{
			start = true;
			if (found >= number)
			{
				return text.Substring(0, i).Trim();
			}
		}
		if (start && delimeters.IndexOf(text[i]) >= 0 && (i + 1 == text.Length || text[i + 1] == ' '))
		{
			found++;
			start = false;
		}
	}
	return text;
}