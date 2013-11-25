using System.IO;
using System;

class Program
{
	static string[] lines = new String[6];

	static void Main ()
	{
		string pattern;
		int rowNumber = 0;
		
		// Read in every line in the file.
		using (StreamReader reader = new StreamReader("../../input.txt")) {
			string line;
			while ((line = reader.ReadLine()) != null) {
				Array.Resize(ref lines, rowNumber + 1);
				lines[rowNumber] = line;
				rowNumber ++;
			}
		}

		// Loop Through Read Lines
		int lineNum = 1;
		int endOfPic = 0;

		for(int i = 0; i < Convert.ToInt32(lines[0]); i++) {
			endOfPic = lineNum + Convert.ToInt32(lines[lineNum]);
			lineNum ++;

			// Check if contains '#'
			Console.Write("Case #" + (i+1) + ": ");
			if(IsSquare(lineNum, endOfPic)){
				Console.WriteLine("YES");

		} else {
				Console.WriteLine("NO");
			}
		

			lineNum = endOfPic + 1;

		}
    }

	static bool IsSquare(int start, int end){
		bool result = true;
		string line;

		int size = 0;

		int current = start;

		int inACol = 0;
		int inARow = 0;
		
		while (current <= end)
		{
			line = lines[current].Replace("."," ").Trim();

			if(line.Split('#').Length - 1 > 0)
			{
				// '#' are in a row
				inARow = 0;

				foreach(string black in line.Split('#'))
				{
					// gap detect
					if(black.Length != 0)
					{
						return false;
					}
					inARow ++;
				}

				if(size == 0)
				{
					size = inARow - 1;
				}
				else if(size != inARow - 1)
				{
					return false;
				}
				inACol ++;
			}
			current++;
		}
		if((size > 0) & (inARow - 1 == inACol))
		{
			return true;
		}
		return false;
	}
}
