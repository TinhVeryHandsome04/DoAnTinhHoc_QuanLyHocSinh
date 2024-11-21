#include <iostream>
using namespace std;

void hanoi(int n, char source, char auxiliary, char destination) {
    
    if (n == 1) {
        cout << "Di chuyen dia 1 tu cot " << source << " sang cot " << destination << endl;
        return;
    }
    hanoi(n - 1, source, destination, auxiliary); 
    cout << "Di chuyen dia " << n << " tu cot " << source << " sang cot " << destination << endl;
    hanoi(n - 1, auxiliary, source, destination);
}

int main() {
    int n;
    cout << "Nhap so luong dia: ";
    cin >> n;
    hanoi(n, 'A', 'B', 'C');

    return 0;
}
