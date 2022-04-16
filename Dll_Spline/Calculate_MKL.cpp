#include"pch.h"
#include <iostream>
#include <time.h>
#include <mkl.h>
using namespace std;
extern "C" _declspec(dllexport)
bool Calculate_MKL(const int count_nodes, double* x, double* y, const int N, double* value1, double* value2, double* value3, double* Derivative1, double* Derivative2, double* deriv1, double* deriv2, double* deriv3, double* deriv_1ab_h, double* deriv_2ab_h, double* deriv_3ab_h, int& error, double* coef)
{

	try
	{
		DFTaskPtr Task;
		int code = dfdNewTask1D(&Task, count_nodes, x, DF_NON_UNIFORM_PARTITION, 1, y, DF_MATRIX_STORAGE_ROWS);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}

		//1
		code = dfdEditPPSpline1D(Task, DF_PP_CUBIC, DF_PP_NATURAL, DF_BC_1ST_LEFT_DER | DF_BC_1ST_RIGHT_DER, Derivative1, DF_NO_IC, NULL, coef, DF_NO_HINT);
		
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdConstruct1D(Task, DF_PP_SPLINE, DF_METHOD_STD);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		const double* a_b= new double[2]{ x[0], x[count_nodes - 1] };
		const double* a_b_h = new double[2]{ x[1], x[count_nodes - 2] };
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, N, a_b,       //
			DF_UNIFORM_PARTITION, 1, new int[1]{ 1 }, NULL, value1,
			DF_MATRIX_STORAGE_ROWS, NULL);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, 2, a_b,       //
			DF_UNIFORM_PARTITION, 3, new int[3]{ 1, 1,1 }, NULL, deriv1,
			DF_MATRIX_STORAGE_ROWS, NULL);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}


		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, 2, a_b_h,       //
			DF_UNIFORM_PARTITION, 3, new int[3]{ 1, 1,1 }, NULL, deriv_1ab_h,
			DF_MATRIX_STORAGE_ROWS, NULL);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		//2
		code = dfdEditPPSpline1D(Task, DF_PP_CUBIC, DF_PP_NATURAL, DF_BC_1ST_LEFT_DER | DF_BC_1ST_RIGHT_DER, Derivative2, DF_NO_IC, NULL, coef, DF_NO_HINT);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdConstruct1D(Task, DF_PP_SPLINE, DF_METHOD_STD);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, N, a_b,       //
			DF_UNIFORM_PARTITION, 1, new int[1]{1}, NULL, value2,
			DF_MATRIX_STORAGE_ROWS, NULL);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, 2, a_b,       //
			DF_UNIFORM_PARTITION, 3, new int[3]{ 1, 1 ,1}, NULL, deriv2,
			DF_MATRIX_STORAGE_ROWS, NULL);

		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, 2, a_b_h,       //
			DF_UNIFORM_PARTITION, 3, new int[3]{ 1, 1 ,1 }, NULL, deriv_2ab_h,
			DF_MATRIX_STORAGE_ROWS, NULL);

		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		//3
		code = dfdEditPPSpline1D(Task, DF_PP_CUBIC, DF_PP_NATURAL, DF_BC_FREE_END, NULL, DF_NO_IC, NULL, coef, DF_NO_HINT);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdConstruct1D(Task, DF_PP_SPLINE, DF_METHOD_STD);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, N, a_b,       //
			DF_UNIFORM_PARTITION, 1, new int[1]{ 1 }, NULL, value3,
			DF_MATRIX_STORAGE_ROWS, NULL);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, 2, a_b,       //
			DF_UNIFORM_PARTITION, 3, new int[3]{ 1, 1,1 }, NULL, deriv3,
			DF_MATRIX_STORAGE_ROWS, NULL);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, 2, a_b_h,       //
			DF_UNIFORM_PARTITION, 3, new int[3]{ 1, 1 ,1 }, NULL, deriv_3ab_h,
			DF_MATRIX_STORAGE_ROWS, NULL);

		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
		dfDeleteTask(&Task);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Dynamic library" + code;
		}
	}
		catch (...) {
			throw;
		}
		return true;

}
