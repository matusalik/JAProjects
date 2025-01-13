#include "pch.h"
#include "MotionBlurC.h"
void ApplyMotionBlur(uint8_t* imageData, uint8_t* temp, int startX, int endX, int width, int height, int radius) {
    int bytesPerPixel = 4; // 4 bytes per pixel for RGB
    int stride = width * bytesPerPixel; // length of one row in data array
    int divisorCount = (radius * 2) + 1; 
    // Processing an image in vertical stripes
    for (int x = startX; x < endX; x++) {
        for (int y = 0; y < height; y++) {
            int redSum = 0, greenSum = 0, blueSum = 0;
            int count = 0;
            // Gathering pixels vertically
            for (int dy = -radius; dy <= radius; dy++) {
                int ny = y + dy; // New Y position
                if (ny >= 0 && ny < height) { // Checking image boundaries
                    int index = ny * stride + x * bytesPerPixel; // Array index
                    blueSum += imageData[index];           // Accumulating blue
                    greenSum += imageData[index + 1];     // Accumulating green
                    redSum += imageData[index + 2];       // Accumulating red
                    count++;                               // Counting pixels
                }
            }
            // Averaging value of RGB and loading them to temporary array
            if (count == divisorCount) {
                int blurredIndex = y * stride + x * bytesPerPixel; // Array index
                temp[blurredIndex] = blueSum / divisorCount; // Blue
                temp[blurredIndex + 1] = greenSum / divisorCount; // Green
                temp[blurredIndex + 2] = redSum / divisorCount; // Red
                temp[blurredIndex + 3] = imageData[blurredIndex + 3];
            }
        }
    }
    // Moving blured pixels to original image data
    for (int y = 0; y < height; y++) {
        for (int x = startX; x < endX; x++) {
            int blurredIndex = y * stride + x * bytesPerPixel; // blurred pixel array index
            int originalIndex = y * stride + x * bytesPerPixel; // original pixel array index

            // Przypisujemy rozmyte wartoœci do oryginalnej tablicy
            imageData[originalIndex] = temp[blurredIndex]; // Blue
            imageData[originalIndex + 1] = temp[blurredIndex + 1]; // Green  
            imageData[originalIndex + 2] = temp[blurredIndex + 2]; // Red
        }
    }
}