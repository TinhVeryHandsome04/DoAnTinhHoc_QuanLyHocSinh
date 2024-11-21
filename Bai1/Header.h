#pragma once
#include<iostream>
using namespace std;
const int MAX = 100;
typedef struct  OneArrayDimension
{
	int n;
	int arr[MAX];
}OAD;
void Input(OAD& array);
void Display(OAD array);
int InsertElement(OAD& array, int index, int value);
void RemoveElement(OAD& array, int index);
void Reverse(OAD &array);
void swap(int& a, int& b);
void SortArr(OAD& array);
OAD updateArray(OAD& array, int newValue, int index);
void Menu();