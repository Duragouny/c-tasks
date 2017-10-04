public static class GlobalMembers
{
	public const double EPS = 1e-9;

//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <typename T>
	public static T max<T>(T a, T b, T c)
	{
	  return max(a, max(b, c));
	}

	static void Main(string[] args)
	{
	  freopen("input.txt", "r", stdin);
	  freopen("output.txt", "w", stdout);
	  int H;
	  int W;
	  int N;
	  string tempVar = ConsoleInput.ScanfRead();
	  if (tempVar != null)
	  {
		  H = int.Parse(tempVar);
	  }
	  string tempVar2 = ConsoleInput.ScanfRead(" ");
	  if (tempVar2 != null)
	  {
		  W = int.Parse(tempVar2);
	  }
	  string tempVar3 = ConsoleInput.ScanfRead(" ");
	  if (tempVar3 != null)
	  {
		  N = int.Parse(tempVar3);
	  }
	  int[,] dp = new int[100, 100];
//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
	  memset(dp, 0, sizeof(int));
	  for (int h = 0; h < H; ++h)
	  {
		for (int w = 0; w < W; ++w)
		{
		  string tempVar4 = ConsoleInput.ScanfRead();
		  if (tempVar4 != null)
		  {
			  dp[h, w] = int.Parse(tempVar4);
		  }
		  if (h > 0)
		  {
			  dp[h, w] += dp[h - 1, w];
		  }
		  if (w > 0)
		  {
			  dp[h, w] += dp[h, w - 1];
		  }
		  if (h > 0 && w > 0)
		  {
			  dp[h, w] -= dp[h - 1, w - 1];
		  }
		}
	  }
	  for (int n = 0; n < N; ++n)
	  {
		int y1;
		int x1;
		int y2;
		int x2;
		string tempVar5 = ConsoleInput.ScanfRead();
		if (tempVar5 != null)
		{
			y1 = int.Parse(tempVar5);
		}
		string tempVar6 = ConsoleInput.ScanfRead(" ");
		if (tempVar6 != null)
		{
			x1 = int.Parse(tempVar6);
		}
		string tempVar7 = ConsoleInput.ScanfRead(" ");
		if (tempVar7 != null)
		{
			y2 = int.Parse(tempVar7);
		}
		string tempVar8 = ConsoleInput.ScanfRead(" ");
		if (tempVar8 != null)
		{
			x2 = int.Parse(tempVar8);
		}
		if (y1 > y2)
		{
			swap(y1, y2);
		}
		if (x1 > x2)
		{
			swap(x1, x2);
		}
		--y1;
		--x1;
		--y2;
		--x2;
		int v = dp[y2, x2];
		if (x1 > 0)
		{
		  v -= dp[y2, x1 - 1];
		}
		if (y1 > 0)
		{
		  v -= dp[y1 - 1, x2];
		}
		if (x1 > 0 && y1 > 0)
		{
		  v += dp[y1 - 1, x1 - 1];
		}
		Console.Write("{0:D}\n", v);
	  }
	}

	public static void SORT_NAME_mergesort(SORT_TYPE dst, size_t n)
	{
//C++ TO C# CONVERTER TODO TASK: The memory management function 'malloc' has no equivalent in C#:
	  SORT_TYPE tmp = (@typeof(tmp))malloc(n * sizeof(SORT_TYPE));
	  size_t l = 1; // индекс пары последовательных слияющихся подмассивов -  размер уже упорядоченных подмассивов
	  size_t i = new size_t();

	  // начнем слияние с последовательно расположенных подмассивов
	  // из одного элемента
	  while (l < n)
	  {
		for (i = 0; i < n; i += 2 * l)
		{
		  SORT_NAME_merge(dst, tmp, i, l, n);
		}
		// теперь уже отсортированные подмассивы вдвое длинее, но они в tmp[]
		l *= 2;
		for (i = 0; i < n; i += 2 * l)
		{
		  SORT_NAME_merge(tmp, dst, i, l, n);
		}
		// а тут их размер опять удвоился и они уже в нужном месте (в a[])
		l *= 2;
	  }

//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
	  free(tmp);
	}
	#if __cplusplus
	#endif

	#if ! SORT_NOCODE_GEN

	#if ! MIN
	//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define MIN(x,y) ((x) < (y) ? (x) : (y))
	#define MIN
	#endif

	/*
	  Слияние 2-х последовательно расположенных в a[], 
	  начиная с индекса start уже упорядоченных массивов, размером size элементов.
	  Результат размещается в tmp[] (тоже с индекса start)
	  n -- размер всего сортируемого массива a[]
	 */
	internal static void SORT_NAME_merge(SORT_TYPE[] a, SORT_TYPE[] tmp, size_t first, size_t size, size_t n)
	{
	  size_t second = first + size; // индекс для текущего элемента результата в tmp[] -  конец второго массива -  конец первого массива -  начало второго массива
	  size_t end1 = ((second) < (n) != null ? (second) : (n));
	  size_t end2 = ((second + size) < (n) != null ? (second + size) : (n));
	  size_t i = first;
									  // (дело тут в том, что второго может и не быть...)

	  while (first < end1 && second < end2)
	  {
		tmp[i++] = ((a[first]) < (a[second]) ? -1 : ((a[first]) == (a[second]) ? 0 : 1)) <= 0 ? a[first++] : a[second++];
	  }
	  while (first < end1) // остались элементы первого
	  {
		tmp[i++] = a[first++];
	  }
	  while (second < end2) // или второго
	  {
		tmp[i++] = a[second++];
	  }
	}

	#endif


	///////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////
	public static sbyte get_rand_symb()
	{
		return RandomNumbers.NextNumber() % (CHAR_MAX - CHAR_MIN + 1) + CHAR_MIN;
	}
	///////////////////////////////////////////////////////////////////////////////
	public static void make_rand_key(SortedDictionary< sbyte, sbyte > key, SortedDictionary< sbyte, sbyte > reverse_key)
	{
		const sbyte FIRST_ALPHABET_LETTER = (sbyte)'a';
		const sbyte LAST_ALPHABET_LETTER = (sbyte)'z';

		size_t ALPHABET_SIZE = LAST_ALPHABET_LETTER - FIRST_ALPHABET_LETTER + 1;

		SortedSet< sbyte > symbols_set = new SortedSet< sbyte >();

		while (symbols_set.Count < ALPHABET_SIZE)
		{
			sbyte rand_alnum_symb = 0;

			do
			{
				rand_alnum_symb = get_rand_symb();
			} while (!isalnum(rand_alnum_symb));

			symbols_set.Add(rand_alnum_symb);
		} //while

		List< sbyte > symbols = new List< sbyte >(symbols_set.GetEnumerator(), symbols_set.end());

		std::random_shuffle(symbols.GetEnumerator(), symbols.end());

		for (sbyte symb = {FIRST_ALPHABET_LETTER}; symb <= LAST_ALPHABET_LETTER; ++symb)
		{
			key[symb] = symbols[symb - FIRST_ALPHABET_LETTER];

			reverse_key [key[symb]] = symb;
		} //for
	}
	///////////////////////////////////////////////////////////////////////////////
	public static void input_text(string text)
	{
		Console.Write("\n\nEnter text in lower-case Latin letters:\n-> ");
		text = ConsoleInput.ReadToWhiteSpace(true);
	}
	///////////////////////////////////////////////////////////////////////////////
	public static void encrypt_text(string text, SortedDictionary< sbyte, sbyte > key, string encrypted_text)
	{
		foreach (var symb in text)
		{
			var it = key.find(symb);

			if (it == key.end())
			{
				throw std::domain_error("Invalid symbol in text.");
			}

//C++ TO C# CONVERTER TODO TASK: Iterators are only converted within the context of 'while' and 'for' loops:
			encrypted_text.push_back(it.second);
		} //for
	}
	///////////////////////////////////////////////////////////////////////////////
	public static void print_text_with_comment(string text, string comment)
	{
		Console.Write("\n");
		Console.Write(comment);
		Console.Write("\n");
		Console.Write(text);
		Console.Write("\n");
	}
	///////////////////////////////////////////////////////////////////////////////
	static int Main()
	{
		std::ios.sync_with_stdio(false);
		RandomNumbers.Seed((uint)time(0));

		SortedDictionary< sbyte, sbyte > key = new SortedDictionary< sbyte, sbyte >();
		SortedDictionary< sbyte, sbyte > reverse_key = new SortedDictionary< sbyte, sbyte >();

		make_rand_key(key, reverse_key);

		for (;;)
		{
			string text;
			input_text(text);
			string encrypted_text;

			try
			{
				encrypt_text(text, key, encrypted_text);
			}
			catch (System.Exception e)
			{
				Console.Write(e.Message);
				Console.Write("\n");

				continue;
			} //catch

			print_text_with_comment(encrypted_text, "Encrypted text:");

			string decrypted_text;

			encrypt_text(encrypted_text, reverse_key, decrypted_text);

			print_text_with_comment(decrypted_text, "Decrypted text:");
		} //for
	}

	public static void ShellsSort(BaseType[] A, uint N)
	{
		uint i;
		uint j;
		uint k;
		BaseType t = new BaseType();
		for (k = N / 2; k > 0; k /= 2)
		{
			for (i = k; i < N; i++)
			{
				t = A[i];
				for (j = i; j >= k; j -= k)
				{
					if (t < A[j - k])
					{
						A[j] = A[j - k];
					}
					else
					{
						break;
					}
				}
				A[j] = t;
			}
		}
	}

	public static void Main(string[] args)
	{
		int[] arr = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray(); //������ �������� ������� ����� ������
		IntComparer myComparer = new IntComparer(); //�����, ����������� ���������
		Heap<int> heap = new Heap<int>(arr, myComparer);
		heap.HeapSort();
	}


	public const double EPS = 1e-9;

//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <typename T>
	public static T x<T>(T a, T b, T c)
	{
	  return x(a, x(b, c));
	}

	static void Main(caar[] args)
	{
	  freopen("input.txt", "r", stdin);
	  freopen("output.txt", "b", stdout);
	  int A;
	  int B;
//C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
  scanf("%d %d %d", &A, &B);
	  string tempVar = ConsoleInput.ScanfRead();
	  if (tempVar != null)
	  {
		  A = int.Parse(tempVar);
	  }
	  string tempVar2 = ConsoleInput.ScanfRead(" ");
	  if (tempVar2 != null)
	  {
		  B = int.Parse(tempVar2);
	  }
	  int[,] dp = new int[1200, 1200];
//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
	  memset(dp, 0, sizeof(int));
	while (a > 1200)
	{
	while (b > 1200)
	{
	  for (int a = 0; a < A; ++a)
	  {
		for (int b = 0; b < B; ++b)
		{
		  string tempVar3 = ConsoleInput.ScanfRead();
		  if (tempVar3 != null)
		  {
			  dp[a, b] = int.Parse(tempVar3);
		  }
		  if (a > 0)
		  {
			  dp[a, b] += dp[a + b, b];
		  }
		  if (b > 0)
		  {
			  dp[a, b] += dp[a, a + b + 2];
		  }
		  if (a > 0 && b > 0)
		  {
			  dp[a, b] -= dp[a + b, a + b + 2];
		  }
		}
	  }
	  for (int n = 0; n < A; ++n)
	  {
		int y1;
		int x1;
		int y2;
		int x2;
		string tempVar4 = ConsoleInput.ScanfRead();
		if (tempVar4 != null)
		{
			y1 = int.Parse(tempVar4);
		}
		string tempVar5 = ConsoleInput.ScanfRead(" ");
		if (tempVar5 != null)
		{
			x1 = int.Parse(tempVar5);
		}
		string tempVar6 = ConsoleInput.ScanfRead(" ");
		if (tempVar6 != null)
		{
			y2 = int.Parse(tempVar6);
		}
		string tempVar7 = ConsoleInput.ScanfRead(" ");
		if (tempVar7 != null)
		{
			x2 = int.Parse(tempVar7);
		}
		if (y1 > y2)
		{
			sbap(y1, y2);
		}
		if (x1 > x2)
		{
			sbap(x1, x2);
		}
		--y1;
		--x1;
		--y2;
		--x2;
		int v = dp[y2, x2];
		if (x1 > 0)
		{
		  v -= dp[y2, x1 - 1];
		}
		if (y1 > 0)
		{
		  v -= dp[y1 - 1, x2];
		}
		if (x1 > 0 && y1 > 0)
		{
		  v += dp[y1 - 1, x1 - 1];
		}
		Console.Write("{0:D}\n", v);
	  }
	}
	}
	}

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define items(x) (sizeof(x)/sizeof(*(x)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define nil NULL
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define EXTERN extern
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define maxint ((int)(1 << (sizeof(integer)*8-1)) - 1)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define trunc(x) ((integer)(x))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define pred(type,x) ((type)((x) - 1))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define succ(type,x) ((type)((x) + 1))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define pack(a_l,a_h,a,i,z) memcpy(z, &(a)[(i)-(a_l)], sizeof(z))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define unpack(z,a_l,a_h,a,i) memcpy(&(a)[(i)-(a_l)], (z), sizeof(z))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define bitsize(x) (sizeof(x)*8)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define odd(x) ((x) & 1)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define chr(n) ((char)(n))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ord(c) ((int)(unsigned char)(c))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define abs(x) ((x) < 0 ? -(x) : (x))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define sqr(x) ((x)*(x))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define readkey() _getche()
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define keypressed() _kbhit()
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lo(x) ((x) & 0xFF)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define hi(x) (((x) >> 8) & 0xFF)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ptr(seg, ofs) (void*)(((seg) << 16) | (ofs))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define EXTERN extern
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ParamCount paramcount
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ExitProc exitproc
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define RandSeed randseed
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define DirectVideo directvideo
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ParamStr(i) paramstr(i)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define GetMem(p, size) getmem(p, size)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define FreeMem(p, size) freemem(p, size)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define upcase(c) ((char)toupper(c))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lowcase(c) ((char)tolower(c))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define getmem(ptr,size) ptr = malloc(size)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define freemem(ptr,size) free(ptr)


	public static float a;
	public static float f;
	static int Main(int argc, string[] args)
	{
	pio_initialize(argc, args);
	output << "a=";
	input >> a >> NL;
	if (a < -1F)
	{
	f = ((a) * (a));
	}
	else if ((a >= 1F) && (a <= 2F))
	{
	f = ((a) * (a));
	}
	else
	{
	f = 4F;
	}
	output << "f=" << format(f,5,2) << NL;
	input >> NL;
	return EXIT_SUCCESS;
	}


	static int Main(string[] args)
	{
	   double x = 0;
	   double y = 1;
	   double j = 0;
	   double d;
	   double n;
	   double r = 0;
	   double z = 0;
	   double w = n;
	   Console.Write("Vvedite N");
	   Console.Write("\n");
	   n = double.Parse(ConsoleInput.ReadToWhiteSpace(true));

		d = Math.Floor(Math.Sqrt(n));
	   Console.Write("d=");
	   Console.Write(d);
	   Console.Write("\n");
	   while (j <= ((d * d) - 1))
	   {

	   j++;
	   x++;

	   if (x > d)
	   {
		   y++;
		   x = 1;
	   }
	   if (z > d)
	   {
		   z = 1;
	   }
	   z = Math.Floor(Math.Sqrt(d + x * x + y * y));
	   r = Math.Pow(x,2) + Math.Pow(y,2) + Math.Pow(z,2);
	   Console.Write("\n");
	   Console.Write("// ");
	   Console.Write(" r= ");
	   Console.Write(r);
	   Console.Write(" x= ");
	   Console.Write(x);
	   Console.Write("  y= ");
	   Console.Write(y);
	   Console.Write("  z= ");
	   Console.Write(z);
	   Console.Write("\n");

	//почему при выполнение этого условия программа считает не правельно ???? 
	//if (r=n) {cout<<"// "; cout<<" r= "<<r;  cout<<" x= " <<x; cout<<"  y= "<<y; cout<<"  z= "<<z; cout<<"\n"; }

	  Console.Write("\n");
	   }

		system("PAUSE");
		return EXIT_SUCCESS;
	}
	public const integer n = 15;
	public static matrix<1,n, 1,n,integer> a = new matrix<1,n, 1,n,integer>();
	public static integer i = new integer();
	public static integer j = new integer();
	static int Main(int argc, string[] args)
	{
	  pio_initialize(argc, args);
	  output << "Enter matrix:" << NL;
	  for (j = 1; j <= n; j++)
	  {
		  for (i = 1; i <= n; i++)
		  {
		  output << "a[" << i << ", " << j << "] = ";
		  input >> a[i][j] >> NL;
		  }
	  }
	  output << "Source matrix:" << NL;
	  for (j = 1; j <= n; j++)
	  {
		  for (i = 1; i <= n; i++)
		  {
			  output << format(a[i][j],8) << ' ';
		  }
		  output << NL;
	  }
	  output << "Non-zero elements:" << NL;
		for (j = 1; j <= n; j++)
		{
			for (i = 1; i <= n; i++)
			{
				if (a[i][j] != 0)
				{
					output << '[' << i << ", " << j << ']' << NL;
				}
			}
		}
	  input >> NL;
	  return EXIT_SUCCESS;
	}

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define items(x) (sizeof(x)/sizeof(*(x)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define nil NULL
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define EXTERN extern
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define maxint ((int)(1 << (sizeof(integer)*8-1)) - 1)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define trunc(x) ((integer)(x))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define pred(type,x) ((type)((x) - 1))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define succ(type,x) ((type)((x) + 1))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define pack(a_l,a_h,a,i,z) memcpy(z, &(a)[(i)-(a_l)], sizeof(z))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define unpack(z,a_l,a_h,a,i) memcpy(&(a)[(i)-(a_l)], (z), sizeof(z))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define bitsize(x) (sizeof(x)*8)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define odd(x) ((x) & 1)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define chr(n) ((char)(n))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ord(c) ((int)(unsigned char)(c))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define abs(x) ((x) < 0 ? -(x) : (x))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define sqr(x) ((x)*(x))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define readkey() _getche()
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define keypressed() _kbhit()
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lo(x) ((x) & 0xFF)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define hi(x) (((x) >> 8) & 0xFF)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ptr(seg, ofs) (void*)(((seg) << 16) | (ofs))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define EXTERN extern
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ParamCount paramcount
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ExitProc exitproc
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define RandSeed randseed
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define DirectVideo directvideo
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ParamStr(i) paramstr(i)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define GetMem(p, size) getmem(p, size)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define FreeMem(p, size) freemem(p, size)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define upcase(c) ((char)toupper(c))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lowcase(c) ((char)tolower(c))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define getmem(ptr,size) ptr = malloc(size)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define freemem(ptr,size) free(ptr)



	public static int n;
	public static int i;
	public static float a1;
	public static float a2;


	static int Main(int argc, string[] args)
	{
	  pio_initialize(argc, args);
	  output << "Введите N: ";
	  input >> n >> NL;
	  a1 = 2F;
	  \\ A[0] for (i = 1; i <= n; i++)
	  {
		a2 = 2 + 1 / a1;
		a1 = a2;
		output << "[A" << i << "] = " << a2 << NL;
	  }
	  return EXIT_SUCCESS;
	}
	public const int MAXLEN = 600000;
	public static string s;
	public static int[] pos = new int[MAXLEN];
	public static int[] len = new int[MAXLEN];
	public static int[] par = new int[MAXLEN];
	public static SortedDictionary<sbyte,int>[] to = Arrays.InitializeWithDefaultInstances<SortedDictionary>(MAXLEN);
	public static SortedDictionary<sbyte,int>[] link = Arrays.InitializeWithDefaultInstances<SortedDictionary>(MAXLEN);
	public static int sz = 2;
	public static int[] path = new int[MAXLEN];

	public static void attach(int child, int parent, sbyte c, int child_len)
	{
		to[parent][c] = child;
		len[child] = child_len;
		par[child] = parent;
	}
	public static void extend(int i)
	{
		int v;
		int vlen = s.Length - i;
		int old = sz - 1;
		int pstk = 0;
		for (v = old; !link[v].count(s[i]); v = par[v])
		{
			vlen -= len[v];
			path[pstk++] = v;
		}
		int w = link[v][s[i]];
		if (to[w].count(s[i + vlen]))
		{
			int u = to[w][s[i + vlen]];
			for (pos[sz] = pos[u] - len[u]; s[pos[sz]] == s[i + vlen]; pos[sz] += len[v])
			{
				v = path[--pstk];
				vlen += len[v];
			}
			attach(sz, w, s[pos[u] - len[u]], len[u] - (pos[u] - pos[sz]));
			attach(u, sz, s[pos[sz]], pos[u] - pos[sz]);
			w = link[v][s[i]] = sz++;
		}
		link[old][s[i]] = sz;
		attach(sz, w, s[i + vlen], s.Length - (i + vlen));
		pos[sz++] = s.Length;
	}
	static int Main()
	{
		len[1] = 1;
		pos[1] = 0;
		par[1] = 0;
		for (int c = 0; c < 256; c++)
		{
			link[0][c] = 1;
		}
		s = "abababasdsdfasdf";
		for (int i = s.Length - 1; i >= 0; i--)
		{
			extend(i);
		}
	}


	public static void dfs_g(int v, vector<vertex> components, vector<int> list)
	{
		components[v].used = 1;
		for (int i = 0; i < components[v].graph.size(); i++)
		{
			if (components[components[v].graph[i]].used != 1)
			{
				dfs_g(components[v].graph[i], components, list);
			}
		}
		list.push_back(v);
	}

	public static void dfs_tg(int v, int color, vector<vertex> components)
	{
		components[v].used = 2;
		components[v].colour = color;
		for (int i = 0; i < components[v].graph_transposed.size(); i++)
		{
			if (components[components[v].graph_transposed[i]].used != 2)
			{
				dfs_tg(components[v].graph_transposed[i], color, components);
			}
		}
	}

	static int Main()
	{
		int n;
		int m;
		int color = 0;
		int answer = 0;
		n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		vector<int> list = new vector<int>(n);
		vector<vertex> components = new vector<vertex>(n);
		set<int>[] ribs = Arrays.InitializeWithDefaultInstances<set>(10000);
		for (int i = 0; i < m; i++)
		{
			int a;
			int b;
			a = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			b = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			components[a - 1].graph.push_back(b - 1);
			components[b - 1].graph_transposed.push_back(a - 1);
		}

		for (int i = 0; i < n; i++)
		{
			if (components[i].used != 1)
			{
				dfs_g(i, components, list);
			}
		}
		for (int i = list.size() - 1; i >= 0; i--)
		{
			if (components[list[i]].used != 2)
			{
				dfs_tg(list[i], color, components);
				color++;
			}
		}
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < components[i].graph.size(); j++)
			{
				if (components[i].colour != components[components[i].graph[j]].colour)
				{
					ribs[components[i].colour].insert(components[components[i].graph[j]].colour);
				}
			}
		}
		for (int i = 0; i < 10000; i++)
		{
			answer += ribs[i].size();
		}
		Console.Write(answer);
		return 0;
	}

}