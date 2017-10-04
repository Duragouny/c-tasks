//C++ TO C# CONVERTER TODO TASK: C++ template specialization was removed by C++ to C# Converter:
//ORIGINAL LINE: public class Heap<T>
public class Heap
{
	private internal[] T _array; //������ ����������� ���������
	internal int heapsize = new internal(); //����� �������������� ���������
	internal IComparer<T> _comparer = new internal();
	public Heap(T[] a, IComparer<T> comparer)
	{
		_array = a;
		heapsize = a.Length;
		_comparer = comparer;
	}

	public void HeapSort()
	{
		build_max_heap(); //���������� ��������
		for (int i = _array.Length - 1; i > 0; i--)
		{

			T temp = _array[0]; //���������� ������� ������������ ������� �� ������� ������� � ����� �������
			_array[0] = _array[i];
			_array[i] = temp;

			heapsize--; //�������� ����� �������������� ���������
			max_heapify(0); //�������������� �������� ��������
		}
	}

	internal int parent(int i)
	{
		return (i - 1) / 2;
	} //������ ������������� ����
	internal int left(int i)
	{
		return 2 * i + 1;
	} //������ ������ �������
	internal int right(int i)
	{
		return 2 * i + 2;
	} //������ ������� �������

	//����� ����������������� �������� �������� ��� �������,
		//��� ������� � �������� i ������ ���� �� ������ �� ����� ��������, ������� ��� ����� �������� �������������� ��������
	internal void max_heapify(int i)
	{
		int l = left(i);
		int r = right(i);
		int lagest = i;
		if (l<heapsize && _comparer.Compare(_array[l], _array[i])>0)
		{
			lagest = l;
		}
		if (r<heapsize && _comparer.Compare(_array[r], _array[lagest])>0)
		{
			lagest = r;
		}
		if (lagest != i)
		{
			T temp = _array[i];
			_array[i] = _array[lagest];
			_array[lagest] = temp;

			max_heapify(lagest);
		}
	}

	//����� ������ �������������� ��������
	internal void build_max_heap()
	{
		int i = (_array.Length - 1) / 2;

		while (i >= 0)
		{
			max_heapify(i);
			i--;
		}
	}

}

public class IntComparer : IComparer<int>
{
	public int Compare(int x, int y)
	{
		return x - y;
	}
}