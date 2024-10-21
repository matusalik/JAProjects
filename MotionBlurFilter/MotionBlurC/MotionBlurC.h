#pragma once
#ifdef MotionBlurC_EXPORTS
#define MotionBlurC_API __declspec(dllexport)
#else
#define MotionBlurC_API __declspec(dllimport)
#endif

extern "C" MotionBlurC_API int add(int a, int b);