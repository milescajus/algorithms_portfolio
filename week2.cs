using System;

class Week2
{
	// O(1)
	public int ConstantTime ()
	{
		return 1;
	}

	// O(n)
	public void LinearTime (int n)
	{
		for (int i = 0; i < n; i++)
		{
			Console.WriteLine(i);
		}
	}

	// O(n^2)
	public void QuadraticTime (int n)
	{
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				Console.WriteLine(j);
			}
			Console.WriteLine(i);
		}
	}
}
