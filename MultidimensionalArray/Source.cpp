#include"Header.h" 
void Input(MA& m) {
	do
	{
		cout << "Enter the number column: ";
		cin >> m.column;
		cout << "Enter the number row: ";
		cin >> m.row;
	} while (m.column<0||m.row<0||m.column>=MAX||m.row>=MAX);
	for (int i = 0; i < m.row; i++)
	{
		for (int j = 0; j < m.column; j++)
		{
			cin >> m.ma[i][j];
		}
	}
}
void Display(MA m) {
	cout << "\n=========MY MATRIX=========" << endl;
	for (int i = 0; i < m.row; i++)
	{
		for (int j = 0; j < m.column; j++)
		{
			cout << m.ma[i][j] << "\t";
		}
		cout << endl;
	}
}
void changeValue(MA& m, int value, int change) {
	

	for (int i = 0; i < m.column; i++)
	{
		for (int j = 0; j < m.row; j++)
		{
			if (m.ma[i][j] == value)
				m.ma[i][j] = change;
		}
	}
}
void deleteElement(MA& m, int value) {
	for (int i = 0; i < m.row; i++)
	{
		for (int j = 0; j < m.column; j++)
		{
			if (m.ma[i][j] == value)
				m.ma[i][j] = 0;
		}
	}
}
void Reverse(MA& matrix) {
	int totalElements = matrix.row * matrix.column;

	for (int i = 0; i < totalElements / 2; i++) {
		
		int row1 = i / matrix.column;
		int col1 = i % matrix.column;
		int row2 = (totalElements - i - 1) / matrix.column;
		int col2 = (totalElements - i - 1) % matrix.column;

		
		int temp = matrix.ma[row1][col1];
		matrix.ma[row1][col1] = matrix.ma[row2][col2];
		matrix.ma[row2][col2] = temp;
	}
}
void swap(int& a, int& b) {
	int temp = a;
	a = b;
	b = temp;
}
void Sort(MA& matrix) {
	int temp[MAX * MAX];
	int index = 0;
	for (int i = 0; i < matrix.row; i++) {
		for (int j = 0; j < matrix.column; j++) {
			temp[index++] = matrix.ma[i][j];
		}
	}	
	for (int i = 0; i < index - 1; i++) {
		for (int j = 0; j < index - i - 1; j++) {
			if (temp[j] > temp[j + 1]) {
				
				swap(temp[j], temp[j + 1]);
			}
		}
	}
	index = 0;
	for (int i = 0; i < matrix.row; i++) {
		for (int j = 0; j < matrix.column; j++) {
			matrix.ma[i][j] = temp[index++];
		}
	}
}

void AddRow(MA& matrix) {
	if (matrix.row >= MAX) {
		cout << "Khong them duoc" << endl;
		return;
	}
	for (int i = 0; i < matrix.column; i++) {
		cout << "nhap phan tu vi tri [ " << matrix.row << " ][ " << i << " ]: ";
		cin >> matrix.ma[matrix.row][i];
	}
	matrix.row++;
}
void deleteRow(MA& matrix, int row) {
	for (int i = 0; i < matrix.row; i++)
	{
		for (int j = 0; j < matrix.column; j++)
		{
			if (i == row)
				matrix.ma[i][j] = matrix.ma[i+1][j];
		}
	}
	matrix.row--;	
}
void deleteColumn(MA& matrix, int column) {
	for (int i = 0; i < matrix.row; i++)
	{
		for (int j = 0; j < matrix.column; j++)
		{
			if (column == j)
				matrix.ma[i][j] = matrix.ma[i][j + 1];
		}
	}
	matrix.column--;
}
void AddColumn(MA& matrix) {
	if (matrix.column >= MAX) {
		cout << "Khong them duoc" << endl;
		return;
	}
	for (int i = 0; i < matrix.row; i++) {
		cout << "nhap phan tu vi tri [ " << i << " ][ " << matrix.column << " ]: ";
		cin >> matrix.ma[i][matrix.column];
	}
	matrix.column++;
}
void Menu() {
	int choice, index, value;
	MA matrix;
	cout << "\n--------INPUT ARRAY--------" << endl;;
	Input(matrix);
	Display(matrix);
	do
	{
		cout << "\n=================================="  ;
		cout << "\n===============MENU===============";
		cout << "\n==================================" ;
		cout << "\n1. Add row";
		cout << "\n2. Add column";
		cout << "\n3. Delete row ";
		cout << "\n4. Delete column";
		cout << "\n5. Delete element";
		cout << "\n6. Update";
		cout << "\n7. Reverse";
		cout << "\n8. Sort";
		cout << "\n0. EXIT";
		cout << "\nEnter your choice: ";
		cin >> choice;

		switch (choice)
		{

		case 1:	
			AddRow(matrix);
			Display(matrix);
			break;
		case 2:
			AddColumn(matrix);
			Display(matrix);
			break;
		case 3: 
			cout << "enter the row you want delete: ";
			cin >> value;
			deleteRow(matrix, value);
			Display(matrix);
		case 4:
			cout << "Enter the element  you want delete: ";
			cin >> value;
			cout << "\nAfter matrix row deletion :"<<value << endl;
			deleteColumn(matrix, value);
			Display(matrix);
			break;
		case 5:

			cout << "Enter the element of matrix you want delete: ";

			cin >> value;
			deleteElement(matrix, value);
			Display(matrix);
			break;
		case 6:
			cout << "Nhap phan tu ban muon doi: ";
			cin >> value;
			cout << "Nhap gia tri ban muon doi: ";
			cin >> index;
			changeValue(matrix, value, index);
			Display(matrix);
			break;
		case 7:
			cout << "\nAfter reverse matrix: "<<endl;
			Reverse(matrix);
			Display(matrix);
			break;
		case 8:
			Sort(matrix);
			Display(matrix);
			break;
		default:
			break;
		}
	} while (choice != 0);
}