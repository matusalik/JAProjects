#pragma once
#ifdef MotionBlurC_EXPORTS
#define MotionBlurC_API __declspec(dllexport)
#else
#define MotionBlurC_API __declspec(dllimport)
#endif

extern "C" MotionBlurC_API void ApplyMotionBlur(uint8_t* ptr, int startX, int endX, int width, int height, int radius);