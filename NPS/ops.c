void swap(int *xp, int *yp)
{
    int temp = *xp;
    *xp = *yp;
    *yp = temp;
}

void bubbleSortA(int a[], int n)
{
    int i, j;
    for (i = 0; i < n-1; i++)    
    for (j = 0; j < n-i-1; j++)
        if (a[j] > a[j+1])
            swap(&a[j], &a[j+1]);
}
void bubbleSortD(int a[], int n)
{
    int i, j;
    for (i = 0; i < n-1; i++)    
    for (j = 0; j < n-i-1; j++)
        if (a[j] < a[j+1])
            swap(&a[j], &a[j+1]);
}
int search(int arr[], int n, int x)
{
    int i;
    for (i = 0; i < n; i++)
        if (arr[i] == x)
            return i+1;
    return 0;
}
char isPalindrome(char str[])
{
    int l = 0;
    int h = strlen(str) - 1;
    while (h > l)
    {
        if (str[l++] != str[h--])
        {
            return '0';
        }
    }
    return '1';
}

void replaceAll(char *str, const char *oldWord, const char *newWord){
    char *pos, temp[1000];
    int index = 0;
    int owlen;
    owlen = strlen(oldWord);
    while ((pos = strstr(str, oldWord)) != NULL){
        strcpy(temp, str);
        index = pos - str;
        str[index] = '\0';
        strcat(str, newWord);
        strcat(str, temp + index + owlen);
    }
    // replaceAll(buffer, str1, str2);
}

void permute(char * a, int l, int r) 
{
  int i;
  if (l == r)
    printf("%s\n", a);
  else 
  {
    for (i = l; i <= r; i++) 
    {
      swap((a + l), (a + i));
      permute(a, l + 1, r);
      swap((a + l), (a + i)); 
    }
  }
}
// permute(buff, 0, n - 1);

int find_anagram(char array1[], char array2[])
{
    int num1[26] = {0}, num2[26] = {0}, i = 0;
 
    while (array1[i] != '\0')
    {
        num1[array1[i] - 'a']++;
        i++;
    }
    i = 0;
    while (array2[i] != '\0')
    {
        num2[array2[i] -'a']++;
        i++;
    }
    for (i = 0; i < 26; i++)
    {
        if (num1[i] != num2[i])
            return 0;
    }
    return 1;
}