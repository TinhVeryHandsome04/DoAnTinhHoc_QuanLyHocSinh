#include"Header.h"
void Input(OAD& array) {
	do
	{
		cout << "\nEnter the number element of array: "; 
		cin >> array.n;
	} while (array.n<0||array.n>=MAX);
	for (int i = 0; i < array.n; i++)
	{
		cout << "Elemet[" << i << "]: ";
		cin >> array.arr[i];
	}
}
void Display(OAD array) {
	cout << "\nArray: ";
	for (int i = 0; i < array.n; i++)
	{
		cout << array.arr[i] << " ";
	}
}
int InsertElement(OAD& array, int index, int value) {

	if (index > array.n)
		return -1;
	for (int i = array.n; i >=index; i--)
	{
		array.arr[i] = array.arr[i - 1];
	}
	array.arr[index] = value;
	array.n++;
	return 1;
}
void RemoveElement(OAD& array, int index) {
	for (int i = index; i < array.n; i++)
	{
		array.arr[i] = array.arr[i + 1];
	}array.n--;
}
void swap(int& a, int& b) {
	int temp = a;
	a = b;
	b = temp;
}
void Reverse(OAD &array) {
	int i = 0, j = array.n-1;
	while (i < j) {
		swap(array.arr[i], array.arr[j]);
		i++;
		j--;
	}
}
void SortArr(OAD& array) {

	for (int i = 0; i < array.n - 1; i++) {
		int min_index = i;
		for (int j = i + 1; j < array.n; j++) {
			if (array.arr[j] < array.arr[min_index])
				min_index = j;
		}
		swap(array.arr[i], array.arr[min_index]);
	}
}
OAD updateArray(OAD& array, int newValue, int index) {
	array.arr[index] = newValue;
	return array;
}
void Menu() {
	int choice,index,value;
	OAD a;
	cout << "\n--------INPUT ARRAY--------" << endl;;
	Input(a);
	Display(a);
	do
	{
		cout << endl;
		cout << "\n1. Insert";
		cout << "\n2. Delete";
		cout << "\n3. Reverse";
		cout << "\n4. Sort";
		cout << "\n5. Update";
		cout << "\nEnter your choice: ";
		cin >> choice;
		
		switch (choice)
		{
			
		case 1:
			
			do
			{
				cout << "\nEnter index: ";
				cin >> index;
				if (index < 0 || index >= a.n)
					cout << "\nInvalid location !!! ";
			} while (index < 0 || index >= a.n);

			cout << "\nEnter value: ";
			cin >> value;
			Display(a);
			InsertElement(a, index, value);
			cout << "\nAfter insert the element ";
			Display(a);
			break;
		case 2:
			
			do
			{
				cout << "\nEnter index: ";
				cin >> index;
				if (index < 0 || index >= a.n)
					cout << "\nInvalid location !!! ";
			} while (index < 0 || index >= a.n);
			Display(a);
			RemoveElement(a, index);
			cout << "\nAfter remove: ";
			Display(a);
			break;
		case 3: 
			
			Display(a);
			cout << "\nReverse array :";
			Reverse(a);
			Display(a);
			break;
		case 4:
			
			Display(a);
			cout << "\nSort array: ";
			SortArr(a);
			Display(a);
			break;
		case 5:
			
			do
			{				
				cout << "\nEnter index: ";
				cin >> index;
				if (index < 0 || index >= a.n) {
					cout << "\nInvalid location !!! ";
					cout << "\nAgain: ";
				}
			} while (index < 0 || index >= a.n);
						
			cout << "Enter value: ";
			cin >> value;
			Display(a);
			updateArray(a,value,index);
			cout << "\nUpdate array: ";
			Display(a);
			break;
		default:
			break;
		}
	} while (choice != 0);
}