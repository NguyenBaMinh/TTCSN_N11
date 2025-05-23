#include <iostream>
#include <string>
using namespace std;

void calculateZArray(string str, int Z[]) {
    int n = str.length();
    int L = 0, R = 0;

    for (int i = 1; i < n; ++i) {
        if (i > R) {
            L = R = i;
            while (R < n && str[R - L] == str[R]) {
                R++;
            }
            Z[i] = R - L;
            R--;
        } else {
            int k = i - L;
            if (Z[k] < R - i + 1) {
                Z[i] = Z[k];
            } else {
                L = i;
                while (R < n && str[R - L] == str[R]) {
                    R++;
                }
                Z[i] = R - L;
                R--;
            }
        }
    }
}	

int searchPattern(string text, string pattern) {
	int count = 0;
    string concat = pattern + "$" + text;
    int l = concat.length();

    int Z[l];
    calculateZArray(concat, Z);

    for (int i = 0; i < l; ++i) {
        if (Z[i] == pattern.length()) {
//            cout << "Pattern found at index " << i - pattern.length() - 1 << endl;
			count++;
        }
    }
    return count;
}

int main() {
    string text = "abababababababababababab";
    string pattern = "aba";

    cout << "Text: " << text << endl;
    cout << "Pattern: " << pattern << endl;

    cout<<searchPattern(text, pattern);

    return 0;
}
