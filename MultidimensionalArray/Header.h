#pragma once
#include<iostream>
const int MAX = 50;
using namespace std;
typedef struct MultidimensionArray{
	int column, row;
	int ma[MAX][MAX];
}MA;

void Input(MA& m);
void Display(MA m);
void changeValue(MA& m, int value,int change);
void deleteElement(MA& m, int value);
void deleteRow(MA& matrix, int row);
void deleteColumn(MA& matrix, int column);
void Reverse(MA& matrix);
void swap(int& a, int& b);
void Sort(MA& m);
void AddRow(MA& matrix);
void AddColumn(MA& matrix);
void Menu();