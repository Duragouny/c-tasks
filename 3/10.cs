#if ! SORT_NAME
#error "Must declare SORT_NAME"
#endif

#if ! SORT_TYPE
#error "Must declare SORT_TYPE"
#endif

#if ! SORT_CMP
//C++ TO C# CONVERTER TODO TASK: #define macros defined in multiple preprocessor conditionals can only be replaced within the scope of the preprocessor conditional:
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SORT_CMP(x, y) ((x) < (y) ? -1 : ((x) == (y) ? 0 : 1))
#define SORT_CMP
#endif

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SORT_CONCAT(x, y) x ## _ ## y
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SORT_MAKE_STR1(x, y) SORT_CONCAT(x,y)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SORT_MAKE_STR(x) SORT_MAKE_STR1(SORT_NAME,x)

// делает имя функции наподобие int_mergesort(), 
// по которому надо вызывать сортировку 
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MERGE_SORT SORT_MAKE_STR(mergesort)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MERGE SORT_MAKE_STR(merge)
#if __cplusplus
#endif