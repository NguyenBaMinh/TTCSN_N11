#include <iostream>
#include <cstring>
using namespace std;

void Z_algo(char* s, int* Z, int n) {
    int l = 0, r = 0;
    for (int i = 1; i < n; i++) {
        if (i <= r) Z[i] = min(Z[i - l], r - i + 1);
        while (i + Z[i] < n && s[Z[i]] == s[i + Z[i]]) Z[i]++;
        if (i + Z[i] - 1 > r) l = i, r = i + Z[i] - 1;
    }
}

int count_pattern(char* text, char* pattern) {
    int len_p = strlen(pattern), len_t = strlen(text);
    char s[len_p + len_t + 2];
    int Z[len_p + len_t + 2] = {0};
    
    strcpy(s, pattern);
    strcat(s, "$");
    strcat(s, text);
    
    Z_algo(s, Z, len_p + len_t + 1);
    
    int cnt = 0;
    for (int i = 0; i < len_p + len_t + 1; i++) 
        if (Z[i] == len_p) cnt++;
    return cnt;
}

int main() {
    char text[] = "do xuan vuong";
    char pattern[] = "xua";
    cout << count_pattern(text, pattern); // Output: 3
    //cout<<pattern;
}
