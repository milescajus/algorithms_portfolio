using System;

class Week2
{
	// O(1) as this always returns the first item, which is not affected by the length of the input.
	public int ConstantTime (int[] a)
	{
		return a[0];
	}

	// O(n) as the time taken scales linearly with the input integer n.
	public void LinearTime (int n)
	{
		for (int i = 0; i < n; i++)
		{
			Console.WriteLine(i);
		}
	}

	// O(n^2) as this is a nested loop that takes n*n time, i.e. n^2, growing quadratically as n grows.
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
