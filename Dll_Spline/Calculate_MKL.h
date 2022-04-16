#pragma once
#include"pch.h"
#include "mkl.h"
extern "C" _declspec(dllexport)

bool Calculate_MKL(const int count_nodes, double* x, double* y, const int N, double* value1, double* value2, double* value3, double* Derivative1, double* Derivative2, double* deriv1, double* deriv2, double* deriv3, double* deriv_1ab_h, double* deriv_2ab_h, double* deriv_3ab_h, int& error, double* coef);
