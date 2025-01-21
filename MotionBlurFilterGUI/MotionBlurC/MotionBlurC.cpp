#include "pch.h"
#include "MotionBlurC.h"
void ApplyMotionBlur(uint8_t* imageData, uint8_t* temp, int startX, int endX, int width, int height, int radius) {
    int bytesPerPixel = 4; // 4 bytes per pixel for RGB
    int stride = width * bytesPerPixel; // length of one row in data array
    int divisorCount = (radius * 2) + 1;
    for (int y = 5; y < height - 5; y++) {
        for (int x = startX; x < endX; x++) {
            int red = 0, green = 0, blue = 0;

            // Apply the mask
            for (int i = -radius; i <= radius; i++) {
                int index = (y + i) * stride + x * bytesPerPixel;
                blue += imageData[index];
                green += imageData[index + 1];
                red += imageData[index + 2];

            }

            // Assign computed values to result
            int resultIndex = y * stride + x * bytesPerPixel;
            temp[resultIndex] = (int)(blue / divisorCount);
            temp[resultIndex + 1] = (int)(green / divisorCount);
            temp[resultIndex + 2] = (int)(red / divisorCount);
            temp[resultIndex + 3] = imageData[resultIndex + 3];
        }
    }
}